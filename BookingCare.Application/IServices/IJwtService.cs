using BookingCare.Domain.Entities;

namespace BookingCare.Application.Services
{
    public interface IJwtService
    {
        Task<string> GenerateAccessToken(User user);
        string GenerateRefreshToken();
    }
}
