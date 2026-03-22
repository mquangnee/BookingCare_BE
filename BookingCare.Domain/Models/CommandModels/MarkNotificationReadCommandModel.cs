namespace BookingCare.Domain.Models.CommandModels
{
    public class MarkNotificationReadCommandModel
    {
        public Guid NotificationId { get; set; }
        public bool IsRead { get; set; }
    }
}
