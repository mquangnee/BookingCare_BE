using BookingCare.Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Infrastructure.Repository
{
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
        public IMedicineRepository Medicines { get; }
        public IPrescriptionRepository Prescriptions { get; }
        public IPrescriptionDetailRepository PrescriptionDetails { get; }
        public IPaymentRepository Payments { get; }
        public IPaymentTransactionRepository PaymentsTransactions { get; }

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
            IMedicineRepository medicines,
            IPrescriptionRepository prescriptions,
            IPrescriptionDetailRepository prescriptionDetails,
            IPaymentRepository payment,
            IPaymentTransactionRepository paymentTransaction)
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
            Medicines = medicines;
            Prescriptions = prescriptions;
            PrescriptionDetails = prescriptionDetails;
            Payments = payment;
            PaymentsTransactions = paymentTransaction;
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
