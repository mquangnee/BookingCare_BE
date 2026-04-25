using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.EntityModels
{
    public class DoctorModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ServiceId { get; set; }
        public Guid SpecialtyId { get; set; }
        public string? SpecialtyName { get; set; }
        public string? DoctorCode { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AvatarUrl { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EnumGender Gender { get; set; }
        public string? CitizenId { get; set; }
        public int ExperienceYears { get; set; }
        public EnumPosition Position { get; set; }
        public string? WorkingHistory { get; set; }
        public string? Description { get; set; }
        public EnumStatus Status { get; set; }
        public double? Price { get; set; }
        public DateTime? StartTime { get; set; }
    }
}
