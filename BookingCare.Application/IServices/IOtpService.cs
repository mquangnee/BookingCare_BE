namespace BookingCare.Application.Services
{
    public interface IOtpService
    {
        void SetOtp(string email);
        string GetOtp(string email);
        void RemoveOtp(string email);
    }
}
