using BookingCare.Shared.Enum;
using Microsoft.AspNetCore.Http;

namespace BookingCare.Domain.Models.CommandModels
{
    public class UpdateDoctorProfileCommandModel
    {
        public IFormFile? Avatar { get; set; }
        public Guid DoctorId { get; set; }
        public Guid ServiceId { get; set; }
        public Guid SpecialtyId { get; set; }
        public EnumPosition Position { get; set; }
        public string? PhoneNumber { get; set; }
        public int ExperienceYears { get; set; }
        public string? Description { get; set; }
        public string? WorkingHistory { get; set; }
    }
}
