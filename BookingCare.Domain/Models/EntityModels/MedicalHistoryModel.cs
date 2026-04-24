using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.EntityModels
{
    public class PrescriptionMedicineModel
    {
        public Guid MedicineId { get; set; }
        public string? MedicineName { get; set; }
        public EnumMedicineUnit? Unit { get; set; }
        public string? Dosage { get; set; }
        public string? UsageInstruction { get; set; }
    }

    public class MedicalHistoryModel
    {
        public Guid AppointmentId { get; set; }
        public Guid WorkSessionId { get; set; }
        public Guid PatientProfileId { get; set; }
        public string? AppointmentCode { get; set; }
        public string? ProfileCode { get; set; }
        public string? DoctorName { get; set; }
        public string? PatientName { get; set; }
        public int? Age { get; set; }
        public string? Diagnosis { get; set; }
        public EnumGender? Gender { get; set; }
        public EnumAppointmentType? Type { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        public List<PrescriptionMedicineModel>? Medicines { get; set; }
    }
}
