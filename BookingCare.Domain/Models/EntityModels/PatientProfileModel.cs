using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.EntityModels
{
    public class PatientProfileModel
    {
        public Guid Id { get; set; }
        public string? PatientCode { get; set; }
        public string? ProfileCode { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EnumGender Gender { get; set; }
        public string? CitizenId { get; set; }
        public string? PhoneNumber { get; set; }
        public EnumRelationship? Relationship { get; set; }
        public EnumBloodType? BloodType { get; set; }
        public string? MedicalHistory { get; set; }
        public bool? IsShared { get; set; } = false;
        public EnumSharePermission? SharePermission { get; set; }
    }
}
