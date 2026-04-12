using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.CommandModels
{
    public class UpdateMedicineCommandModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public EnumMedicineUnit Unit { get; set; }
        public string? Function { get; set; }
    }
}
