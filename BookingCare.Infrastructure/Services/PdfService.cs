using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Enum;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace BookingCare.Infrastructure.Services
{
    public class PdfService : IPdfService
    {
        private readonly IConverter _converter;

        public PdfService(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GeneratePrescriptionPdf(MedicalHistoryModel prescriptionDetails)
        {
            var medicineRows = string.Empty;
            if (prescriptionDetails.Medicines != null && prescriptionDetails.Medicines.Any())
            {
                int stt = 1;
                foreach (var med in prescriptionDetails.Medicines)
                {
                    string unitVN = med.Unit switch
                    {
                        EnumMedicineUnit.Tablet => "Viên",
                        EnumMedicineUnit.Blister => "Vỉ",
                        EnumMedicineUnit.Box => "Hộp",
                        EnumMedicineUnit.Bottle => "Chai",
                        EnumMedicineUnit.Vial => "Lọ",
                        EnumMedicineUnit.Ampule => "Ống",
                        EnumMedicineUnit.Sachet => "Gói",
                        EnumMedicineUnit.Tube => "Tuýp",
                        _ => med.Unit?.ToString() ?? "Không rõ"
                    };

                    medicineRows += $@"
                    <tr>
                        <td align='center'>{stt++}</td>
                        <td>{med.MedicineName}</td>
                        <td align='center'>{unitVN}</td>
                        <td>{med.Dosage} - {med.UsageInstruction}</td>
                    </tr>";
                }
            }
            else
            {
                medicineRows = "<tr><td colspan='4' align='center'>Không có chỉ định thuốc</td></tr>";
            }

            string genderVN = prescriptionDetails.Gender switch
            {
                EnumGender.Male => "Nam",
                EnumGender.Female => "Nữ",
                EnumGender.Others => "Khác",
                _ => "Không xác định"
            };

            string imageUrl = "https://storage.googleapis.com/bookingcare/%24RKY6O8O.png";
            string logoBase64 = string.Empty;

            try
            {
                using (var client = new HttpClient())
                {
                    byte[] imageBytes = client.GetByteArrayAsync(imageUrl).GetAwaiter().GetResult();
                    logoBase64 = $"data:image/png;base64,{Convert.ToBase64String(imageBytes)}";
                }
            }
            catch (Exception)
            {
                logoBase64 = "BookingCare";
            }

            string logoHtml = !string.IsNullOrEmpty(logoBase64)
                ? $"<img src='{logoBase64}' alt='Booking Care Logo' style='max-width: 180px; height: auto; margin-bottom: 5px;' />"
                : "<h2 style='color:#2980b9; margin:0; font-size: 20px;'>BOOKING CARE</h2>";

            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "Prescription", "PrescriptionTemplate.html");
            if(!File.Exists(templatePath)) 
            {
                string? currentDir = Directory.GetCurrentDirectory();
                while (currentDir != null && !Directory.Exists(Path.Combine(currentDir, "BookingCare.Infrastructure")))
                {
                    currentDir = Directory.GetParent(currentDir)?.FullName;
                }
                if (currentDir != null)
                {
                    templatePath = Path.Combine(currentDir, "BookingCare.Infrastructure", "Templates", "Prescription", "PrescriptionTemplate.html");
                }
            }

            var htmlContent = File.ReadAllText(templatePath);

            htmlContent = htmlContent.Replace("{{LogoHtml}}", logoHtml)
                                     .Replace("{{PatientName}}", prescriptionDetails.PatientName)
                                     .Replace("{{ProfileCode}}", prescriptionDetails.ProfileCode)
                                     .Replace("{{Gender}}", genderVN)
                                     .Replace("{{Age}}", prescriptionDetails.Age.ToString())
                                     .Replace("{{DoctorName}}", prescriptionDetails.DoctorName)
                                     .Replace("{{AppointmentCode}}", prescriptionDetails.AppointmentCode)
                                     .Replace("{{Date}}", prescriptionDetails.Date.ToString("dd/MM/yyyy"))
                                     .Replace("{{StartTime}}", prescriptionDetails.StartTime?.ToString(@"hh\:mm"))
                                     .Replace("{{EndTime}}", prescriptionDetails.EndTime?.ToString(@"hh\:mm"))
                                     .Replace("{{Diagnosis}}", prescriptionDetails.Diagnosis)
                                     .Replace("{{MedicineRows}}", medicineRows)
                                     .Replace("{{Day}}", DateTime.Now.Day.ToString("D2"))
                                     .Replace("{{Month}}", DateTime.Now.Month.ToString("D2"))
                                     .Replace("{{Year}}", DateTime.Now.Year.ToString());

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A5Extra,
                    Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 }
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            return _converter.Convert(doc);
        }
    }
}