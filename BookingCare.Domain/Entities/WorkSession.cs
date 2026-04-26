namespace BookingCare.Domain.Entities
{
    public class WorkSession
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public Doctor? Doctor { get; set; }
        public Service? Service { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
