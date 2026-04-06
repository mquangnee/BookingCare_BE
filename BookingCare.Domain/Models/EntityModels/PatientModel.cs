using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.EntityModels
{
    public class PatientModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? PatientCode { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EnumGender Gender { get; set; }
        public string? CitizenId { get; set; }
        public EnumBloodType BloodType { get; set; }
        public string? MedicalHistory { get; set; }
    }
}
