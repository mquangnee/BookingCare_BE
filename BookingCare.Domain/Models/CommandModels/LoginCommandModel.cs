namespace BookingCare.Domain.Models.CommandModels
{
    public class LoginCommandModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
