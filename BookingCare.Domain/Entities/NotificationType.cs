using BookingCare.Shared.Enum;
using System.Text.Json.Serialization;

namespace BookingCare.Domain.Entities
{
    public class NotificationType
    {
        public Guid Id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnumNotificationContent Content { get; set; }
        public string? TemplateMessage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
