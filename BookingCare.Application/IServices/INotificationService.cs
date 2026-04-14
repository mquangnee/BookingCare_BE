using BookingCare.Shared.Enum;

namespace BookingCare.Application.Services
{
    public interface INotificationService
    {
        Task SendNotificationAsync(Guid receiverId, Guid? senderId, Guid? patientProfileId, EnumNotificationContent content, EnumNotificationType type, Guid? objectId, List<object> messageParams, CancellationToken cancellationToken);
    }
}
