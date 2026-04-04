using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string? AppointmentCode { get; set; }
        public Guid BookerId { get; set; }
        public Guid WorkSessionId { get; set; }
        public Guid PatientProfileId { get; set; }

        public EnumAppointmentStatus Status { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? QueueNumber { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Relationships
        public User? Booker { get; set; }
        public WorkSession? WorkSession { get; set; }
        public PatientProfile? PatientProfile { get; set; }
        public ICollection<AppointmentService>? AppointmentServices { get; set; }
    }
}
