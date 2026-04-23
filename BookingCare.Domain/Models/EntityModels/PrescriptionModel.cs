namespace BookingCare.Domain.Models.EntityModels
{
    public class PrescriptionModel
    {
        public Guid AppointmentId { get; set; }
        public Guid PrescriptionId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Instructions { get; set; }
        public List<PrescriptionDetailModel>? PrescriptionDetails { get; set; }
    }
}
