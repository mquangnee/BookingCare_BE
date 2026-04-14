using BookingCare.Application.Services;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Setting;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace BookingCare.Infrastructure.Services
{
    public class SenderService : ISenderService
    {
        private readonly SmtpSetting _smtpSetting;

        public SenderService(IOptions<SmtpSetting> smtpOptions)
        {
            _smtpSetting = smtpOptions.Value;
        }

        public async Task SendDailySummaryAsync(DailySummaryEmailModel model)
        {
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "Email", $"{EnumSenderTemplate.DailySummary.ToString()}.html");
            if (!File.Exists(templatePath))
                throw new FileNotFoundException($"Template not found: {templatePath}");

            string htmlBody = await File.ReadAllTextAsync(templatePath);

            var rows = string.Join("", model.Appointments?.Select((a, i) => $"""
                <div style="border:1px solid #E5E7EB; border-radius:10px; margin-bottom:16px; overflow:hidden;">
                    <div style="background-color:#F9FAFB; padding:10px 18px; border-bottom:1px solid #E5E7EB;">
                        <table cellpadding="0" cellspacing="0" style="border-collapse:collapse;">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" style="border-collapse:collapse;">
                                        <tr>
                                            <td style="width:22px; height:22px; background-color:#45C3D2; border-radius:50%; text-align:center; vertical-align:middle; font-size:12px; font-weight:700; color:#ffffff;">
                                                {i + 1}
                                            </td>
                                            <td style="padding-left:8px; font-size:14px; font-weight:700; color:#111827; vertical-align:middle;">
                                                {a.StartTime?.ToString(@"hh\:mm")} - {a.EndTime?.ToString(@"hh\:mm")}
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="padding:14px 18px;">
                        <table cellpadding="0" cellspacing="0" style="width:100%; border-collapse:collapse;">
                            <tr style="margin-bottom:8px;">
                                <td style="width:120px; color:#9CA3AF; font-size:13px; padding-bottom:8px;">Bệnh nhân</td>
                                <td style="color:#111827; font-weight:500; font-size:14px; padding-bottom:8px;">{a.PatientName}</td>
                            </tr>
                            <tr>
                                <td style="width:120px; color:#9CA3AF; font-size:13px; padding-bottom:8px;">Bác sĩ</td>
                                <td style="color:#111827; font-weight:500; font-size:14px; padding-bottom:8px;">{a.DoctorName}</td>
                            </tr>
                            <tr>
                                <td style="width:120px; color:#9CA3AF; font-size:13px;">Ngày khám</td>
                                <td style="color:#111827; font-weight:500; font-size:14px;">{a.Date}</td>
                            </tr>
                        </table>
                    </div>
                </div>
            """) ?? []);

            var templateData = new Dictionary<string, string>
            {
                { EmailConstants.Keys.BookerName, model.BookerName!},
                { EmailConstants.Keys.Date, model.Date.ToString("dd/MM/yyyy") },
                { EmailConstants.Keys.AppointmentCount, (model.Appointments?.Count ?? 0).ToString() },
                { EmailConstants.Keys.AppointmentRows,  rows }
            };

            foreach (var data in templateData)
            {
                htmlBody = htmlBody.Replace("{{" + data.Key + "}}", data.Value);
            }

            using var smtpClient = new SmtpClient(_smtpSetting.Host, _smtpSetting.Port)
            {
                Credentials = new NetworkCredential(_smtpSetting.From, _smtpSetting.Password),
                EnableSsl = true
            };

            var subject = EmailConstants.Subjects.DailySummary.Replace("{{Date}}", model.Date.ToString("dd/MM/yyyy"));

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSetting.From!),
                Subject = subject,
                Body = htmlBody,
                IsBodyHtml = true
            };
            mailMessage.To.Add(model.ToEmail!);

            await smtpClient.SendMailAsync(mailMessage);
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
