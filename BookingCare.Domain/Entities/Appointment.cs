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
        public Guid PrescriptionId { get; set; }
        public Guid ServiceId { get; set; }
        public EnumAppointmentType Type { get; set; }
        public EnumAppointmentStatus Status { get; set; }
        public EnumAppointmentPriority Priority { get; set; } = EnumAppointmentPriority.Level0;
        public DateTime Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public DateTime CheckInDate { get; set; }
        public string? Note { get; set; }
        public double ServicePrice { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public User? Booker { get; set; }
        public WorkSession? WorkSession { get; set; }
        public PatientProfile? PatientProfile { get; set; }
        public Prescription? Prescription { get; set; }
        public Service? Service { get; set; }
    }
}