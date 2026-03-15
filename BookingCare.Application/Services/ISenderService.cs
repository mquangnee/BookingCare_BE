using BookingCare.Shared.Setting;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace BookingCare.Application.Services
{
    public interface ISenderService
    {
        Task SendEmailAsync(string to, string subject, string templateName, Dictionary<string, string> templateData);
    }

    public class SenderService : ISenderService
    {
        private readonly SmtpSetting _smtpSetting;

        public SenderService(IOptions<SmtpSetting> smtpOptions)
        {
            _smtpSetting = smtpOptions.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string templateName, Dictionary<string, string> templateData)
        {
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "Email", $"{templateName}.html");
            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException($"The template file {templatePath} was not found.");
            }
            string htmlBody = await File.ReadAllTextAsync(templatePath);
            foreach (var data in templateData)
            {
                htmlBody = htmlBody.Replace("{{" + data.Key + "}}", data.Value);
            }
            using var smptClient = new SmtpClient(_smtpSetting.Host, _smtpSetting.Port)
            {
                Credentials = new NetworkCredential(_smtpSetting.From, _smtpSetting.Password),
                EnableSsl = true
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSetting.From!),
                Subject = subject,
                Body = htmlBody,
                IsBodyHtml = true
            };
            mailMessage.To.Add(to);
            await smptClient.SendMailAsync(mailMessage);
        }
    }
}
