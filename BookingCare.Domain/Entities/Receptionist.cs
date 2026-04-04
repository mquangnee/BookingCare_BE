using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Entities
{
    public class Receptionist
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? ReceptionistCode { get; set; }
        public string? AvatarUrl { get; set; }

        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EnumGender Gender { get; set; }
        public string? CitizenId { get; set; }

        // Relationships
        public User? User { get; set; }
    }
}
