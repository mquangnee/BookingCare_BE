using AutoMapper;
using BookingCare.Application.Services;
using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Commands.NotificationCmd
{
    public class RespondNotificationCommand : RespondNotificationCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class RespondNotificationCommandHandler : IRequestHandler<RespondNotificationCommand, MethodResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;

        public RespondNotificationCommandHandler(IUnitOfWork unitOfWork, INotificationService notificationService)
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
                .FirstOrDefaultAsync(p => p.ProfileId == notification.ObjectId && p.SharedToUserId == notification.ReceiverId, cancellationToken);
            if (profileShare == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(notification.ObjectId), notification.ObjectId);
                return methodResult;
            }
            profileShare.ShareStatus = request.IsAccepted ? EnumShareStatus.Accepted : EnumShareStatus.Rejected;
            _unitOfWork.ProfileShares.Update(profileShare);
            await _unitOfWork.SaveChangesAsync();

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
            await SendNotificationAsync(_notificationService, notification.ReceiverId, (Guid)notification.SenderId!, messageParams);

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }

        private static async Task SendNotificationAsync(INotificationService notificationService, Guid senderId, Guid receiverId, List<object> messageParams)
        {
            await notificationService.SendNotificationAsync(
                receiverId: receiverId,
                senderId: senderId,
                content: EnumNotificationContent.ShareProfileAccepted,
                type: EnumNotificationType.ShareProfileAccepted,
                objectId: null,
                messageParams: messageParams
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