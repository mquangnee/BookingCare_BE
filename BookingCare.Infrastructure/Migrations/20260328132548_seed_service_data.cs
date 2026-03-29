using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seed_service_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorId",
                table: "Services",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SpecialtyId",
                table: "Services",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222201"),
                columns: new[] { "Position", "SpecialtyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222202"),
                columns: new[] { "Position", "SpecialtyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222203"),
                columns: new[] { "Position", "SpecialtyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222204"),
                columns: new[] { "Position", "SpecialtyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222205"),
                columns: new[] { "Position", "SpecialtyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222206"),
                columns: new[] { "Position", "SpecialtyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222207"),
                columns: new[] { "Position", "SpecialtyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222208"),
                columns: new[] { "Position", "SpecialtyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222209"),
                columns: new[] { "Position", "SpecialtyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222210"),
                columns: new[] { "Position", "SpecialtyId" },
                values: new object[] { null, null });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedDate", "Description", "DoctorId", "DurationInMinutes", "IsActive", "Name", "Position", "Price", "ServiceCode", "SpecialtyId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-000000000001"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), null, null, 15, true, "Khám Bác sĩ - Cơ Xương Khớp", 0, 150000.0, "KHAM-CXK-BS", new Guid("11111111-1111-1111-1111-111111111101"), null },
                    { new Guid("22222222-2222-2222-2222-000000000002"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), null, null, 15, true, "Khám Thạc sĩ - Cơ Xương Khớp", 1, 250000.0, "KHAM-CXK-THS", new Guid("11111111-1111-1111-1111-111111111101"), null },
                    { new Guid("22222222-2222-2222-2222-000000000003"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20, true, "Khám PGS - Cơ Xương Khớp", 3, 450000.0, "KHAM-CXK-PGS", new Guid("11111111-1111-1111-1111-111111111101"), null },
                    { new Guid("22222222-2222-2222-2222-000000000004"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), null, null, 15, true, "Khám Bác sĩ - Tiêu hóa", 0, 200000.0, "KHAM-TH-BS", new Guid("11111111-1111-1111-1111-111111111102"), null },
                    { new Guid("22222222-2222-2222-2222-000000000005"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), null, null, 15, true, "Khám Thạc sĩ - Tiêu hóa", 1, 300000.0, "KHAM-TH-THS", new Guid("11111111-1111-1111-1111-111111111102"), null },
                    { new Guid("22222222-2222-2222-2222-000000000006"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20, true, "Khám PGS - Tiêu hóa", 3, 500000.0, "KHAM-TH-PGS", new Guid("11111111-1111-1111-1111-111111111102"), null },
                    { new Guid("22222222-2222-2222-2222-000000000007"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), null, null, 15, true, "Khám Bác sĩ - Tim mạch", 0, 250000.0, "KHAM-TM-BS", new Guid("11111111-1111-1111-1111-111111111103"), null },
                    { new Guid("22222222-2222-2222-2222-000000000008"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20, true, "Khám PGS - Tim mạch", 3, 600000.0, "KHAM-TM-PGS", new Guid("11111111-1111-1111-1111-111111111103"), null },
                    { new Guid("22222222-2222-2222-2222-000000000009"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), null, null, 30, true, "Khám Giáo sư - Tim mạch", 4, 800000.0, "KHAM-TM-GS", new Guid("11111111-1111-1111-1111-111111111103"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_SpecialtyId",
                table: "Services",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Specialties_SpecialtyId",
                table: "Services",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Specialties_SpecialtyId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_SpecialtyId",
                table: "Services");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-000000000001"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-000000000002"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-000000000003"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-000000000004"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-000000000005"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-000000000006"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-000000000007"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-000000000008"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-000000000009"));

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Services");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorId",
                table: "Services",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
