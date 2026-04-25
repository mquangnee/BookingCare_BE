using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.EntityModels
{
    public class ReceptionistModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? ReceptionistCode { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AvatarUrl { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EnumGender Gender { get; set; }
        public string? CitizenId { get; set; }
        public EnumStatus Status { get; set; }
    }
}