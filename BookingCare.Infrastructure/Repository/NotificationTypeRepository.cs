using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Shared.Enum;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Infrastructure.Repository
{
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
