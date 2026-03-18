namespace BookingCare.Domain.Models.CommandModels
{
    public class VerifyPasswordCommandModel
    {
        public string? Email { get; set; }
        public string? Otp { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmNewPassword { get; set; }
    }
}
