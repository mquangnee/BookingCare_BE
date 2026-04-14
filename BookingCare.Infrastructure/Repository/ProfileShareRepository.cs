using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Infrastructure.Repository
{
    public class ProfileShareRepository : Repository<ProfileShare>, IProfileShareRepository
    {
        public ProfileShareRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
