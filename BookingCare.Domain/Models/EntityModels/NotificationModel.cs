using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.EntityModels
{
    public class NotificationModel
    {
        public Guid NotificationId { get; set; }
        public Guid ReceiverId { get; set; } // Người nhận
        public Guid? SenderId { get; set; } // Người gửi
        public Guid? ShareProfileId { get; set; }

        public string? Message { get; set; }
        public EnumNotificationType Type { get; set; }
        public Guid? ObjectId { get; set; }
        public bool IsRead { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsActioned { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
