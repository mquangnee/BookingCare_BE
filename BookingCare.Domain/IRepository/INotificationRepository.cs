using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface INotificationRepository : IRepository<Notification>
    {
    }

    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
