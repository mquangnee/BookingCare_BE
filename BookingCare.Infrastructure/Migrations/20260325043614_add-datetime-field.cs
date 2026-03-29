using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adddatetimefield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1ad3c56a-7b3f-42a9-b3a1-df8b105a30bf"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("34994df5-6435-430c-8fd3-e578da6ed929"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eb0a010d-c0ed-4fb9-a9a7-96a1a1fdc04c"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333331"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333332"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222221"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222223"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Specialties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Specialties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Services",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Appointments",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Appointments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1ad3c56a-7b3f-42a9-b3a1-df8b105a30bf"), "b9a8c7d6-e5f4-3210-a1b2-c3d4e5f60718", "Receptionist", "RECEPTIONIST" },
                    { new Guid("34994df5-6435-430c-8fd3-e578da6ed929"), "01234567-89ab-cdef-0123-456789abcdef", "Admin", "ADMIN" },
                    { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), "76543210-fedc-ba98-7654-3210fedcba98", "Doctor", "DOCTOR" },
                    { new Guid("eb0a010d-c0ed-4fb9-a9a7-96a1a1fdc04c"), "abcdef01-2345-6789-abcd-ef0123456789", "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "AvatarUrl", "CitizenId", "DateOfBirth", "Description", "DoctorCode", "ExperienceYears", "FullName", "Gender", "Position", "SubSpecialties", "UserId", "WorkingHistory" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333331"), "https://storage.googleapis.com/bookingcare/doctors/nguyen-trong-minh.jpg", "001075123456", new DateTime(1975, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Phó Giáo sư, Tiến sĩ, Bác sĩ Nguyễn Trọng Minh là chuyên gia đầu ngành về Tiêu hóa với hơn 20 năm kinh nghiệm.", "BS-001", 20, "Nguyễn Trọng Minh", 0, 3, "[\"N\\u1ED9i soi ti\\u00EAu h\\u00F3a\",\"\\u0110i\\u1EC1u tr\\u1ECB HP d\\u1EA1 d\\u00E0y\",\"Polyp \\u0111\\u1EA1i tr\\u00E0ng\"]", new Guid("00000000-0000-0000-0000-000000000001"), "2005 - 2015: Bác sĩ khoa Tiêu hóa Bệnh viện Bạch Mai\n2015 - Nay: Trưởng khoa Tiêu hóa Bệnh viện đa khoa Tâm Anh" },
                    { new Guid("33333333-3333-3333-3333-333333333332"), "https://storage.googleapis.com/bookingcare/doctors/do-thi-tuong-van.jpg", "001182654321", new DateTime(1982, 10, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Thạc sĩ, Bác sĩ Đỗ Thị Tường Vân nổi tiếng với sự chuyên nghiệp trong việc nhổ răng khôn không đau.", "BS-002", 15, "Đỗ Thị Tường Vân", 1, 1, "[\"Kh\\u1EDBp c\\u1EAFn\",\"Nha chu\",\"Nh\\u1ED5 r\\u0103ng kh\\u00F4n\"]", new Guid("00000000-0000-0000-0000-000000000002"), "2010 - Nay: Bác sĩ chuyên khoa Răng Hàm Mặt tại Phòng khám Nha khoa Quốc tế." }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "DurationInMinutes", "IsActive", "Name", "Price", "ServiceCode" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222221"), "Khám lâm sàng với Bác sĩ chuyên khoa, tư vấn lộ trình điều trị.", 15, true, "Khám chuyên khoa Cơ xương khớp", 300000.0, "SRV-001" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Phương pháp nội soi tiên tiến, bệnh nhân không có cảm giác buồn nôn hay khó chịu.", 45, true, "Nội soi dạ dày không đau (Gây mê)", 1200000.0, "SRV-002" },
                    { new Guid("22222222-2222-2222-2222-222222222223"), "Siêu âm đánh giá hình thái, chức năng và huyết động học của tim.", 20, true, "Siêu âm tim Dopler màu", 450000.0, "SRV-003" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "SpecialtyCode" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Khám và điều trị các bệnh lý về hệ cơ, xương, khớp như thoái hóa cột sống, thoát vị đĩa đệm, viêm khớp dạng thấp.", "https://storage.googleapis.com/bookingcare/specialties/co-xuong-khop.jpg", "Cơ Xương Khớp", "CK-001" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), "Chuyên chẩn đoán và điều trị các bệnh lý liên quan đến dạ dày, tá tràng, đại tràng, gan, mật, tụy.", "https://storage.googleapis.com/bookingcare/specialties/tieu-hoa.jpg", "Tiêu hóa", "CK-002" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), "Khám, siêu âm và điều trị các bệnh lý về tim mạch, huyết áp, mạch máu.", "https://storage.googleapis.com/bookingcare/specialties/tim-mach.jpg", "Tim mạch", "CK-003" }
                });
        }
    }
}
