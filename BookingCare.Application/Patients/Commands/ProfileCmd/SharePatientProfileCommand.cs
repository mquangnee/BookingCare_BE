using BookingCare.Application.Services;
using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Patients.Commands.ProfileCmd
{
    public class SharePatientProfileCommand : SharePatientProfileCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class SharePatientProfileCommandHandler : IRequestHandler<SharePatientProfileCommand, MethodResult<bool>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationRealTimeService _notificationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SharePatientProfileCommandHandler(UserManager<User> userManager, IUnitOfWork unitOfWork, INotificationRealTimeService notificationService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MethodResult<bool>> Handle(SharePatientProfileCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            var senderIdStr = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (string.IsNullOrEmpty(senderIdStr) || !Guid.TryParse(senderIdStr, out Guid senderId))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }
            var senderEmail = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
            if (senderEmail == request.Email)
            {
                methodResult.AddErrorBadRequest(nameof(EnumProfileShareErrorCode.CannotShareToYourself), nameof(request.Email), request.Email);
                return methodResult;
            }
            var user = await _userManager.FindByEmailAsync(request.Email!);
            if (user == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.Email), request.Email);
                return methodResult;
            }
            var profile = await _unitOfWork.PatientProfiles.GetByIdAsync(request.ProfileId);
            if (profile == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.ProfileId), request.ProfileId);
                return methodResult;
            }
            var existingShare = await _unitOfWork.ProfileShares.QueryableAsync().AnyAsync(ps => ps.PatientProfileId == request.ProfileId && ps.SharedToUserId == user.Id && ps.ShareStatus != EnumShareStatus.Rejected);
            if (existingShare)
            {
                methodResult.AddErrorBadRequest(nameof(EnumProfileShareErrorCode.ProfileSharedToThisUser), nameof(existingShare));
                return methodResult;
            }
            var profileShare = new ProfileShare
            {
                PatientProfileId = request.ProfileId,
                SharedByUserId = senderId,
                SharedToUserId = user.Id,
                SharePermission = request.Permission
            };
            await _unitOfWork.ProfileShares.AddAsync(profileShare);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var fullName = profile.FullName;
            string permissionText = request.Permission switch
            {
                EnumSharePermission.ReadOnly => "Chỉ xem thông tin",
                EnumSharePermission.BookAppointment => "Được phép đặt lịch khám",
                EnumSharePermission.FullAccess => "Toàn quyền quản lý",
                _ => "Chỉ xem thông tin"
            };
            var messageParams = new List<object>
            {
                fullName!,
                profile.ProfileCode!,
                permissionText,
            };
            await SendNotificationAsync(_notificationService, profileShare.Id, senderId, user.Id, profile.Id, messageParams);
            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }

        private static async Task SendNotificationAsync(INotificationRealTimeService notificationService, Guid patientProfileId, Guid senderId, Guid receiverId, Guid objectId, List<object> messageParams)
        {
            await notificationService.SendNotificationAsync(
                receiverId: receiverId,
                senderId: senderId,
                patientProfileId: patientProfileId,
                content: EnumNotificationContent.ShareProfileInvite,
                type: EnumNotificationType.ShareProfileInvite,
                objectId: objectId,
                messageParams: messageParams,
                cancellationToken: CancellationToken.None
            );
        }
    }
}
