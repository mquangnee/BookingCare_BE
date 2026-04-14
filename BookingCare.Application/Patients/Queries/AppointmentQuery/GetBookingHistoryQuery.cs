using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Domain.Models.QueryModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Patients.Queries.AppointmentQuery
{
    public class GetBookingHistoryQuery : GetBookingHistoryQueryModel, IRequest<MethodResult<PagedResult<BookingHistoryModel>>>
    {
    }

    public class GetBookingHistoryQueryHandler : IRequestHandler<GetBookingHistoryQuery, MethodResult<PagedResult<BookingHistoryModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetBookingHistoryQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MethodResult<PagedResult<BookingHistoryModel>>> Handle(GetBookingHistoryQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<PagedResult<BookingHistoryModel>>();

            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }
            var query = _unitOfWork.Appointments.QueryableAsync()
                .Include(a => a.WorkSession)
                    .ThenInclude(ws => ws.Doctor)
                        .ThenInclude(d => d.Specialty)
                .Include(a => a.PatientProfile)
                .Include(a => a.Service)
                .Where(a => a.BookerId == userId);
            if (request.Status.HasValue)
            {
                query = query.Where(a => a.Status == request.Status.Value);
            }
            if (!string.IsNullOrWhiteSpace(request.DoctorName))
            {
                var doctorPattern = $"%{request.DoctorName.Trim()}%";
                query = query.Where(a => EF.Functions.Like(a.WorkSession!.Doctor!.FullName, doctorPattern));
            }
            if (!string.IsNullOrWhiteSpace(request.PatientProfileName))
            {
                var patientPattern = $"%{request.PatientProfileName.Trim()}%";
                query = query.Where(a => EF.Functions.Like(a.PatientProfile!.FullName, patientPattern));
            }
            var totalCount = await query.CountAsync(cancellationToken);

            query = query
                .OrderBy(a => a.Date)
                .ThenBy(a => a.StartTime);
            var appointments = await query.ToListAsync(cancellationToken);
            var bookingHistories = appointments.Select(a => new BookingHistoryModel
            {
                Id = a.Id,
                AppointmentCode = a.AppointmentCode,
                Date = a.Date,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                Status = a.Status,
                DoctorName = a.WorkSession!.Doctor!.FullName,
                DoctorCode = a.WorkSession.Doctor.DoctorCode,
                DoctorId = a.WorkSession.Doctor.Id,
                SpecialtyName = a.WorkSession.Doctor.Specialty?.Name ?? string.Empty,
                PatientProfileName = a.PatientProfile!.FullName,
                PatientProfileCode = a.PatientProfile.ProfileCode,
                PatientProfileId = a.PatientProfile.Id,
                ServiceId = a.ServiceId,
                ServiceName = a.Service!.Name,
                CreatedDate = a.CreatedDate
            }).ToList();

            var pagedResult = new PagedResult<BookingHistoryModel>
            {
                Items = bookingHistories,
                TotalCount = totalCount
            };

            methodResult.Result = pagedResult;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}