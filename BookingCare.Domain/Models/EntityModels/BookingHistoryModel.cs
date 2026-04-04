using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.EntityModels
{
    public class BookingHistoryModel
    {
        public Guid Id { get; set; }
        public string? AppointmentCode { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? QueueNumber { get; set; }
        public EnumAppointmentStatus Status { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorCode { get; set; }
        public Guid DoctorId { get; set; }
        public string? SpecialtyName { get; set; }
        public string? PatientProfileName { get; set; }
        public string? PatientProfileCode { get; set; }
        public Guid PatientProfileId { get; set; }
        public List<string> Services { get; set; } = new();
        public DateTime CreatedDate { get; set; }
    }
}
