using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Setting;
using BookingCare.Shared.SignalR;
using Microsoft.AspNetCore.SignalR;
using System.Globalization;

namespace BookingCare.Application.Services
{
    public interface INotificationService
    {
        Task SendNotificationAsync(Guid receiverId, Guid? senderId, Guid? patientProfileId, EnumNotificationContent content, EnumNotificationType type, Guid? objectId, List<object> messageParams);
    }

    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IUnitOfWork unitOfWork, IHubContext<NotificationHub> hubContext)
        {
            _unitOfWork = unitOfWork;
            _hubContext = hubContext;
        }

        public async Task SendNotificationAsync(Guid userId, Guid? senderId, Guid? patientProfileId, EnumNotificationContent content, EnumNotificationType type, Guid? objectId, List<object> messageParams)
        {
            var notificationType = await _unitOfWork.NotificationTypes.GetByContentAsync(content);
            if (notificationType == null)
            {
                throw new Exception($"Notification type with content '{content}' not found.");
            }
            var templateMessgae = notificationType.TemplateMessage;
            var messageNoti = messageParams != null ? string.Format(CultureInfo.InvariantCulture, templateMessgae ?? string.Empty, messageParams.ToArray()) : "";
            var notification = new Notification
            {
                ReceiverId = userId,
                SenderId = senderId,
                NotificationTypeId = notificationType.Id,
                Message = messageNoti,
                Type = type,
                ObjectId = objectId
            };
            await _unitOfWork.Notifications.AddAsync(notification);
            await _unitOfWork.SaveChangesAsync();
            var notificationModel = new NotificationModel
            {
                NotificationId = notification.Id,
                ReceiverId = notification.ReceiverId,
                SenderId = notification.SenderId,
                ShareProfileId = patientProfileId,
                Message = notification.Message,
                Type = notification.Type,
                ObjectId = notification.ObjectId,
                IsRead = notification.IsRead,
                IsAccepted = notification.IsAccepted,
                IsActioned = notification.IsActioned,
                CreatedDate = notification.CreatedDate
            };
            await _hubContext.Clients.User(userId.ToString()).SendAsync(RealTimeSetting.NotificationHub.Method.NotificationMessage, notificationModel);
        }
    }
}
