using BookingCare.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookingCare.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private IDbContextTransaction? _currentTransaction;
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
        public IChatMessageRepository ChatMessages { get; }
        public IChatSessionRepository ChatSessions { get; }

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
            IPaymentTransactionRepository paymentTransaction,
            IChatMessageRepository chatMessages,
            IChatSessionRepository chatSessions)
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
            ChatMessages = chatMessages;
            ChatSessions = chatSessions;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _currentTransaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

            return _currentTransaction;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction is null)
                throw new InvalidOperationException("Không có transaction nào đang mở.");

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
                await _currentTransaction.CommitAsync(cancellationToken);
            }
            finally
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction is null) return;

            try
            {
                await _currentTransaction.RollbackAsync(cancellationToken);
            }
            finally
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
    }
}
