using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.CommandModels
{
    public class ChangeStatusAccountCommandModel
    {
        public Guid UserId { get; set; }
        public EnumAccountStatus NewStatus { get; set; }
    }
}
