namespace BookingCare.Application.Services
{
    public interface IGeneratorCodeService
    {
        Task<string> GeneratePatientCodeAsync();
        Task<string> GenerateDoctorCodeAsync();
        Task<string> GenerateReceptionistCodeAsync();
        Task<string> GeneratePatientProfileCodeAsync();
        Task<string> GenerateAppointmentCodeAsync();
    }
}
