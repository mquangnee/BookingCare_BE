using BookingCare.Domain.Models.EntityModels;

namespace BookingCare.Application.Services
{
    public interface ISenderService
    {
        Task SendEmailAsync(string to, string subject, string templateName, Dictionary<string, string> templateData);
        Task SendDailySummaryAsync(DailySummaryEmailModel model);
    }
}
