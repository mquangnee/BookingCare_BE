namespace BookingCare.Domain.Models.EntityModels
{
    public class DailySummaryEmailModel
    {
        public string? ToEmail { get; set; }
        public string? BookerName { get; set; }
        public DateTime Date { get; set; }
        public List<AppointmentSummaryModel>? Appointments { get; set; }
    }

    public class AppointmentSummaryModel
    {
        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }
        public string? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }
}
