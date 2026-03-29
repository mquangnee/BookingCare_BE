using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seed_new_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "SpecialtyCode", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111101"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám và điều trị các bệnh lý về hệ vận động, xương khớp.", "https://storage.googleapis.com/bookingcare/specialties/co-xuong-khop.jpg", "Cơ Xương Khớp", "CK-001", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111102"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên khoa dạ dày, đại tràng, gan mật và nội soi tiêu hóa.", "https://storage.googleapis.com/bookingcare/specialties/tieu-hoa.jpg", "Tiêu hóa", "CK-002", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111103"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Điều trị cao huyết áp, suy tim và các bệnh lý mạch vành.", "https://storage.googleapis.com/bookingcare/specialties/tim-mach.jpg", "Tim mạch", "CK-003", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111104"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Chăm sóc thai kỳ, sinh sản và các bệnh lý phụ khoa nữ giới.", "https://storage.googleapis.com/bookingcare/specialties/san-phu-khoa.jpg", "Sản Phụ khoa", "CK-004", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111105"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám và điều trị các bệnh lý thường gặp ở trẻ sơ sinh và trẻ nhỏ.", "https://storage.googleapis.com/bookingcare/specialties/nhi-khoa.jpg", "Nhi khoa", "CK-005", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111106"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Điều trị mụn, nám, dị ứng da và thẩm mỹ công nghệ cao.", "https://storage.googleapis.com/bookingcare/specialties/da-lieu.jpg", "Da liễu", "CK-006", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111107"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám và điều trị viêm xoang, viêm họng, các bệnh lý tai mũi họng.", "https://storage.googleapis.com/bookingcare/specialties/tai-mui-hong.jpg", "Tai Mũi Họng", "CK-007", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111108"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám mắt tổng quát, đo thị lực và điều trị tật khúc xạ.", "https://storage.googleapis.com/bookingcare/specialties/mat.jpg", "Mắt", "CK-008", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111109"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Chẩn đoán rối loạn thần kinh, đau đầu, tiền đình và não bộ.", "https://storage.googleapis.com/bookingcare/specialties/than-kinh.jpg", "Thần kinh", "CK-009", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111110"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Nha khoa tổng quát, nhổ răng khôn và thẩm mỹ răng sứ.", "https://storage.googleapis.com/bookingcare/specialties/rang-ham-mat.jpg", "Răng Hàm Mặt", "CK-010", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "AvatarUrl", "CitizenId", "DateOfBirth", "Description", "DoctorCode", "ExperienceYears", "FullName", "Gender", "Position", "SpecialtyId", "SubSpecialties", "UserId", "WorkingHistory" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333301"), "https://storage.googleapis.com/bookingcare/doctors/bs-minh.jpg", "001075123456", new DateTime(1975, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia tiêu hóa.", "BS-001", 25, "PGS.TS Nguyễn Trọng Minh", 0, 3, new Guid("11111111-1111-1111-1111-111111111102"), "[\"Ti\\u00EAu h\\u00F3a\",\"N\\u1ED9i soi\"]", new Guid("021ac6a0-18c5-4e1e-6386-08de8652903f"), "BV Bạch Mai" },
                    { new Guid("33333333-3333-3333-3333-333333333302"), "https://storage.googleapis.com/bookingcare/doctors/bs-van.jpg", "001182654321", new DateTime(1982, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia xương khớp.", "BS-002", 15, "ThS.BS Đỗ Thị Tường Vân", 1, 1, new Guid("11111111-1111-1111-1111-111111111101"), "[\"X\\u01B0\\u01A1ng kh\\u1EDBp\"]", new Guid("021ac6a0-18c5-4e1e-6386-08de8652903f"), "BV Chợ Rẫy" },
                    { new Guid("33333333-3333-3333-3333-333333333303"), "https://storage.googleapis.com/bookingcare/doctors/bs-nam.jpg", "001078987654", new DateTime(1978, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia tim mạch.", "BS-003", 20, "BSCKII Phạm Thành Nam", 0, 2, new Guid("11111111-1111-1111-1111-111111111103"), "[\"Tim m\\u1EA1ch\"]", new Guid("021ac6a0-18c5-4e1e-6386-08de8652903f"), "Viện Tim TP.HCM" },
                    { new Guid("33333333-3333-3333-3333-333333333304"), "https://storage.googleapis.com/bookingcare/doctors/bs-ha.jpg", "001185456789", new DateTime(1985, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên khoa sản.", "BS-004", 12, "ThS.BS Lê Thị Thu Hà", 1, 1, new Guid("11111111-1111-1111-1111-111111111104"), "[\"S\\u1EA3n khoa\"]", new Guid("021ac6a0-18c5-4e1e-6386-08de8652903f"), "BV Từ Dũ" },
                    { new Guid("33333333-3333-3333-3333-333333333305"), "https://storage.googleapis.com/bookingcare/doctors/bs-duc.jpg", "001088112233", new DateTime(1988, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ nhi khoa.", "BS-005", 10, "BSCKI Hoàng Văn Đức", 0, 1, new Guid("11111111-1111-1111-1111-111111111105"), "[\"Nhi khoa\"]", new Guid("021ac6a0-18c5-4e1e-6386-08de8652903f"), "BV Nhi TW" },
                    { new Guid("33333333-3333-3333-3333-333333333306"), "https://storage.googleapis.com/bookingcare/doctors/bs-huong.jpg", "001190334455", new DateTime(1990, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ da liễu.", "BS-006", 8, "BS Trần Mai Hương", 1, 0, new Guid("11111111-1111-1111-1111-111111111106"), "[\"Da li\\u1EC5u\"]", new Guid("021ac6a0-18c5-4e1e-6386-08de8652903f"), "Phòng khám Da liễu HN" },
                    { new Guid("33333333-3333-3333-3333-333333333307"), "https://storage.googleapis.com/bookingcare/doctors/bs-tuan.jpg", "001072998877", new DateTime(1972, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ TMH.", "BS-007", 28, "BSCKII Vũ Anh Tuấn", 0, 2, new Guid("11111111-1111-1111-1111-111111111107"), "[\"Tai M\\u0169i H\\u1ECDng\"]", new Guid("021ac6a0-18c5-4e1e-6386-08de8652903f"), "BV Tai Mũi Họng TW" },
                    { new Guid("33333333-3333-3333-3333-333333333308"), "https://storage.googleapis.com/bookingcare/doctors/bs-nhung.jpg", "001183223344", new DateTime(1983, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ mắt.", "BS-008", 14, "ThS.BS Bùi Tuyết Nhung", 1, 1, new Guid("11111111-1111-1111-1111-111111111108"), "[\"Nh\\u00E3n khoa\"]", new Guid("021ac6a0-18c5-4e1e-6386-08de8652903f"), "BV Mắt TW" },
                    { new Guid("33333333-3333-3333-3333-333333333309"), "https://storage.googleapis.com/bookingcare/doctors/bs-viet.jpg", "001065776655", new DateTime(1965, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ thần kinh.", "BS-009", 35, "PGS.TS Ngô Quốc Việt", 0, 3, new Guid("11111111-1111-1111-1111-111111111109"), "[\"Th\\u1EA7n kinh\"]", new Guid("021ac6a0-18c5-4e1e-6386-08de8652903f"), "ĐH Y Hà Nội" },
                    { new Guid("33333333-3333-3333-3333-333333333310"), "https://storage.googleapis.com/bookingcare/doctors/bs-dung.jpg", "001087009988", new DateTime(1987, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nha sĩ.", "BS-010", 11, "BSCKI Đặng Tiến Dũng", 0, 1, new Guid("11111111-1111-1111-1111-111111111110"), "[\"R\\u0103ng H\\u00E0m M\\u1EB7t\"]", new Guid("021ac6a0-18c5-4e1e-6386-08de8652903f"), "BV RHM TW" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedDate", "Description", "DoctorId", "DurationInMinutes", "IsActive", "Name", "Price", "ServiceCode", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222201"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám xương khớp tổng quát.", new Guid("33333333-3333-3333-3333-333333333302"), 15, true, "Khám chuyên khoa Cơ xương khớp", 300000.0, "SRV-001", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-2222-2222-222222222202"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Nội soi không đau.", new Guid("33333333-3333-3333-3333-333333333301"), 45, true, "Nội soi dạ dày gây mê", 1200000.0, "SRV-002", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-2222-2222-222222222203"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Siêu âm chức năng tim.", new Guid("33333333-3333-3333-3333-333333333303"), 20, true, "Siêu âm tim Dopler màu", 450000.0, "SRV-003", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-2222-2222-222222222204"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Siêu âm tầm soát thai nhi.", new Guid("33333333-3333-3333-3333-333333333304"), 30, true, "Siêu âm thai 4D", 500000.0, "SRV-004", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-2222-2222-222222222205"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám sức khỏe cho trẻ.", new Guid("33333333-3333-3333-3333-333333333305"), 15, true, "Khám Nhi tổng quát", 200000.0, "SRV-005", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-2222-2222-222222222206"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Xử lý mụn công nghệ cao.", new Guid("33333333-3333-3333-3333-333333333306"), 40, true, "Điều trị mụn Laser", 800000.0, "SRV-006", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-2222-2222-222222222207"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Nội soi họng và tai.", new Guid("33333333-3333-3333-3333-333333333307"), 15, true, "Nội soi Tai Mũi Họng", 250000.0, "SRV-007", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-2222-2222-222222222208"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra độ cận/viễn.", new Guid("33333333-3333-3333-3333-333333333308"), 20, true, "Đo khúc xạ mắt", 150000.0, "SRV-008", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-2222-2222-222222222209"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám chức năng não.", new Guid("33333333-3333-3333-3333-333333333309"), 45, true, "Đo điện não đồ EEG", 600000.0, "SRV-009", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-2222-2222-222222222210"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Tiểu phẫu răng miệng.", new Guid("33333333-3333-3333-3333-333333333310"), 60, true, "Nhổ răng khôn mọc lệch", 1500000.0, "SRV-010", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222201"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222202"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222203"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222204"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222205"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222206"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222207"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222208"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222209"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222210"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333301"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333302"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333303"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333304"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333305"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333306"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333307"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333308"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333309"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333310"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111101"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111102"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111103"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111104"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111105"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111106"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111107"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111108"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111109"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111110"));
        }
    }
}
