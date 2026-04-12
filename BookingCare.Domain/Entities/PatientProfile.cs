using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Entities
{
    public class PatientProfile
    {
        public Guid Id { get; set; }
        public string? ProfileCode { get; set; }
        public Guid? PatientId { get; set; }

        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EnumGender Gender { get; set; }
        public string? CitizenId { get; set; }
        public string? PhoneNumber { get; set; }
        public EnumRelationship Relationship { get; set; } = EnumRelationship.MySelf;
        public EnumBloodType BloodType { get; set; } = EnumBloodType.Unknown;
        public string? MedicalHistory { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        // Relationships
        public Patient? Patient { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<ProfileShare>? SharedProfiles { get; set; }
    }
}
