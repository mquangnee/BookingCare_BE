using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Entities
{
    public class ProfileShare
    {
        public Guid Id { get; set; }
        public Guid PatientProfileId { get; set; }
        public Guid SharedByUserId { get; set; }
        public Guid SharedToUserId { get; set; }
        public EnumShareStatus ShareStatus { get; set; } = EnumShareStatus.Pending;
        public EnumSharePermission SharePermission { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        // Relationships
        public PatientProfile? PatientProfile { get; set; }
        public User? SharedByUser { get; set; }
        public User? SharedToUser { get; set; }
    }
}
