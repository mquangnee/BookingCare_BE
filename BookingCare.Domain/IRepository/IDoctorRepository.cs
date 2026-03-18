using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
    }

    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
