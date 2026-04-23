namespace BookingCare.Domain.Entities
{
    public class ChatSession
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public User? User { get; set; }
        public ICollection<ChatMessage>? ChatMessages { get; set; }
    }
}
