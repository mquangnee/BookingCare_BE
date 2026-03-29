using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface IServiceRepository : IRepository<Service>
    {
    }

    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(DbContext context) : base(context)
        {
        }
    }
}
