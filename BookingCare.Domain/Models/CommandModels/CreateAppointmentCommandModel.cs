using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.CommandModels
{
    public class CreateAppointmentCommandModel
    {
        public Guid PatientProfileId { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid? ServiceId { get; set; }
        public EnumAppointmentType Type { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
