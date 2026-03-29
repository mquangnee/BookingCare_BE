namespace BookingCare.Domain.Entities
{
    public class WorkSessionService
    {
        public Guid Id { get; set; }
        public Guid WorkSessionId { get; set; }
        public WorkSession? WorkSession { get; set; }
        public Guid ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}
    