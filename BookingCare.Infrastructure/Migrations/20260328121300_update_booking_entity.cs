using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_booking_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments");

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

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Appointments");

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "Services",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SpecialtyId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "Appointments",
                type: "time",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "Appointments",
                type: "time",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QueueNumber",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppointmentServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceOverride = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentServices_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkSessionServices_ServiceId",
                table: "WorkSessionServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSessionServices_WorkSessionId",
                table: "WorkSessionServices",
                column: "WorkSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_DoctorId",
                table: "Services",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentServices_AppointmentId",
                table: "AppointmentServices",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentServices_ServiceId",
                table: "AppointmentServices",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialties_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Doctors_DoctorId",
                table: "Services",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSessionServices_Services_ServiceId",
                table: "WorkSessionServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSessionServices_WorkSessions_WorkSessionId",
                table: "WorkSessionServices",
                column: "WorkSessionId",
                principalTable: "WorkSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialties_SpecialtyId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Doctors_DoctorId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkSessionServices_Services_ServiceId",
                table: "WorkSessionServices");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkSessionServices_WorkSessions_WorkSessionId",
                table: "WorkSessionServices");

            migrationBuilder.DropTable(
                name: "AppointmentServices");

            migrationBuilder.DropIndex(
                name: "IX_WorkSessionServices_ServiceId",
                table: "WorkSessionServices");

            migrationBuilder.DropIndex(
                name: "IX_WorkSessionServices_WorkSessionId",
                table: "WorkSessionServices");

            migrationBuilder.DropIndex(
                name: "IX_Services_DoctorId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "QueueNumber",
                table: "Appointments");

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Appointments",
                type: "datetime2",
                nullable: true);

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
                columns: new[] { "Id", "CreatedDate", "Description", "DurationInMinutes", "IsActive", "Name", "Price", "ServiceCode", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222221"), new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khám lâm sàng với Bác sĩ chuyên khoa, tư vấn lộ trình điều trị.", 15, true, "Khám chuyên khoa Cơ xương khớp", 300000.0, "SRV-001", new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phương pháp nội soi tiên tiến, bệnh nhân không có cảm giác buồn nôn hay khó chịu.", 45, true, "Nội soi dạ dày không đau (Gây mê)", 1200000.0, "SRV-002", new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-2222-2222-222222222223"), new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Siêu âm đánh giá hình thái, chức năng và huyết động học của tim.", 20, true, "Siêu âm tim Dopler màu", 450000.0, "SRV-003", new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "SpecialtyCode", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khám và điều trị các bệnh lý về hệ cơ, xương, khớp như thoái hóa cột sống, thoát vị đĩa đệm, viêm khớp dạng thấp.", "https://storage.googleapis.com/bookingcare/specialties/co-xuong-khop.jpg", "Cơ Xương Khớp", "CK-001", new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111112"), new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên chẩn đoán và điều trị các bệnh lý liên quan đến dạ dày, tá tràng, đại tràng, gan, mật, tụy.", "https://storage.googleapis.com/bookingcare/specialties/tieu-hoa.jpg", "Tiêu hóa", "CK-002", new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111113"), new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khám, siêu âm và điều trị các bệnh lý về tim mạch, huyết áp, mạch máu.", "https://storage.googleapis.com/bookingcare/specialties/tim-mach.jpg", "Tim mạch", "CK-003", new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
