
using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Doctors.Command
{
    public class RegisterWorkSessionCommand : IRequest<MethodResult<WorkSessionModel>>
    {
        public DateTime Date { get; set; }
        public EnumShift Shift { get; set; }
    }

    public class RegisterWorkSessionCommandHandler : IRequestHandler<RegisterWorkSessionCommand, MethodResult<WorkSessionModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RegisterWorkSessionCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MethodResult<WorkSessionModel>> Handle(RegisterWorkSessionCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<WorkSessionModel>();

            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }

            var doctor = await _unitOfWork.Doctors
                .QueryableAsync()
                .Where(d => d.UserId == userId)
                .Select(d => new
                {
                    d.Id,
                    d.ServiceId
                })
                .FirstOrDefaultAsync(cancellationToken);
            if (doctor == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(doctor));
                return methodResult;
            }

            var (startTime, endTime) = GetWorkSessionTimeRange(request.Date, request.Shift);
            var existingSession = await _unitOfWork.WorkSessions
                .QueryableAsync()
                .Where(ws => ws.DoctorId == doctor.Id &&
                             ws.StartTime >= startTime &&
                             ws.EndTime <= endTime)
                .FirstOrDefaultAsync(cancellationToken);
            if (existingSession != null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumWorkSessionErrorCode.WorkSessionExisted), nameof(request.Date), request.Date);
                return methodResult;
            }

            
            var workSession = new WorkSession
            {
                Id = Guid.NewGuid(),
                DoctorId = doctor.Id,
                ServiceId = doctor.ServiceId,
                StartTime = startTime,
                EndTime = endTime,
                NextAvailableAt = startTime
            };
            await _unitOfWork.WorkSessions.AddAsync(workSession);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            methodResult.Result = new WorkSessionModel
            {
                Id = workSession.Id,
                DoctorId = workSession.DoctorId,
                StartTime = workSession.StartTime,
                EndTime = workSession.EndTime,
            };
            methodResult.StatusCode = StatusCodes.Status201Created;
            return methodResult;
        }

        private (DateTime, DateTime) GetWorkSessionTimeRange(DateTime date, EnumShift shift)
        {
            var baseDate = date.Date;
            return shift switch
            {
                EnumShift.Morning => (baseDate.Add(new TimeSpan(7, 30, 0)), baseDate.AddHours(12)),
                EnumShift.Afternoon => (baseDate.Add(new TimeSpan(13, 30, 0)), baseDate.Add(new TimeSpan(17, 30, 0))),
                EnumShift.Evening => (baseDate.AddHours(18), baseDate.AddHours(21)),
                _ => throw new ArgumentOutOfRangeException(nameof(shift), shift, null)
            };
        }
    }
}
