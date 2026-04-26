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
    public class GetMedicalHistoryQuery : IRequest<MethodResult<List<MedicalHistoryModel>>>
    {
        public string? Keyword { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class GetMedicalHistoryQueryHandler : IRequestHandler<GetMedicalHistoryQuery, MethodResult<List<MedicalHistoryModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetMedicalHistoryQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MethodResult<List<MedicalHistoryModel>>> Handle(GetMedicalHistoryQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<MedicalHistoryModel>>();

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
                    d.DoctorCode
                })
                .FirstOrDefaultAsync(cancellationToken);
            if (doctor == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(doctor));
                return methodResult;
            }

            var query = _unitOfWork.Appointments.QueryableAsync()
                .Include(a => a.PatientProfile)
                .Include(a => a.WorkSession)
                .Where(a => a.WorkSession!.DoctorId == doctor.Id && a.Status == EnumAppointmentStatus.Completed);

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(a => 
                    (a.AppointmentCode != null && a.AppointmentCode.Contains(request.Keyword)) || 
                    (a.PatientProfile != null && a.PatientProfile.FullName!.Contains(request.Keyword)));
            }

            if (request.FromDate.HasValue)
            {
                var fromDate = request.FromDate.Value.Date;
                query = query.Where(a => a.Date >= fromDate);
            }

            if (request.ToDate.HasValue)
            {
                var toDateLimit = request.ToDate.Value.Date.AddDays(1);
                query = query.Where(a => a.Date < toDateLimit);
            }

            var appointments = await query.ToListAsync(cancellationToken);

            var appointmentIds = appointments.Select(a => a.Id).ToList();

            var prescriptionsDict = await _unitOfWork.Prescriptions
                .QueryableAsync()
                .Where(p => appointmentIds.Contains(p.AppointmentId))
                .Select(p => new { p.AppointmentId, p.Diagnosis })
                .ToDictionaryAsync(k => k.AppointmentId, v => v.Diagnosis, cancellationToken);

            var currentYear = DateTime.Now.Year;
            var medicalHistoryList = appointments.Select(appointment => new MedicalHistoryModel
            {
                AppointmentId = appointment.Id,
                WorkSessionId = appointment.WorkSessionId,
                PatientProfileId = appointment.PatientProfileId,
                AppointmentCode = appointment.AppointmentCode,
                ProfileCode = appointment.PatientProfile!.ProfileCode,
                DoctorName = doctor.DoctorCode,
                PatientName = appointment.PatientProfile!.FullName,
                Age = currentYear - appointment.PatientProfile.DateOfBirth.Year,
                Diagnosis = prescriptionsDict.GetValueOrDefault(appointment.Id) ?? "Không có chẩn đoán",
                Gender = appointment.PatientProfile.Gender,
                Type = appointment.Type,
                Date = appointment.WorkSession!.Date,
                StartTime = appointment.StartTime,
                EndTime = appointment.EndTime
            })
            .OrderByDescending(a => a.Date)
            .ThenBy(a => a.StartTime)
            .ToList();

            methodResult.Result = medicalHistoryList;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
