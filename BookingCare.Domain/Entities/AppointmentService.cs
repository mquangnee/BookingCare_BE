namespace BookingCare.Domain.Entities
{
    public class AppointmentService
    {
        public Guid Id { get; set; }
        public Guid AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
        public Guid ServiceId { get; set; }
        public Service? Service { get; set; }
        public double PriceOverride { get; set; }
        public string? Note { get; set; }
    }
}
