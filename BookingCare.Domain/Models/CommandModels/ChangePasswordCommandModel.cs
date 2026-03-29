namespace BookingCare.Domain.Models.CommandModels
{
    public class ChangePasswordCommandModel
    {
        public string? Otp { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
