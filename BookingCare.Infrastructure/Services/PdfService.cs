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

            var htmlContent = $@"
                <html>
                <head>
                    <meta charset='utf-8'>
                    <style>
                        body {{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; color: #333; margin: 40px; line-height: 1.6; }}
                        
                        /* Layout Header dùng Table để tương thích DinkToPdf */
                        table.header-table {{ width: 100%; border-bottom: 2px solid #2c3e50; padding-bottom: 10px; margin-bottom: 20px; }}
                        .clinic-info {{ text-align: right; font-size: 14px; }}
                        
                        h1.main-title {{ text-align: center; color: #2c3e50; font-size: 26px; text-transform: uppercase; margin-top: 10px; margin-bottom: 25px; letter-spacing: 1px; }}
                        .section-title {{ font-size: 16px; color: #2980b9; border-bottom: 1px solid #bdc3c7; padding-bottom: 5px; margin-top: 20px; margin-bottom: 10px; font-weight: bold; text-transform: uppercase; }}
                        
                        /* Layout lưới thông tin dùng Table */
                        table.info-table {{ width: 100%; font-size: 14px; margin-bottom: 10px; }}
                        table.info-table td {{ padding-bottom: 6px; vertical-align: top; }}
                        .info-label {{ font-weight: 600; color: #555; }}
                        
                        table.medicine-table {{ width: 100%; border-collapse: collapse; margin-top: 15px; font-size: 14px; }}
                        table.medicine-table th {{ background-color: #f8f9fa; color: #2c3e50; font-weight: bold; border: 1px solid #ddd; padding: 10px; text-align: left; }}
                        table.medicine-table td {{ border: 1px solid #ddd; padding: 8px; }}
                        table.medicine-table tr:nth-child(even) {{ background-color: #fbfbfc; }}
                        
                        .footer-table {{ width: 100%; margin-top: 40px; }}
                        .footer-text {{ text-align: right; padding-right: 30px; }}
                        .footer-date {{ font-style: italic; margin-bottom: 10px; }}
                        .signature-area {{ height: 80px; }}
                    </style>
                </head>
                <body>
                    <table class='header-table' cellpadding='0' cellspacing='0'>
                        <tr>
                            <td style='width: 40%; vertical-align: top;'>
                                <h2 style='color:#2980b9; margin:0; font-size: 20px;'>BOOKING CARE</h2>
                                <p style='font-size:12px; color:#7f8c8d; margin:3px 0 0 0;'>Chăm sóc sức khỏe toàn diện</p>
                            </td>
                            <td class='clinic-info' style='width: 60%; vertical-align: top;'>
                                <strong>Phòng Khám Đa Khoa Booking Care</strong><br>
                                Hotline: 1900 1234<br>
                                Email: contact@bookingcare.vn
                            </td>
                        </tr>
                    </table>

                    <h1 class='main-title'>KẾT QUẢ KHÁM BỆNH & ĐƠN THUỐC</h1>

                    <div class='section-title'>THÔNG TIN BỆNH NHÂN</div>
                    <table class='info-table' cellpadding='0' cellspacing='0'>
                        <tr>
                            <td style='width: 50%;'>
                                <span class='info-label'>Họ và tên:</span> <strong>{prescriptionDetails.PatientName}</strong>
                            </td>
                            <td style='width: 50%;'>
                                <span class='info-label'>Mã bệnh nhân:</span> {prescriptionDetails.ProfileCode}
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class='info-label'>Giới tính:</span> {genderVN}
                            </td>
                            <td>
                                <span class='info-label'>Tuổi:</span> {prescriptionDetails.Age}
                            </td>
                        </tr>
                    </table>

                    <div class='section-title'>THÔNG TIN KHÁM BỆNH</div>
                    <table class='info-table' cellpadding='0' cellspacing='0'>
                        <tr>
                            <td style='width: 50%;'>
                                <span class='info-label'>Bác sĩ khám:</span> {prescriptionDetails.DoctorName}
                            </td>
                            <td style='width: 50%;'>
                                <span class='info-label'>Mã lịch hẹn:</span> {prescriptionDetails.AppointmentCode}
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class='info-label'>Ngày khám:</span> {prescriptionDetails.Date:dd/MM/yyyy}
                            </td>
                            <td>
                                <span class='info-label'>Giờ khám:</span> {prescriptionDetails.StartTime:hh\:mm} - {prescriptionDetails.EndTime:hh\:mm}
                            </td>
                        </tr>
                        <tr>
                            <td colspan='2'>
                                <span class='info-label'>Chẩn đoán:</span> <strong style='color:#c0392b;'>{prescriptionDetails.Diagnosis}</strong>
                            </td>
                        </tr>
                    </table>

                    <div class='section-title'>CHI TIẾT ĐƠN THUỐC</div>
                    <table class='medicine-table'>
                        <thead>
                            <tr>
                                <th width='5%' style='text-align:center'>STT</th>
                                <th width='35%'>Tên Thuốc</th>
                                <th width='15%' style='text-align:center'>Đơn vị</th>
                                <th width='45%'>Liều dùng & Cách dùng</th>
                            </tr>
                        </thead>
                        <tbody>
                            {medicineRows}
                        </tbody>
                    </table>

                    <table class='footer-table' cellpadding='0' cellspacing='0'>
                        <tr>
                            <td style='width: 60%;'></td>
                            <td class='footer-text' style='width: 40%;'>
                                <div class='footer-date'>
                                    Ngày {DateTime.Now.Day:D2} tháng {DateTime.Now.Month:D2} năm {DateTime.Now.Year}
                                </div>
                                <strong>Bác sĩ chỉ định</strong><br>
                                <div class='signature-area'></div>
                                <strong>{prescriptionDetails.DoctorName}</strong>
                            </td>
                        </tr>
                    </table>
                </body>
                </html>";

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