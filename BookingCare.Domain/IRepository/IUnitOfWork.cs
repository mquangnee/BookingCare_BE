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
        IProfileShareRepository ProfileShares { get; }
        INotificationRepository Notifications { get; }
        INotificationTypeRepository NotificationTypes { get; }
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
        public IProfileShareRepository ProfileShares { get; }
        public INotificationRepository Notifications { get; }
        public INotificationTypeRepository NotificationTypes { get; }

        public UnitOfWork(
            DbContext dbContext, 
            IPatientRepository patients, 
            IPatientProfileRepository patientProfiles, 
            IDoctorRepository doctors, 
            IReceptionistRepository receptionists, 
            ISpecialtyRepository specialties,
            IProfileShareRepository profileShares,
            INotificationRepository notifications,
            INotificationTypeRepository notificationTypes)
        {
            _dbContext = dbContext;
            Patients = patients;
            PatientProfiles = patientProfiles;
            Doctors = doctors;
            Receptionists = receptionists;
            Specialties = specialties;
            ProfileShares = profileShares;
            Notifications = notifications;
            NotificationTypes = notificationTypes;
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
