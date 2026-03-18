using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepository Patients { get; }
        IPatientProfileRepository PatientProfiles { get; }
        IDoctorRepository Doctors { get; }
        IReceptionistRepository Receptionists { get; }
        ISpecialtyRepository Specialties { get; }
        Task<int> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public IPatientRepository Patients { get; }
        public IPatientProfileRepository PatientProfiles { get; }
        public IDoctorRepository Doctors { get; }
        public IReceptionistRepository Receptionists { get; }
        public ISpecialtyRepository Specialties { get; }

        public UnitOfWork(DbContext dbContext, IPatientRepository patientRepository, IPatientProfileRepository patientProfiles, IDoctorRepository doctors, IReceptionistRepository receptionists, ISpecialtyRepository specialties)
        {
            _dbContext = dbContext;
            Patients = patientRepository;
            PatientProfiles = patientProfiles;
            Doctors = doctors;
            Receptionists = receptionists;
            Specialties = specialties;
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
