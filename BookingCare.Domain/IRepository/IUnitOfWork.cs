using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminRepository Admins { get; }
        IPatientRepository Patients { get; }
        IPatientProfileRepository PatientProfiles { get; }
        IDoctorRepository Doctors { get; }
        IReceptionistRepository Receptionists { get; }
        ISpecialtyRepository Specialties { get; }
        IProfileShareRepository ProfileShares { get; }
        INotificationRepository Notifications { get; }
        INotificationTypeRepository NotificationTypes { get; }
        IAppointmentRepository Appointments { get; }
        IServiceRepository Services { get; }
        IWorkSessionRepository WorkSessions { get; }
        IAppointmentServiceRepository AppointmentServices { get; }
        IMedicineRepository Medicines { get; }
        IPrescriptionRepository Prescriptions { get; }
        IPrescriptionDetailRepository PrescriptionDetails { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public IAdminRepository Admins { get; }
        public IPatientRepository Patients { get; }
        public IPatientProfileRepository PatientProfiles { get; }
        public IDoctorRepository Doctors { get; }
        public IReceptionistRepository Receptionists { get; }
        public ISpecialtyRepository Specialties { get; }
        public IProfileShareRepository ProfileShares { get; }
        public INotificationRepository Notifications { get; }
        public INotificationTypeRepository NotificationTypes { get; }
        public IAppointmentRepository Appointments { get; }
        public IServiceRepository Services { get; }
        public IWorkSessionRepository WorkSessions { get; }
        public IAppointmentServiceRepository AppointmentServices { get; }
        public IMedicineRepository Medicines { get; }
        public IPrescriptionRepository Prescriptions { get; }
        public IPrescriptionDetailRepository PrescriptionDetails { get; }

        public UnitOfWork(
            DbContext dbContext,
            IAdminRepository admins,
            IPatientRepository patients, 
            IPatientProfileRepository patientProfiles, 
            IDoctorRepository doctors, 
            IReceptionistRepository receptionists, 
            ISpecialtyRepository specialties,
            IProfileShareRepository profileShares,
            INotificationRepository notifications,
            INotificationTypeRepository notificationTypes,
            IAppointmentRepository appointments,
            IWorkSessionRepository workSessions,
            IServiceRepository services,
            IAppointmentServiceRepository appointmentServices,
            IMedicineRepository medicines,
            IPrescriptionRepository prescriptions,
            IPrescriptionDetailRepository prescriptionDetails)
        {
            _dbContext = dbContext;
            Admins = admins;
            Patients = patients;
            PatientProfiles = patientProfiles;
            Doctors = doctors;
            Receptionists = receptionists;
            Specialties = specialties;
            ProfileShares = profileShares;
            Notifications = notifications;
            NotificationTypes = notificationTypes;
            Appointments = appointments;
            WorkSessions = workSessions;
            Services = services;
            AppointmentServices = appointmentServices;
            Medicines = medicines;
            Prescriptions = prescriptions;
            PrescriptionDetails = prescriptionDetails;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
