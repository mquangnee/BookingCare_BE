using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.EntityModels
{
    public class UserProfileModel
    {
        public string? PatientCode { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EnumGender Gender { get; set; }
        public string? CitizenId { get; set; }
        public string? PhoneNumber { get; set; }
        public EnumRelationship Relationship { get; set; } = EnumRelationship.MySelf;
        public EnumBloodType BloodType { get; set; } = EnumBloodType.Unknown;
        public string? MedicalHistory { get; set; }
    }
}
