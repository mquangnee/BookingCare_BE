using Microsoft.EntityFrameworkCore.Storage;

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
        IMedicineRepository Medicines { get; }
        IPrescriptionRepository Prescriptions { get; }
        IPrescriptionDetailRepository PrescriptionDetails { get; }
        IPaymentRepository Payments { get; }
        IPaymentTransactionRepository PaymentsTransactions { get; }
        IChatMessageRepository ChatMessages { get; }
        IChatSessionRepository ChatSessions { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}
