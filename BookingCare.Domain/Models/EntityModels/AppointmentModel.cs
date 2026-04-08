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
        public DateTime Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }
}
