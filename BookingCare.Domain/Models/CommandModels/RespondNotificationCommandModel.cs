namespace BookingCare.Domain.Models.CommandModels
{
    public class RespondNotificationCommandModel
    {
        public Guid NotificationId { get; set; }
        public bool IsAccepted { get; set; }
    }
}
