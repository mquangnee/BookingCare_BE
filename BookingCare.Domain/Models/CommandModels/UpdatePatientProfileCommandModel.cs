using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.CommandModels
{
    public class UpdatePatientProfileCommandModel
    {
        public string? ProfileCode { get; set; }
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public EnumGender? Gender { get; set; }
        public string? CitizenId { get; set; }
        public string? PhoneNumber { get; set; }
        public EnumRelationship? Relationship { get; set; }
        public EnumBloodType? BloodType { get; set; }
        public string? MedicalHistory { get; set; }
    }
}
