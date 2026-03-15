using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<Patient?> GetByCitizenIdAsync(string citizenId);
    }

    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Patient?> GetByCitizenIdAsync(string citizenId)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.CitizenId == citizenId);
        }
    }
}
