namespace BookingCare.Domain.Models.EntityModels
{
    public class PrescriptionDetailModel
    {
        public Guid MedicineId { get; set; }
        public string? Dosage { get; set; }
        public string? Usage { get; set; }
    }
}
