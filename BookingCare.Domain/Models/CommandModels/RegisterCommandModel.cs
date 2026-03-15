using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.CommandModels
{
    public class RegisterCommandModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Otp { get; set; }
        public string? FullName { get; set; }
        public EnumGender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Citizend { get; set; }
    }
}
