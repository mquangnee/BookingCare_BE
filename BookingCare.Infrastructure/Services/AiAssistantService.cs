using BookingCare.Application.IServices;
using BookingCare.Application.Patients.Commands.AppointmentCmd;
using BookingCare.Application.Patients.Queries.ProfileQuery;
using BookingCare.Application.Patients.Queries.WorkSessionQuery;
using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Setting;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace BookingCare.Infrastructure.Services
{
    public class AiAssistantService : IAiAssistantService
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _httpClient;
        private readonly GroqSetting _groqSetting;

        public AiAssistantService(
            IOptions<GroqSetting> options,
            IMediator mediator,
            IUnitOfWork unitOfWork,
            ILogger<AiAssistantService> logger,
            IHttpContextAccessor httpContextAccessor,
            HttpClient httpClient)
        {
            _groqSetting = options.Value;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
        }

        public async Task<string> ProcessChatAsync(string? message)
        {
            var userIdStr = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (string.IsNullOrEmpty(userIdStr) || !Guid.TryParse(userIdStr, out Guid userId))
            {
                return FallbackMessage();
            }
            var session = await GetOrCreateTodaySessionAsync(userId);
            await SaveMessageAsync(session.Id, EnumChatMessageRole.User, message);

            try
            {
                var history = await LoadHistoryAsync(session.Id);
                var messageList = BuildMessageList(history);

                // Groq call #1
                var (firstDoc, _) = await CallGroqAsync(messageList, withTools: true);
                if (firstDoc is null) return FallbackMessage();

                var messageNode = firstDoc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message");

                if (messageNode.TryGetProperty("tool_calls", out var toolCalls)
                    && toolCalls.ValueKind == JsonValueKind.Array
                    && toolCalls.GetArrayLength() > 0)
                {
                    var secondNode = await HandleToolCallsAsync(messageList, messageNode, toolCalls);
                    if (secondNode is null) return FallbackMessage();
                    messageNode = secondNode.Value;
                }

                string finalText = string.Empty;
                if (messageNode.TryGetProperty("content", out var cp) && cp.ValueKind == JsonValueKind.String)
                {
                    finalText = cp.GetString() ?? string.Empty;
                }
                else if (cp.ValueKind != JsonValueKind.Null && cp.ValueKind != JsonValueKind.Undefined)
                {
                    finalText = cp.GetRawText();
                }

                if (string.IsNullOrWhiteSpace(finalText) && _logger.IsEnabled(LogLevel.Warning))
                {
                    _logger.LogWarning("Groq API returned an empty message content. MessageNode: {Node}", messageNode.GetRawText());
                    return FallbackMessage();
                }

                await SaveMessageAsync(session.Id, EnumChatMessageRole.Assistant, finalText);
                return finalText;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProcessChatAsync failed");
                return FallbackMessage();
            }
        }

        private async Task<ChatSession> GetOrCreateTodaySessionAsync(Guid currentUserId)
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var existing = await _unitOfWork.ChatSessions
                .QueryableAsync()
                .FirstOrDefaultAsync(cs => cs.UserId == currentUserId
                                        && cs.CreatedDate >= today
                                        && cs.CreatedDate < tomorrow);

            if (existing is not null) return existing;

            var session = new ChatSession
            {
                Id = Guid.NewGuid(),
                UserId = currentUserId,
                Title = $"Chat Session: {today:dd/MM/yyyy}"
            };
            await _unitOfWork.ChatSessions.AddAsync(session);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return session;
        }

        private async Task SaveMessageAsync(Guid sessionId, EnumChatMessageRole role, string? content)
        {
            await _unitOfWork.ChatMessages.AddAsync(new ChatMessage
            {
                ChatSessionId = sessionId,
                ChatRole = role,
                Content = content
            });
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        }

        private async Task<List<ChatMessage>> LoadHistoryAsync(Guid sessionId)
        {
            return await _unitOfWork.ChatMessages
                .QueryableAsync()
                .Where(cm => cm.ChatSessionId == sessionId)
                .OrderBy(cm => cm.CreatedDate)
                .ToListAsync();
        }

        private List<object> BuildMessageList(List<ChatMessage> history)
        {
            var list = new List<object>
            {
                new
                {
                    role    = "system",
                    content = AiAssistantSetting.Prompts.DefaultSystemPrompt
                              + "\n\n"
                              + BuildNext7DaysText()
                }
            };

            foreach (var msg in history)
            {
                var role = msg.ChatRole == EnumChatMessageRole.User ? "user" : "assistant";
                list.Add(new { role, content = msg.Content });
            }

            return list;
        }

        private async Task<(JsonDocument? doc, string raw)> CallGroqAsync(
            List<object> messageList,
            bool withTools)
        {
            object body = withTools
                ? new { model = _groqSetting.Model, messages = messageList, tools = BuildToolList(), tool_choice = "auto" }
                : new { model = _groqSetting.Model, messages = messageList };

            var reqContent = new StringContent(
                JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _groqSetting.ApiKey);

            var resp = await _httpClient.PostAsync(_groqSetting.BaseUrl, reqContent);
            var raw = await resp.Content.ReadAsStringAsync();

            _logger.LogInformation("=== GROQ [{Status}] ===\n{Body}", resp.StatusCode, raw);

            if (!resp.IsSuccessStatusCode)
            {
                _logger.LogError("Groq error: {Body}", raw);
                return (null, raw);
            }

            return (JsonDocument.Parse(raw), raw);
        }

        private async Task<JsonElement?> HandleToolCallsAsync(
            List<object> messageList,
            JsonElement messageNode,
            JsonElement toolCalls)
        {
            messageList.Add(messageNode);

            foreach (var toolCall in toolCalls.EnumerateArray())
            {
                var toolCallId = toolCall.GetProperty("id").GetString();
                var functionName = toolCall.GetProperty("function").GetProperty("name").GetString();
                var argsStr = toolCall.GetProperty("function").GetProperty("arguments").GetString() ?? "{}";

                _logger.LogInformation("=== TOOL: {Name} | ARGS: {Args} ===", functionName, argsStr);

                JsonDocument argsDoc;
                try { argsDoc = JsonDocument.Parse(argsStr.Trim()); }
                catch 
                { 
                    _logger.LogError("Cannot parse tool arguments: {Args}", argsStr);
                    argsDoc = JsonDocument.Parse("{}");
                }

                var toolResult = await ExecuteToolAsync(functionName ?? "unknown", argsDoc);

                messageList.Add(new
                {
                    role = "tool",
                    tool_call_id = toolCallId,
                    name = functionName,
                    content = toolResult
                });
            }

            var (doc, _) = await CallGroqAsync(messageList, withTools: true);
            if (doc is null) return null;

            return doc.RootElement.GetProperty("choices")[0].GetProperty("message");
        }

        private async Task<string> ExecuteToolAsync(string name, JsonDocument argsDoc)
        {
            var root = argsDoc.RootElement;

            switch (name)
            {
                case AiAssistantSetting.Tools.GetDoctorSchedules.Name:
                    {
                        if (!TryGetGuid(root, "doctorId", out var doctorId))
                            return ErrorResult("Không tìm thấy thông tin bác sĩ. Vui lòng chọn lại.");

                        if (!TryGetDate(root, "date", out var date))
                            return ErrorResult("Ngày không hợp lệ. Vui lòng chọn lại.");

                        var today = DateTime.Today;
                        var maxDate = today.AddDays(6);

                        if (date < today || date > maxDate)
                            return JsonSerializer.Serialize(new
                            {
                                available = false,
                                message = $"Chỉ chấp nhận ngày từ {today:dd/MM/yyyy} đến {maxDate:dd/MM/yyyy}."
                            });

                        var qr = await _mediator.Send(new GetAvailableTimeSlotsQuery
                        {
                            DoctorId = doctorId,
                            Date = date,
                            DaysToFetch = 1
                        });

                        if (!qr.IsOK || qr.Result == null)
                            return ErrorResult("Không thể lấy lịch khám. Vui lòng thử lại sau.");

                        var targetDay = qr.Result.FirstOrDefault(d => d.Date.Date == date);

                        var freeSlots = targetDay?.AvailableTimeSlots?
                            .Where(s => !s.IsFull)
                            .Select(s => new
                            {
                                startTime = s.StartTime.ToString(@"hh\:mm"),
                                endTime = s.EndTime.ToString(@"hh\:mm"),
                                timeString = s.TimeString
                            })
                            .ToList();

                        var hasSlots = freeSlots?.Count > 0;

                        return JsonSerializer.Serialize(new
                        {
                            available = hasSlots,
                            date = date.ToString("yyyy-MM-dd"),
                            dayOfWeek = GetVietnameseDayOfWeek(date),
                            displayDate = date.ToString("dd/MM/yyyy"),
                            totalSlots = freeSlots?.Count ?? 0,
                            slots = hasSlots ? freeSlots : null,
                            message = hasSlots
                                ? $"Có {freeSlots!.Count} ca khám trống."
                                : "Không có ca khám trống hoặc đã kín lịch trong ngày này."
                        });
                    }

                case AiAssistantSetting.Tools.GetPatientProfiles.Name:
                    {
                        if (!TryGetDate(root, "date", out var profileDate))
                            return ErrorResult("Ngày khám không hợp lệ.");

                        if (!TryGetTimeSpan(root, "startTime", out var startTime))
                            return ErrorResult("Giờ bắt đầu không hợp lệ.");

                        if (!TryGetTimeSpan(root, "endTime", out var endTime))
                            return ErrorResult("Giờ kết thúc không hợp lệ.");

                        var profiles = await _mediator.Send(new GetPatientProfilesForBookingQuery
                        {
                            Date = profileDate,
                            StartTime = startTime,
                            EndTime = endTime
                        });

                        var simplifiedProfile = profiles?.Result?.Select(p => new
                        {
                            id = p.Id,
                            name = p.FullName,
                            dateOfBirth = p.DateOfBirth.ToString("yyyy-MM-dd")
                        }).ToList();

                        return JsonSerializer.Serialize(new
                        {
                            date = profileDate.ToString("yyyy-MM-dd"),
                            startTime = startTime.ToString(@"hh\:mm"),
                            endTime = endTime.ToString(@"hh\:mm"),
                            profiles = simplifiedProfile,
                            note = "Dùng trường 'id' của hồ sơ được chọn làm patientProfileId khi gọi book_appointment."
                        });
                    }

                case AiAssistantSetting.Tools.BookAppointment.Name:
                    {
                        if (!TryGetGuid(root, "doctorId", out var bookDoctorId))
                            return ErrorResult("Thiếu thông tin bác sĩ. Vui lòng thử lại.");

                        if (!TryGetGuid(root, "patientProfileId", out var patientProfileId))
                            return ErrorResult("Thiếu thông tin hồ sơ bệnh nhân. Vui lòng thử lại.");

                        if (!TryGetDate(root, "date", out var bookDate))
                            return ErrorResult("Ngày khám không hợp lệ. Vui lòng thử lại.");

                        if (!TryGetTimeSpan(root, "startTime", out var bookStart))
                            return ErrorResult("Giờ bắt đầu không hợp lệ. Vui lòng thử lại.");

                        if (!TryGetTimeSpan(root, "endTime", out var bookEnd))
                            return ErrorResult("Giờ kết thúc không hợp lệ. Vui lòng thử lại.");

                        await using var transaction = await _unitOfWork.BeginTransactionAsync(CancellationToken.None);
                        try
                        {
                            var command = new CreateAppointmentCommand
                            {
                                DoctorId = bookDoctorId,
                                PatientProfileId = patientProfileId,
                                Date = bookDate,
                                StartTime = bookStart,
                                EndTime = bookEnd
                            };

                            var commandResult = await _mediator.Send(command);

                            if (!commandResult.IsOK)
                            {
                                await transaction.RollbackAsync();
                                return ErrorResult("Đặt lịch thất bại: " + commandResult.ErrorMessages);
                            }

                            await transaction.CommitAsync();
                            return JsonSerializer.Serialize(new { success = true, message = "Đặt lịch thành công." });
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "BookAppointment transaction failed");
                            try { await transaction.RollbackAsync(); } catch { }
                            return ErrorResult("Đặt lịch thất bại. Vui lòng thử lại.");
                        }
                    }

                default:
                    _logger.LogWarning("Unsupported tool: {Name}", name);
                    return ErrorResult($"Chức năng '{name}' chưa được hỗ trợ.");
            }
        }

        private object[] BuildToolList() => new object[]
        {
            MakeTool(
                AiAssistantSetting.Tools.GetDoctorSchedules.Name,
                AiAssistantSetting.Tools.GetDoctorSchedules.Description,
                new
                {
                    doctorId = new
                    {
                        type = AiAssistantSetting.Types.String,
                        description = AiAssistantSetting.Tools.GetDoctorSchedules.ParameterDescriptions.DoctorId
                    },
                    date = new
                    {
                        type = AiAssistantSetting.Types.String,
                        description = AiAssistantSetting.Tools.GetDoctorSchedules.ParameterDescriptions.Date
                    }
                },
                new[] 
                {
                    AiAssistantSetting.Tools.GetDoctorSchedules.Parameters.DoctorId,
                    AiAssistantSetting.Tools.GetDoctorSchedules.Parameters.Date
                }
            ),
            MakeTool(
                AiAssistantSetting.Tools.GetPatientProfiles.Name,
                AiAssistantSetting.Tools.GetPatientProfiles.Description,
                new
                {
                    date = new
                    {
                        type = AiAssistantSetting.Types.String,
                        description = AiAssistantSetting.Tools.GetPatientProfiles.ParameterDescriptions.Date
                    },
                    startTime = new
                    {
                        type = AiAssistantSetting.Types.String,
                        description = AiAssistantSetting.Tools.GetPatientProfiles.ParameterDescriptions.StartTime
                    },
                    endTime = new
                    {
                        type = AiAssistantSetting.Types.String,
                        description = AiAssistantSetting.Tools.GetPatientProfiles.ParameterDescriptions.EndTime
                    }
                },
                new[] 
                { 
                    AiAssistantSetting.Tools.GetPatientProfiles.Parameters.Date,
                    AiAssistantSetting.Tools.GetPatientProfiles.Parameters.StartTime,
                    AiAssistantSetting.Tools.GetPatientProfiles.Parameters.EndTime
                }
            ),
            MakeTool(
                AiAssistantSetting.Tools.BookAppointment.Name,
                AiAssistantSetting.Tools.BookAppointment.Description,
                new
                {
                    doctorId = new
                    {
                        type = AiAssistantSetting.Types.String,
                        description = AiAssistantSetting.Tools.BookAppointment.ParameterDescriptions.DoctorId
                    },
                    patientProfileId = new
                    {
                        type = AiAssistantSetting.Types.String,
                        description = AiAssistantSetting.Tools.BookAppointment.ParameterDescriptions.PatientProfileId
                    },
                    date = new
                    {
                        type = AiAssistantSetting.Types.String,
                        description = AiAssistantSetting.Tools.BookAppointment.ParameterDescriptions.Date
                    },
                    startTime = new
                    {
                        type = AiAssistantSetting.Types.String,
                        description = AiAssistantSetting.Tools.BookAppointment.ParameterDescriptions.StartTime
                    },
                    endTime = new
                    {
                        type = AiAssistantSetting.Types.String,
                        description = AiAssistantSetting.Tools.BookAppointment.ParameterDescriptions.EndTime
                    }
                },
                new[] 
                { 
                    AiAssistantSetting.Tools.BookAppointment.Parameters.DoctorId,
                    AiAssistantSetting.Tools.BookAppointment.Parameters.PatientProfileId,
                    AiAssistantSetting.Tools.BookAppointment.Parameters.Date,
                    AiAssistantSetting.Tools.BookAppointment.Parameters.StartTime,
                    AiAssistantSetting.Tools.BookAppointment.Parameters.EndTime
                }
            )
        };

        private static object MakeTool(string name, string description, object properties, string[] required)
        {
            return new
            {
                type = AiAssistantSetting.Types.Function,
                function = new
                {
                    name,
                    description,
                    parameters = new
                    {
                        type = AiAssistantSetting.Types.Object,
                        properties,
                        required
                    }
                }
            };
        }

        private static bool TryGetGuid(JsonElement root, string key, out Guid result)
        {
            result = Guid.Empty;
            return root.TryGetProperty(key, out var p)
                && Guid.TryParse(p.GetString(), out result)
                && result != Guid.Empty;
        }

        private static bool TryGetDate(JsonElement root, string key, out DateTime result)
        {
            result = default;
            if (!root.TryGetProperty(key, out var p)) return false;
            if (!DateTime.TryParse(p.GetString(), out result)) return false;
            result = result.Date;
            return true;
        }

        private static bool TryGetTimeSpan(JsonElement root, string key, out TimeSpan result)
        {
            result = default;
            return root.TryGetProperty(key, out var p)
                && TimeSpan.TryParse(p.GetString(), out result);
        }

        private static string ErrorResult(string message)
        {
            return JsonSerializer.Serialize(new { success = false, message });
        }

        private static string FallbackMessage()
        {
            return "Xin lỗi, đã có lỗi xảy ra khi xử lý yêu cầu của bạn. Vui lòng thử lại sau.";
        }

        private static string GetVietnameseDayOfWeek(DateTime date) => date.DayOfWeek switch
        {
            DayOfWeek.Monday => "Thứ 2",
            DayOfWeek.Tuesday => "Thứ 3",
            DayOfWeek.Wednesday => "Thứ 4",
            DayOfWeek.Thursday => "Thứ 5",
            DayOfWeek.Friday => "Thứ 6",
            DayOfWeek.Saturday => "Thứ 7",
            DayOfWeek.Sunday => "Chủ nhật",
            _ => ""
        };

        private static string BuildNext7DaysText()
        {
            var sb = new StringBuilder();
            sb.AppendLine("DANH SÁCH 7 NGÀY ĐẶT LỊCH (hệ thống tính sẵn — KHÔNG tự tính lại):");
            sb.AppendLine();
            for (int i = 0; i < 7; i++)
            {
                var d = DateTime.Today.AddDays(i);
                var label = i == 0 ? "Hôm nay  " : i == 1 ? "Ngày mai " : "         ";
                sb.AppendLine($"  {i + 1}. {label} — {GetVietnameseDayOfWeek(d)}, ngày {d:dd/MM/yyyy}  (date={d:yyyy-MM-dd})");
            }
            return sb.ToString();
        }
    }
}