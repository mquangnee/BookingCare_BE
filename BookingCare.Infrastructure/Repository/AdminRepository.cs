using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Infrastructure.Repository
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
