using BookingCare.Domain.Entities;
using BookingCare.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Services
{
    public interface IGeneratorCodeService
    {
        Task<string> GeneratePatientCodeAsync();
        Task<string> GenerateDoctorCodeAsync();
        Task<string> GenerateReceptionistCodeAsync();
        Task<string> GeneratePatientProfileCodeAsync();
    }

    public class GeneratorCodeService : IGeneratorCodeService
    {
        private readonly DataContext _dbContext;

        public GeneratorCodeService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GeneratePatientCodeAsync()
        {
            var currentMonth = DateTime.Now.ToString("yyMM");
            var prefix = $"BN-{currentMonth}-";
            var lastPatient = await _dbContext.Set<Patient>()
                .Where(p => p.PatientCode != null && p.PatientCode.StartsWith(prefix))
                .OrderByDescending(p => p.PatientCode)
                .FirstOrDefaultAsync();

            return GenerateNextCode(lastPatient?.PatientCode, prefix);
        }

        public async Task<string> GenerateDoctorCodeAsync()
        {
            var currentMonth = DateTime.Now.ToString("yyMM");
            var prefix = $"BS-{currentMonth}-";
            var lastDoctor = await _dbContext.Set<Doctor>()
                .Where(d => d.DoctorCode != null && d.DoctorCode.StartsWith(prefix))
                .OrderByDescending(d => d.DoctorCode)
                .FirstOrDefaultAsync();

            return GenerateNextCode(lastDoctor?.DoctorCode, prefix);
        }

        public async Task<string> GenerateReceptionistCodeAsync()
        {
            var currentMonth = DateTime.Now.ToString("yyMM");
            var prefix = $"LT-{currentMonth}-";
            var lastReceptionist = await _dbContext.Set<Receptionist>()
                .Where(r => r.ReceptionistCode != null && r.ReceptionistCode.StartsWith(prefix))
                .OrderByDescending(r => r.ReceptionistCode)
                .FirstOrDefaultAsync();

            return GenerateNextCode(lastReceptionist?.ReceptionistCode, prefix);
        }

        public async Task<string> GeneratePatientProfileCodeAsync()
        {
            var currentMonth = DateTime.Now.ToString("yyMM");
            var prefix = $"HS-{currentMonth}-";
            var lastProfile = await _dbContext.Set<PatientProfile>()
                .Where(p => p.ProfileCode != null && p.ProfileCode.StartsWith(prefix))
                .OrderByDescending(p => p.ProfileCode)
                .FirstOrDefaultAsync();

            return GenerateNextCode(lastProfile?.ProfileCode, prefix);
        }

        private string GenerateNextCode(string? lastCode, string prefix)
        {
            if (string.IsNullOrEmpty(lastCode))
            {
                return $"{prefix}0001";
            }

            var lastNumberStr = lastCode.Substring(prefix.Length);
            if (int.TryParse(lastNumberStr, out int lastNumber))
            {
                return $"{prefix}{(lastNumber + 1).ToString("D4")}";
            }
            return $"{prefix}0001";
        }
    }
}
