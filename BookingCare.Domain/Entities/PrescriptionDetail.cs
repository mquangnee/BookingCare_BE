namespace BookingCare.Domain.Entities
{
    public class PrescriptionDetail
    {
        public Guid Id { get; set; }
        public Guid PrescriptionId { get; set; }
        public Guid MedicineId { get; set; }
        public string? Dosage { get; set; }
        public string? Usage { get; set; }
        
        public Prescription? Prescription { get; set; }
        public Medicine? Medicine { get; set; }
    }
}
