using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepository Patients { get; }
        Task<int> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public IPatientRepository Patients { get; }

        public UnitOfWork(DbContext dbContext, IPatientRepository patientRepository)
        {
            _dbContext = dbContext;
            Patients = patientRepository;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
