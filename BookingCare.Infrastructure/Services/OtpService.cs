using BookingCare.Application.Services;
using Microsoft.Extensions.Caching.Memory;

namespace BookingCare.Infrastructure.Services
{
    public class OtpService : IOtpService
    {
        private readonly IMemoryCache _memoryCache;

        public OtpService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void SetOtp(string email)
        {
            var otp = new Random().Next(100000, 999999).ToString();
            _memoryCache.Set(email, otp, TimeSpan.FromMinutes(5));
        }

        public string GetOtp(string email)
        {
            return _memoryCache.Get<string>(email)!;
        }

        public void RemoveOtp(string email)
        {
            _memoryCache.Remove(email);
        }
    }
}
