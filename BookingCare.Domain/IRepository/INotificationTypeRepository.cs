using BookingCare.Domain.Entities;
using BookingCare.Shared.Enum;

namespace BookingCare.Domain.IRepository
{
    public interface INotificationTypeRepository : IRepository<NotificationType>
    {
        Task<NotificationType?> GetByContentAsync(EnumNotificationContent content);
    }
}
