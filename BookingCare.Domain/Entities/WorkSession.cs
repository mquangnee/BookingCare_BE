namespace BookingCare.Domain.Entities
{
    public class WorkSession
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime NextAvailableAt { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public Guid DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public ICollection<WorkSessionService>? WorkSessionServices { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
