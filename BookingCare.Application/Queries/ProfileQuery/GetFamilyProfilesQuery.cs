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

namespace BookingCare.Application.Queries.ProfileQuery
{
    public class GetFamilyProfilesQuery : IRequest<MethodResult<List<UserProfileModel>>>
    {
    }

    public class GetFamilyProfilesQueryHandler : IRequestHandler<GetFamilyProfilesQuery, MethodResult<List<UserProfileModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetFamilyProfilesQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MethodResult<List<UserProfileModel>>> Handle(GetFamilyProfilesQuery request, CancellationToken cancellationToken)
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

            var profileQuery = _unitOfWork.PatientProfiles.QueryableAsync();
            var familyProfiles = await profileQuery
                .Where(pp => pp.PatientId == patient.Id && pp.Relationship != EnumRelationship.MySelf)
                .Select(p => new UserProfileModel
                {
                    Id = p.Id,
                    PatientCode = patient.PatientCode,
                    ProfileCode = p.ProfileCode,
                    FullName = p.FullName,
                    DateOfBirth = p.DateOfBirth,
                    Gender = p.Gender,
                    CitizenId = p.CitizenId,
                    PhoneNumber = p.PhoneNumber,
                    Relationship = p.Relationship,
                    BloodType = p.BloodType,
                    MedicalHistory = p.MedicalHistory,
                    IsShared = false
                })
                .ToListAsync(cancellationToken);

            var shareProfileIds = await _unitOfWork.ProfileShares.QueryableAsync()
                .Where(sp => sp.SharedToUserId == userId && sp.ShareStatus == EnumShareStatus.Accepted)
                .Select(sp => sp.ProfileId)
                .ToListAsync(cancellationToken);
            var sharedProfiles = await profileQuery
                .Where(p => shareProfileIds.Contains(p.Id))
                .Select(p => new UserProfileModel
                {
                    Id = p.Id,
                    PatientCode = null,
                    ProfileCode = p.ProfileCode,
                    FullName = p.FullName,
                    DateOfBirth = p.DateOfBirth,
                    Gender = p.Gender,
                    CitizenId = p.CitizenId,
                    PhoneNumber = p.PhoneNumber,
                    Relationship = p.Relationship,
                    BloodType = p.BloodType,
                    MedicalHistory = p.MedicalHistory,
                    IsShared = true,
                    SharePermission = _unitOfWork.ProfileShares.QueryableAsync()
                        .Where(sp => sp.ProfileId == p.Id && sp.SharedToUserId == userId && sp.ShareStatus == EnumShareStatus.Accepted)
                        .Select(sp => sp.SharePermission)
                        .FirstOrDefault()
                })
                .ToListAsync(cancellationToken);

            var allProfiles = familyProfiles.Concat(sharedProfiles).ToList();
            methodResult.Result = allProfiles;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
