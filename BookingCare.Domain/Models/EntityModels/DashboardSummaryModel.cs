namespace BookingCare.Domain.Models.EntityModels
{
    public class DashboardSummaryModel
    {
        public DashboardMetricModel<AppointmentModel>? Appointments { get; set; }
        public DashboardMetricModel<DoctorModel>? Doctors { get; set; }
        public DashboardMetricModel<PatientModel>? Patients { get; set; }
        public DashboardMetricModel<ServiceModel>? Services { get; set; }
    }

    public class DashboardMetricModel<T>
    {
        public IList<T>? Data { get; set; }
        public int Total { get; set; }
        public double? Balance { get; set; }
    }
}
