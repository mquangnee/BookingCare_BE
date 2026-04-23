using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.EntityModels
{
    public class PrescriptionDetailModel
    {
        public Guid Id { get; set; }
        public Guid PrescriptionId { get; set; }
        public Guid MedicineId { get; set; }
        public string? MedicineName { get; set; }
        public EnumMedicineUnit? MedicineUnit { get; set; }
        public string? Dosage { get; set; }
        public string? Usage { get; set; }
    }
}
