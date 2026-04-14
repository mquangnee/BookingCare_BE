using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Infrastructure.Repository
{
    public class WorkSessionRepository : Repository<WorkSession>, IWorkSessionRepository
    {
        public WorkSessionRepository(DbContext context) : base(context)
        {
        }
    }
}
