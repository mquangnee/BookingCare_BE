using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using Microsoft.EntityFrameworkCore;


namespace BookingCare.Infrastructure.Repository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(DbContext context) : base(context)
        {
        }
    }
}
