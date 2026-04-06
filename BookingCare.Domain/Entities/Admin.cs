namespace BookingCare.Domain.Entities
{
    public class Admin
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? AdminCode { get; set; }
        public string? FullName { get; set; }
        public bool IsActive { get; set; } = true;
        public User? User { get; set; }
    }
}
