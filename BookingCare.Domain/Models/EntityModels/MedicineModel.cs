using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.EntityModels
{
    public class MedicineModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public EnumMedicineUnit Unit { get; set; }
        public string? Function { get; set; }
        public EnumStatus? Status { get; set; }
    }
}
