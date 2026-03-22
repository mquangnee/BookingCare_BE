using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.EntityModels
{
    public class ProfileShareModel
    {
        public Guid Id { get; set; }
        public Guid ProfileId { get; set; }

        public Guid SharedByUserId { get; set; }
        public Guid SharedToUserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public EnumShareStatus ShareStatus { get; set; }
        public EnumSharePermission SharePermission { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
