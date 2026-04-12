using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_medicine_prescription_table_and_seed_demo_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PrescriptionId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionDetails_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionDetails_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "CreatedDate", "Function", "Name", "Unit", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("073e5869-14fa-2592-6390-72a1d495c689"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Thuốc kháng histamin, điều trị viêm mũi dị ứng, mề đay.", "Loratadine 10mg", "Tablet", null },
                    { new Guid("184f697a-250b-3603-74a1-83b2e506d79a"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Siro ho chiết xuất lá thường xuân, làm loãng đờm, giảm ho.", "Prospan 100ml", "Bottle", null },
                    { new Guid("29507a8b-361c-4714-85b2-94c3f617e8ab"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Thuốc chẹn kênh canxi, điều trị tăng huyết áp.", "Amlodipine 5mg", "Blister", null },
                    { new Guid("3a618b9c-472d-5825-96c3-05d40728f9bc"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Tăng cường sức đề kháng, bổ sung vitamin C.", "Vitamin C 500mg", "Vial", null },
                    { new Guid("4b729cad-583e-6936-07d4-16e518390acd"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Hỗ trợ điều trị thoái hóa khớp, tăng dịch nhờn sụn khớp.", "Glucosamine Sulfate 1500mg", "Box", null },
                    { new Guid("5c83adb1-694f-7a47-18e5-27f6294a1bde"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Thuốc gây tê tại chỗ dạng tiêm.", "Lidocaine 2%", "Ampule", null },
                    { new Guid("6d94bec2-7a50-8b58-29f6-38073a5b2cef"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Điều trị thiếu máu do thiếu vitamin B12, đau dây thần kinh.", "Vitamin B12 1000mcg", "Ampule", null },
                    { new Guid("a1d8f203-5e94-6f3c-0d3a-1c4b7e3f6023"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Gel bôi ngoài da giảm đau, chống viêm cơ xương khớp.", "Voltaren Emulgel 1% 20g", "Tube", null },
                    { new Guid("b2e90314-6fa5-704d-1e4b-2d5c8f407134"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Ức chế tiết axit dạ dày, điều trị viêm loét dạ dày - tá tràng.", "Omeprazole 20mg", "Tablet", null },
                    { new Guid("c3fa1425-70b6-815e-2f5c-3e6d90518245"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Thuốc kháng axit, điều trị cơn đau dạ dày cấp.", "Phosphalugel 20% 20g", "Sachet", null },
                    { new Guid("d40b2536-81c7-926f-306d-4f7ea1629356"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Điều trị tiêu chảy, nhiễm khuẩn đường ruột.", "Berberin 10mg", "Bottle", null },
                    { new Guid("e4b6d081-3c72-4d1a-8b1e-9a2f5c1d4e01"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Giảm đau, hạ sốt từ nhẹ đến vừa.", "Paracetamol 500mg", "Tablet", null },
                    { new Guid("e51c3647-92d8-0370-417e-508fb273a467"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Kháng sinh nhóm Penicillin, điều trị nhiễm khuẩn hô hấp, tai mũi họng.", "Amoxicillin 500mg", "Blister", null },
                    { new Guid("f5c7e192-4d83-5e2b-9c2f-0b3a6d2e5f12"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Kháng viêm không steroid (NSAID), giảm đau, hạ sốt.", "Ibuprofen 400mg", "Tablet", null },
                    { new Guid("f62d4758-03e9-1481-528f-6190c384b578"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Kháng sinh nhóm Macrolid, trị viêm phế quản, viêm phổi.", "Azithromycin 250mg", "Tablet", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDetails_MedicineId",
                table: "PrescriptionDetails",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDetails_PrescriptionId",
                table: "PrescriptionDetails",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_AppointmentId",
                table: "Prescriptions",
                column: "AppointmentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescriptionDetails");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PrescriptionId",
                table: "Appointments");
        }
    }
}
