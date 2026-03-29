using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seed_role_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
