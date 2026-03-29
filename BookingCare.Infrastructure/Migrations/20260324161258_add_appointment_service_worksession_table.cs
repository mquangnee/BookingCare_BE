using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_appointment_service_worksession_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextAvailableAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSessions_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkSessionServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSessionServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_PatientProfiles_PatientProfileId",
                        column: x => x.PatientProfileId,
                        principalTable: "PatientProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_WorkSessions_WorkSessionId",
                        column: x => x.WorkSessionId,
                        principalTable: "WorkSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientProfileId",
                table: "Appointments",
                column: "PatientProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_WorkSessionId",
                table: "Appointments",
                column: "WorkSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSessions_DoctorId",
                table: "WorkSessions",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "WorkSessionServices");

            migrationBuilder.DropTable(
                name: "WorkSessions");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333331"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333332"));

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
        }
    }
}
