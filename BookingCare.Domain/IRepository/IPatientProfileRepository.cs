using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface IPatientProfileRepository : IRepository<PatientProfile>
    {
    }

    public class PatientProfileRepository : Repository<PatientProfile>, IPatientProfileRepository
    {
        public PatientProfileRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}