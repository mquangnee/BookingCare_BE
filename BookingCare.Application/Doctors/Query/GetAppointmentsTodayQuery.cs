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

namespace BookingCare.Application.Doctors.Query
{
    public class GetAppointmentsTodayQuery : IRequest<MethodResult<List<AppointmentModel>>>
    {
    }

    public class GetAppointmentsTodatQueryHandle : IRequestHandler<GetAppointmentsTodayQuery, MethodResult<List<AppointmentModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAppointmentsTodatQueryHandle(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MethodResult<List<AppointmentModel>>> Handle(GetAppointmentsTodayQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<AppointmentModel>>();

            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }

            //var startOfDay = new DateTime(2026, 04, 27).Date;
            var startOfDay = DateTime.Now.Date;
            var endOfDay = startOfDay.AddDays(1);

            var appointments = await _unitOfWork.Appointments
                .QueryableAsync()
                .AsNoTracking()
                .Where(a => a.Date >= startOfDay &&
                            a.Date < endOfDay &&
                            a.WorkSession!.Doctor!.UserId == userId &&
                            (a.Status == EnumAppointmentStatus.Waiting || a.Status == EnumAppointmentStatus.Completed))
                .Select(a => new AppointmentModel
                {
                    Id = a.Id,
                    AppointmentCode = a.AppointmentCode,
                    BookerId = a.BookerId,
                    WorkSessionId = a.WorkSessionId,
                    DoctorName = a.WorkSession!.Doctor!.FullName,
                    PatientProfileId = a.PatientProfileId,
                    PatientName = a.PatientProfile!.FullName,
                    Age = startOfDay.Year - a.PatientProfile.DateOfBirth.Year,
                    Gender = a.PatientProfile.Gender,
                    Date = a.Date,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime,
                    Status = a.Status
                })
                .ToListAsync(cancellationToken);

            methodResult.Result = appointments;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}