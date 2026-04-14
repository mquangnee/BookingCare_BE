namespace BookingCare.Domain.Entities
{
    public class Prescription
    {
        public Guid Id { get; set; }
        public Guid AppointmentId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Instructions { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public Appointment? Appointment { get; set; }
        public ICollection<PrescriptionDetail>? PrescriptionDetails { get; set; }
    }
}
