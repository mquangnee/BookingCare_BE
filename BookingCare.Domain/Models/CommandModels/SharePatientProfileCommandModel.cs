using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.CommandModels
{
    public class SharePatientProfileCommandModel
    {
        public Guid ProfileId { get; set; }
        public string? Email { get; set; }
        public EnumSharePermission Permission { get; set; }
    }
}
