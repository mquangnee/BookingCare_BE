using BookingCare.Domain.Entities;
using BookingCare.Shared.Enum;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface INotificationTypeRepository : IRepository<NotificationType>
    {
        Task<NotificationType?> GetByContentAsync(EnumNotificationContent content);
    }

    public class NotificationTypeRepository : Repository<NotificationType>, INotificationTypeRepository
    {
        public NotificationTypeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<NotificationType?> GetByContentAsync(EnumNotificationContent content)
        {
            return await _dbContext.Set<NotificationType>().FirstOrDefaultAsync(n => n.Content == content);
        }
    }
}
