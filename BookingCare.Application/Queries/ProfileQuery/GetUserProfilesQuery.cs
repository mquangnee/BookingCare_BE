using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Queries.ProfileQuery
{
    public class GetUserProfilesQuery : IRequest<MethodResult<List<UserProfileModel>>>
    {
    }

    public class GetUserProfilesQueryHandler : IRequestHandler<GetUserProfilesQuery, MethodResult<List<UserProfileModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetUserProfilesQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MethodResult<List<UserProfileModel>>> Handle(GetUserProfilesQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<UserProfileModel>>();

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
            var patientProfiles = await _unitOfWork.PatientProfiles.QueryableAsync().Where(p => p.PatientId == patient.Id && p.Relationship != EnumRelationship.MySelf).ToListAsync(cancellationToken);
            if (patientProfiles == null || !patientProfiles.Any())
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(patientProfiles));
                return methodResult;
            }

            methodResult.Result = patientProfiles.Select(patientProfile => new UserProfileModel
            {
                PatientCode = patient.PatientCode,
                ProfileCode = patientProfile.ProfileCode,
                FullName = patientProfile.FullName,
                DateOfBirth = patientProfile.DateOfBirth,
                Gender  = patientProfile.Gender,
                CitizenId = patientProfile.CitizenId,
                PhoneNumber = patientProfile.PhoneNumber,
                Relationship = patientProfile.Relationship,
                BloodType = patientProfile.BloodType,
                MedicalHistory = patientProfile.MedicalHistory
            }).ToList();
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
