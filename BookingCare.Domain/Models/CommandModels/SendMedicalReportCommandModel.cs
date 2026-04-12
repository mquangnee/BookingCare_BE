using BookingCare.Domain.Models.EntityModels;

namespace BookingCare.Domain.Models.CommandModels
{
    public class SendMedicalReportCommandModel
    {
        public Guid AppointmentId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Instructions { get; set; }
        public List<PrescriptionDetailModel>? PrescriptionDetails { get; set; }
    }
}
