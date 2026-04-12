using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.QueryModels
{
    public class GetBookingHistoryQueryModel
    {
        public EnumAppointmentStatus? Status { get; set; }
        public string? DoctorName { get; set; }
        public string? PatientProfileName { get; set; }
    }
}
