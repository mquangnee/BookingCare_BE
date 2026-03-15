using BookingCare.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Services
{
    public interface IGeneratorCodeService
    {
        Task<string> GenerateAsync();
    }

    public class GeneratorCodeService : IGeneratorCodeService
    {
        private readonly DataContext _dbContext;

        public GeneratorCodeService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GenerateAsync()
        {
            var currentMonth = DateTime.Now.ToString("yyMM");
            var prefix = $"BN-{currentMonth}-";
            var lastPatient = await _dbContext.Patients
                .Where(p => p.PatientCode!.StartsWith(prefix))
                .OrderByDescending(p => p.PatientCode)
                .FirstOrDefaultAsync();
            if (lastPatient == null)
            {
                return $"{prefix}0001";
            }
            var lastCode = lastPatient.PatientCode;
            var lastNumberStr = lastCode!.Substring(prefix.Length);
            if (int.TryParse(lastNumberStr, out int lastNumber))
            {
                return $"{prefix}{(lastNumber + 1).ToString("D4")}";
            }
            return $"{prefix}0001";
        }
    }
}
