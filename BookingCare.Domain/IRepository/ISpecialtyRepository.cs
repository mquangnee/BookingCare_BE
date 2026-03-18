using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface ISpecialtyRepository : IRepository<Specialty>
    {
    }

    public class SpecialtyRepository : Repository<Specialty>, ISpecialtyRepository
    {
        public SpecialtyRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}