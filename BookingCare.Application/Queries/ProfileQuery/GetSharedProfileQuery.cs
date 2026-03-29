using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Queries.ProfileQuery
{
    public class GetSharedProfileQuery : IRequest<MethodResult<List<ProfileShareModel>>>
    {
    }

    public class GetSharedProfileQueryHandler : IRequestHandler<GetSharedProfileQuery, MethodResult<List<ProfileShareModel>>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public GetSharedProfileQueryHandler(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<MethodResult<List<ProfileShareModel>>> Handle(GetSharedProfileQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<ProfileShareModel>>();

            var userIdStr = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (string.IsNullOrEmpty(userIdStr) || !Guid.TryParse(userIdStr, out Guid userId))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }
            var sharedProfiles = await _unitOfWork.ProfileShares.QueryableAsync().Where(ps => ps.SharedByUserId == userId && ps.ShareStatus != EnumShareStatus.Rejected).ToListAsync(cancellationToken);
            if (sharedProfiles == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(sharedProfiles));
                return methodResult;
            }
            var listProfileShareModels = new List<ProfileShareModel>();
            foreach (var profileShare in sharedProfiles)
            {
                var inforUser = await GetInforUser(_userManager, _unitOfWork, profileShare.SharedToUserId);
                if (inforUser == null)
                {
                    methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(inforUser));
                    return methodResult;
                }
                var profileShareModel = new ProfileShareModel
                {
                    Id = profileShare.Id,
                    ProfileId = profileShare.ProfileId,
                    SharedByUserId = profileShare.SharedByUserId,
                    SharedToUserId = profileShare.SharedToUserId,
                    UserName = inforUser.Value.Item1,
                    Email = inforUser.Value.Item2,
                    ShareStatus = profileShare.ShareStatus,
                    SharePermission = profileShare.SharePermission,
                    CreatedDate = profileShare.CreatedDate
                };
                listProfileShareModels.Add(profileShareModel);
            }
            methodResult.Result = listProfileShareModels;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }

        private static async Task<(string, string)?> GetInforUser(UserManager<User> userManager, IUnitOfWork unitOfWork, Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return null;
            }
            var patient = await unitOfWork.Patients.QueryableAsync().FirstOrDefaultAsync(p => p.UserId == userId);
            if (patient == null)
            {
                return null;
            }
            var patientProfile = await unitOfWork.PatientProfiles.QueryableAsync().FirstOrDefaultAsync(pp => pp.PatientId == patient.Id && pp.Relationship == EnumRelationship.MySelf);
            if (patientProfile == null)
            {
                return null;
            }
            return (patientProfile.FullName ?? string.Empty, user.Email ?? string.Empty);
        }
    }
}
