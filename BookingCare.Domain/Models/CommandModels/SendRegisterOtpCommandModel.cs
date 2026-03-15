namespace BookingCare.Domain.Models.CommandModels
{
    public class SendRegisterOtpCommandModel
    {
        public string? Email { get; set; }
        public string? FullName { get; set; }
    }
}
