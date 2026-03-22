using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public Guid ReceiverId { get; set; } // Người nhận
        public Guid? SenderId { get; set; } // Người gửi

        public string? Message { get; set; }
        public EnumNotificationType Type { get; set; }
        public Guid? ObjectId { get; set; }
        public bool IsRead { get; set; } = false;
        public bool IsAccepted { get; set; } = false;
        public bool IsActioned { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
