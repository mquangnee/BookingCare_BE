using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Entities
{
    public class NotificationType
    {
        public Guid Id { get; set; }
        public EnumNotificationContent Content { get; set; }
        public string? TemplateMessage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
