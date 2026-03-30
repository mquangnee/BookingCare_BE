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
            // Do not delete AspNetRoles — work sessions do not require it; deleting seeded roles
            // (e.g. Patient eb0a010d-...) removed Identity rows without re-inserting them in Up().
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
        }
    }
}
