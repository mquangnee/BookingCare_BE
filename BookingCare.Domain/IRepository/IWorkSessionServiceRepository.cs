using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface IWorkSessionServiceRepository : IRepository<WorkSessionService>
    {
    }

    public class WorkSessionServiceRepository : Repository<WorkSessionService>, IWorkSessionServiceRepository
    {
        public WorkSessionServiceRepository(DbContext context) : base(context)
        {
        }
    }
}
