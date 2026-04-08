using BookingCare.Shared.Enum;
using Microsoft.AspNetCore.Http;

namespace BookingCare.Domain.Models.CommandModels
{
    public class CreateDoctorAccountCommandModel
    {
        public IFormFile? Avatar { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? CitizenId { get; set; }
        public EnumGender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid SpecialtyId { get; set; }
        public EnumPosition Position { get; set; }
        public string? PhoneNumber { get; set; }
        public int ExperienceYears { get; set; }
        public string? WorkingHistory { get; set; }
        public string? Description { get; set; }
    }
}
