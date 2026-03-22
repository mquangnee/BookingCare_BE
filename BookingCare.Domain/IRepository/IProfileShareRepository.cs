using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface IProfileShareRepository : IRepository<ProfileShare>
    {
    }

    public class ProfileShareRepository : Repository<ProfileShare>, IProfileShareRepository
    {
        public ProfileShareRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
