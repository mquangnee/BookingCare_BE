using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.CommandModels
{
    public class ChangeStatusMedicineCommandModel
    {
        public Guid MedicineId { get; set; }
        public EnumStatus NewStatus { get; set; }
    }
}
