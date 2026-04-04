using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public Guid ReceiverId { get; set; } // Người nhận
        public Guid? SenderId { get; set; } // Người gửi
        public Guid? NotificationTypeId { get; set; }
        public Guid? ObjectId { get; set; }

        public string? Message { get; set; }
        public EnumNotificationType Type { get; set; }
        public bool IsRead { get; set; } = false;
        public bool IsAccepted { get; set; } = false;
        public bool IsActioned { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Relationships
        public User? Receiver { get; set; }
        public User? Sender { get; set; }
        public NotificationType? NotificationType { get; set; }
    }
}
