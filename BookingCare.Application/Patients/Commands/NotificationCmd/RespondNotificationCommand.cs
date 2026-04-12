using BookingCare.Application.Services;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Patients.Commands.NotificationCmd
{
    public class RespondNotificationCommand : RespondNotificationCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class RespondNotificationCommandHandler : IRequestHandler<RespondNotificationCommand, MethodResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationRealTimeService _notificationService;

        public RespondNotificationCommandHandler(IUnitOfWork unitOfWork, INotificationRealTimeService notificationService)
        {
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
        }

        public async Task<MethodResult<bool>> Handle(RespondNotificationCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            var notification = await _unitOfWork.Notifications.GetByIdAsync(request.NotificationId);
            if (notification == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.NotificationId), request.NotificationId);
                return methodResult;
            }
            notification.IsAccepted = request.IsAccepted;
            notification.IsRead = true;
            notification.IsActioned = true;
            _unitOfWork.Notifications.Update(notification);

            var profileShare = await _unitOfWork.ProfileShares.QueryableAsync()
                .FirstOrDefaultAsync(p => 
                    p.PatientProfileId == notification.ObjectId && 
                    p.SharedByUserId == notification.SenderId && 
                    p.SharedToUserId == notification.ReceiverId && 
                    p.ShareStatus == EnumShareStatus.Pending, 
                    cancellationToken);
            if (profileShare == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(notification.ObjectId), notification.ObjectId);
                return methodResult;
            }
            profileShare.ShareStatus = request.IsAccepted ? EnumShareStatus.Accepted : EnumShareStatus.Rejected;
            _unitOfWork.ProfileShares.Update(profileShare);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (request.IsAccepted)
            {
                var fullName = await GetResponderName(_unitOfWork, notification.ReceiverId, cancellationToken) ?? "Người nhận";
                var profile = await _unitOfWork.PatientProfiles.GetByIdAsync(notification.ObjectId ?? Guid.NewGuid());
                if (profile == null)
                {
                    methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(notification.ObjectId), notification.ObjectId);
                    return methodResult;
                }
                var messageParams = new List<object>
                {
                    fullName,
                    profile.ProfileCode!
                };
                await SendNotificationAsync(_notificationService, null, notification.ReceiverId, (Guid)notification.SenderId!, messageParams, request.IsAccepted);
            }

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }

        private static async Task SendNotificationAsync(INotificationRealTimeService notificationService, Guid? patientProfileId, Guid senderId, Guid receiverId, List<object> messageParams, bool isAccepted)
        {
            await notificationService.SendNotificationAsync(
                receiverId: receiverId,
                senderId: senderId,
                patientProfileId: patientProfileId,
                content: isAccepted ? EnumNotificationContent.ShareProfileAccepted : EnumNotificationContent.ShareProfileRejected,
                type: isAccepted ? EnumNotificationType.ShareProfileAccepted : EnumNotificationType.ShareProfileRejected,
                objectId: null,
                messageParams: messageParams,
                cancellationToken: CancellationToken.None
            );
        }

        private static async Task<string?> GetResponderName(IUnitOfWork unitOfWork, Guid userId, CancellationToken cancellationToken)
        {
            var patient = await unitOfWork.Patients.QueryableAsync()
                .FirstOrDefaultAsync(p => p.UserId == userId, cancellationToken);
            if (patient == null)
            {
                return null;
            }
            var patientProfile = await unitOfWork.PatientProfiles.QueryableAsync()
                .FirstOrDefaultAsync(pp => pp.PatientId == patient.Id && pp.Relationship == EnumRelationship.MySelf, cancellationToken);
            if (patientProfile == null)
            {
                return null;
            }
            return patientProfile.FullName;
        }
    }
}