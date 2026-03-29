using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seed_worksession_data : Migration
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

            migrationBuilder.InsertData(
                table: "WorkSessions",
                columns: new[] { "Id", "CreatedDate", "DoctorId", "EndTime", "NextAvailableAt", "StartTime", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444401"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333301"), new DateTime(2026, 4, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444402"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333302"), new DateTime(2026, 4, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444403"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333303"), new DateTime(2026, 4, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444404"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333304"), new DateTime(2026, 4, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444405"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333305"), new DateTime(2026, 4, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444406"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333306"), new DateTime(2026, 4, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444407"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333307"), new DateTime(2026, 4, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444408"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333308"), new DateTime(2026, 4, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444409"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333309"), new DateTime(2026, 4, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444410"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333310"), new DateTime(2026, 4, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444411"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333301"), new DateTime(2026, 4, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444412"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333302"), new DateTime(2026, 4, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444413"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333303"), new DateTime(2026, 4, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444414"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333304"), new DateTime(2026, 4, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444415"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333305"), new DateTime(2026, 4, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444416"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333306"), new DateTime(2026, 4, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444417"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333307"), new DateTime(2026, 4, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444418"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333308"), new DateTime(2026, 4, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444419"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333309"), new DateTime(2026, 4, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("44444444-4444-4444-4444-444444444420"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333310"), new DateTime(2026, 4, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444401"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444402"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444403"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444404"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444405"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444406"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444407"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444408"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444409"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444410"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444411"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444412"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444413"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444414"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444415"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444416"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444417"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444418"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444419"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444420"));

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
    }
}
