using BookingCare.Shared.Enum;
using Microsoft.AspNetCore.Http;

namespace BookingCare.Domain.Models.CommandModels
{
    public class UpdateReceptionistProfileCommandModel
    {
        public Guid ReceptionistId { get; set; }
        public IFormFile? Avatar { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EnumGender Gender { get; set; }
        public string? PhoneNumber { get; set; }
    }
}