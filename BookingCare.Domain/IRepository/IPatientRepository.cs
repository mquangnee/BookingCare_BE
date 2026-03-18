using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface IPatientRepository : IRepository<Patient>
    {
    }

    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
