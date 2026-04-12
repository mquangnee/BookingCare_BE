using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Patients.Queries.ProfileQuery
{
    public class GetPatientProfilesForBookingQuery : IRequest<MethodResult<List<PatientProfileModel>>>
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; } 
        public TimeSpan EndTime { get; set; }   
    }

    public class GetPatientProfilesForBookingQueryHandler : IRequestHandler<GetPatientProfilesForBookingQuery, MethodResult<List<PatientProfileModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetPatientProfilesForBookingQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MethodResult<List<PatientProfileModel>>> Handle(GetPatientProfilesForBookingQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<PatientProfileModel>>();

            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }

            var patient = await _unitOfWork.Patients.QueryableAsync().FirstOrDefaultAsync(p => p.UserId == userId, cancellationToken);
            if (patient == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(patient));
                return methodResult;
            }

            var myProfiles = await _unitOfWork.PatientProfiles.QueryableAsync()
                .Where(p => p.PatientId == patient.Id)
                .Select(p => new PatientProfileModel
                {
                    Id = p.Id,
                    PatientCode = patient.PatientCode,
                    ProfileCode = p.ProfileCode,
                    FullName = p.FullName,
                    DateOfBirth = p.DateOfBirth,
                    Gender = p.Gender,
                    PhoneNumber = p.PhoneNumber,
                    Relationship = p.Relationship,
                    BloodType = p.BloodType,
                    MedicalHistory = p.MedicalHistory,
                    IsShared = false
                })
                .ToListAsync(cancellationToken);

            var sharedProfiles = await (from ps in _unitOfWork.ProfileShares.QueryableAsync()
                                        join p in _unitOfWork.PatientProfiles.QueryableAsync() on ps.PatientProfileId equals p.Id
                                        join pt in _unitOfWork.Patients.QueryableAsync() on p.PatientId equals pt.Id
                                        where ps.SharedToUserId == userId 
                                           && ps.ShareStatus == Shared.Enum.EnumShareStatus.Accepted 
                                           && (ps.SharePermission == Shared.Enum.EnumSharePermission.BookAppointment || ps.SharePermission == Shared.Enum.EnumSharePermission.FullAccess)
                                        select new PatientProfileModel
                                        {
                                            Id = p.Id,
                                            PatientCode = pt.PatientCode,
                                            ProfileCode = p.ProfileCode,
                                            FullName = p.FullName,
                                            DateOfBirth = p.DateOfBirth,
                                            Gender = p.Gender,
                                            PhoneNumber = p.PhoneNumber,
                                            Relationship = p.Relationship,
                                            BloodType = p.BloodType,
                                            MedicalHistory = p.MedicalHistory,
                                            IsShared = true,
                                        }).ToListAsync(cancellationToken);

            var allProfiles = myProfiles.Concat(sharedProfiles)
                                        .GroupBy(p => p.Id)
                                        .Select(g => g.First())
                                        .ToList();

            var profileIds = allProfiles.Select(p => p.Id).ToList();

            var bookedProfileIds = await _unitOfWork.Appointments.QueryableAsync()
                .Where(a => a.Date.Date == request.Date.Date
                         && a.Status != Shared.Enum.EnumAppointmentStatus.Cancelled
                         && profileIds.Contains(a.PatientProfileId)
                         && a.StartTime < request.EndTime 
                         && a.EndTime > request.StartTime)
                .Select(a => a.PatientProfileId)
                .Distinct()
                .ToListAsync(cancellationToken);

            var availableProfiles = allProfiles.Where(p => !bookedProfileIds.Contains(p.Id)).ToList();
            methodResult.Result = availableProfiles;

            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}