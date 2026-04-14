using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.EntityModels
{
    public class BookingHistoryModel
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientProfileId { get; set; }
        public Guid ServiceId { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorCode { get; set; }
        public string? SpecialtyName { get; set; }
        public string? PatientProfileName { get; set; }
        public string? PatientProfileCode { get; set; }
        public string? ServiceName { get; set; }
        public string? AppointmentCode { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public EnumAppointmentStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
