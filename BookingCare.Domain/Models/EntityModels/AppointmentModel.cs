using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.EntityModels
{
    public class AppointmentModel
    {
        public Guid Id { get; set; }
        public string? AppointmentCode { get; set; }
        public Guid BookerId { get; set; }
        public Guid WorkSessionId { get; set; }
        public string? DoctorName { get; set; }
        public Guid PatientProfileId { get; set; }
        public string? PatientName { get; set; }
        public int? Age { get; set; }
        public EnumGender? Gender { get; set; }
        public EnumAppointmentType? Type { get; set; }
        public EnumAppointmentStatus Status { get; set; }
        public EnumAppointmentPriority? Priority { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public DateTime? CheckInDate { get; set; }
    }
}
