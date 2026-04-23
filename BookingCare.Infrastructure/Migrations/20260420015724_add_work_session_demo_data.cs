using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_work_session_demo_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-0000-0000-0000-000000000000"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1111-1111-1111-111111111111"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-2222-2222-2222-222222222222"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-3333-3333-3333-333333333333"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-4444-4444-4444-444444444444"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-5555-5555-5555-555555555555"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-6666-6666-6666-666666666666"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-7777-7777-7777-777777777777"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-8888-8888-8888-888888888888"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-9999-9999-9999-999999999999"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==");

            migrationBuilder.InsertData(
                table: "WorkSessions",
                columns: new[] { "Id", "CreatedDate", "DoctorId", "EndTime", "NextAvailableAt", "ServiceId", "StartTime", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("44444444-7777-7777-7777-000000000025"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 4, 23, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111106"), new DateTime(2026, 4, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000026"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-4444-4444-4444-444444444444"), new DateTime(2026, 4, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111107"), new DateTime(2026, 4, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000027"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-8888-8888-8888-888888888888"), new DateTime(2026, 4, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111104"), new DateTime(2026, 4, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000028"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 4, 23, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 23, 14, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111103"), new DateTime(2026, 4, 23, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000029"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-5555-5555-5555-555555555555"), new DateTime(2026, 4, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111107"), new DateTime(2026, 4, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000030"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-6666-6666-6666-666666666666"), new DateTime(2026, 4, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111105"), new DateTime(2026, 4, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000031"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1111-1111-1111-111111111111"), new DateTime(2026, 4, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111103"), new DateTime(2026, 4, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000032"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-7777-7777-7777-777777777777"), new DateTime(2026, 4, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111101"), new DateTime(2026, 4, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000033"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-8888-8888-8888-888888888888"), new DateTime(2026, 4, 26, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111107"), new DateTime(2026, 4, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000034"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-4444-4444-4444-444444444444"), new DateTime(2026, 4, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111106"), new DateTime(2026, 4, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000035"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-7777-7777-7777-777777777777"), new DateTime(2026, 4, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 23, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111105"), new DateTime(2026, 4, 23, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000036"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-2222-2222-2222-222222222222"), new DateTime(2026, 4, 23, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 23, 9, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111104"), new DateTime(2026, 4, 23, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000037"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1111-1111-1111-111111111111"), new DateTime(2026, 4, 25, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111102"), new DateTime(2026, 4, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000038"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-6666-6666-6666-666666666666"), new DateTime(2026, 4, 25, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111107"), new DateTime(2026, 4, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000039"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-6666-6666-6666-666666666666"), new DateTime(2026, 4, 24, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111105"), new DateTime(2026, 4, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000040"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-7777-7777-7777-777777777777"), new DateTime(2026, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 26, 14, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111104"), new DateTime(2026, 4, 26, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000041"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-2222-2222-2222-222222222222"), new DateTime(2026, 4, 24, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111102"), new DateTime(2026, 4, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000042"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-0000-0000-0000-000000000000"), new DateTime(2026, 4, 22, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111107"), new DateTime(2026, 4, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000043"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-4444-4444-4444-444444444444"), new DateTime(2026, 4, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111102"), new DateTime(2026, 4, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000044"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-9999-9999-9999-999999999999"), new DateTime(2026, 4, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111110"), new DateTime(2026, 4, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000045"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1111-1111-1111-111111111111"), new DateTime(2026, 4, 26, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 26, 9, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111102"), new DateTime(2026, 4, 26, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000046"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-7777-7777-7777-777777777777"), new DateTime(2026, 4, 23, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 23, 13, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111102"), new DateTime(2026, 4, 23, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000047"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-5555-5555-5555-555555555555"), new DateTime(2026, 4, 22, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 22, 13, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111103"), new DateTime(2026, 4, 22, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000048"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-0000-0000-0000-000000000000"), new DateTime(2026, 4, 26, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 26, 14, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111103"), new DateTime(2026, 4, 26, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000049"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-9999-9999-9999-999999999999"), new DateTime(2026, 4, 24, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111101"), new DateTime(2026, 4, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000050"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-4444-4444-4444-444444444444"), new DateTime(2026, 4, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111103"), new DateTime(2026, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000051"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-7777-7777-7777-777777777777"), new DateTime(2026, 4, 21, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111101"), new DateTime(2026, 4, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000052"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 4, 20, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 9, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111110"), new DateTime(2026, 4, 20, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000053"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-8888-8888-8888-888888888888"), new DateTime(2026, 4, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111110"), new DateTime(2026, 4, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000054"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-7777-7777-7777-777777777777"), new DateTime(2026, 4, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111101"), new DateTime(2026, 4, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000025"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000026"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000027"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000028"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000029"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000030"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000031"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000032"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000033"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000034"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000035"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000036"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000037"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000038"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000039"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000040"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000041"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000042"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000043"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000044"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000045"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000046"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000047"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000048"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000049"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000050"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000051"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000052"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000053"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-7777-7777-7777-000000000054"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-0000-0000-0000-000000000000"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1111-1111-1111-111111111111"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-2222-2222-2222-222222222222"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-3333-3333-3333-333333333333"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-4444-4444-4444-444444444444"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-5555-5555-5555-555555555555"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-6666-6666-6666-666666666666"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-7777-7777-7777-777777777777"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-8888-8888-8888-888888888888"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-9999-9999-9999-999999999999"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==");
        }
    }
}
