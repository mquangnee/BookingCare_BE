using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_status_field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: new Guid("073e5869-14fa-2592-6390-72a1d495c689"),
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: new Guid("184f697a-250b-3603-74a1-83b2e506d79a"),
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: new Guid("29507a8b-361c-4714-85b2-94c3f617e8ab"),
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: new Guid("3a618b9c-472d-5825-96c3-05d40728f9bc"),
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: new Guid("4b729cad-583e-6936-07d4-16e518390acd"),
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: new Guid("5c83adb1-694f-7a47-18e5-27f6294a1bde"),
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: new Guid("6d94bec2-7a50-8b58-29f6-38073a5b2cef"),
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: new Guid("a1d8f203-5e94-6f3c-0d3a-1c4b7e3f6023"),
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: new Guid("b2e90314-6fa5-704d-1e4b-2d5c8f407134"),
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: new Guid("c3fa1425-70b6-815e-2f5c-3e6d90518245"),
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: new Guid("d40b2536-81c7-926f-306d-4f7ea1629356"),
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: new Guid("e4b6d081-3c72-4d1a-8b1e-9a2f5c1d4e01"),
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: new Guid("e51c3647-92d8-0370-417e-508fb273a467"),
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: new Guid("f5c7e192-4d83-5e2b-9c2f-0b3a6d2e5f12"),
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: new Guid("f62d4758-03e9-1481-528f-6190c384b578"),
                column: "Status",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Medicines");
        }
    }
}
