using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface IWorkSessionRepository : IRepository<WorkSession>
    {
    }

    public class WorkSessionRepository : Repository<WorkSession>, IWorkSessionRepository
    {
        public WorkSessionRepository(DbContext context) : base(context)
        {
        }
    }
}
