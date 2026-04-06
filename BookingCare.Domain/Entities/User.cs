using Microsoft.AspNetCore.Identity;

namespace BookingCare.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string? RefreshToken { get; set; }
        public DateTime TokenExpiry { get; set; }
        public bool IsRefreshTokenValid(string token)
        {
            return RefreshToken == token && TokenExpiry > DateTime.Now;
        }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public Receptionist? Receptionist { get; set; }
        public Admin? Admin { get; set; }
    }
}
