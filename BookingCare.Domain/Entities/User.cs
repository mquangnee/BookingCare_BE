using BookingCare.Shared.Enum;
using Microsoft.AspNetCore.Identity;

namespace BookingCare.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        /// <summary>
        /// Thông tin cá nhân
        /// </summary>
        public string? FullName { get; set; }
        public EnumGender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? CitizenId { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public string? RefreshToken { get; set; }
        public DateTime TokenExpiry { get; set; }
        public bool IsRefreshTokenValid(string token)
        {
            return RefreshToken == token && TokenExpiry > DateTime.Now;
        }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
