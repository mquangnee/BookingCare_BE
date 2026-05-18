using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_demo_data_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentCode", "BookerId", "CheckInDate", "CreatedDate", "Date", "EndTime", "Note", "PatientProfileId", "PrescriptionId", "Priority", "ServiceId", "ServicePrice", "StartTime", "Status", "Type", "UpdatedDate", "WorkSessionId" },
                values: new object[,]
                {
                    { new Guid("55555555-5555-5555-5555-000000000001"), "APP202605210001", new Guid("eeeeeeee-0018-0018-0018-000000000018"), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0018-0018-0018-000000000018"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111110"), 2500000.0, new TimeSpan(0, 7, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000019") },
                    { new Guid("55555555-5555-5555-5555-000000000002"), "APP202605220002", new Guid("eeeeeeee-0003-0003-0003-000000000003"), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0003-0003-0003-000000000003"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-1111-1111-1111-222222222201"), 300000.0, new TimeSpan(0, 13, 30, 0, 0), "InProgress", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000024") },
                    { new Guid("55555555-5555-5555-5555-000000000003"), "APP202605220003", new Guid("eeeeeeee-0056-0056-0056-000000000056"), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0056-0056-0056-000000000056"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-1111-1111-1111-222222222201"), 300000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000024") },
                    { new Guid("55555555-5555-5555-5555-000000000004"), "APP202605220004", new Guid("eeeeeeee-0018-0018-0018-000000000018"), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0018-0018-0018-000000000018"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-1111-1111-1111-111111111101"), 500000.0, new TimeSpan(0, 7, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000021") },
                    { new Guid("55555555-5555-5555-5555-000000000005"), "APP202605190005", new Guid("eeeeeeee-0076-0076-0076-000000000076"), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0076-0076-0076-000000000076"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111104"), 650000.0, new TimeSpan(0, 7, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000007") },
                    { new Guid("55555555-5555-5555-5555-000000000006"), "APP202605210006", new Guid("eeeeeeee-0098-0098-0098-000000000098"), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0098-0098-0098-000000000098"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111108"), 500000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000016") },
                    { new Guid("55555555-5555-5555-5555-000000000007"), "APP202605180007", new Guid("eeeeeeee-0004-0004-0004-000000000004"), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0004-0004-0004-000000000004"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111102"), 2800000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000004") },
                    { new Guid("55555555-5555-5555-5555-000000000008"), "APP202605200008", new Guid("eeeeeeee-0073-0073-0073-000000000073"), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0073-0073-0073-000000000073"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111106"), 1500000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000012") },
                    { new Guid("55555555-5555-5555-5555-000000000009"), "APP202605230009", new Guid("eeeeeeee-0023-0023-0023-000000000023"), new DateTime(2026, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0023-0023-0023-000000000023"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-1111-1111-1111-111111111102"), 2800000.0, new TimeSpan(0, 7, 30, 0, 0), "InProgress", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000027") },
                    { new Guid("55555555-5555-5555-5555-000000000010"), "APP202605190010", new Guid("eeeeeeee-0100-0100-0100-000000000100"), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0100-0100-0100-000000000100"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111103"), 600000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000006") },
                    { new Guid("55555555-5555-5555-5555-000000000011"), "APP202605190011", new Guid("eeeeeeee-0061-0061-0061-000000000061"), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0061-0061-0061-000000000061"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111105"), 1800000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000010") },
                    { new Guid("55555555-5555-5555-5555-000000000012"), "APP202605200012", new Guid("eeeeeeee-0019-0019-0019-000000000019"), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0019-0019-0019-000000000019"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111108"), 500000.0, new TimeSpan(0, 7, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000015") },
                    { new Guid("55555555-5555-5555-5555-000000000014"), "APP202605180014", new Guid("eeeeeeee-0013-0013-0013-000000000013"), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0013-0013-0013-000000000013"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111101"), 1500000.0, new TimeSpan(0, 7, 30, 0, 0), "Pending", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000001") },
                    { new Guid("55555555-5555-5555-5555-000000000015"), "APP202605190015", new Guid("eeeeeeee-0031-0031-0031-000000000031"), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0031-0031-0031-000000000031"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111103"), 600000.0, new TimeSpan(0, 13, 30, 0, 0), "Pending", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000006") },
                    { new Guid("55555555-5555-5555-5555-000000000016"), "APP202605220016", new Guid("eeeeeeee-0009-0009-0009-000000000009"), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0009-0009-0009-000000000009"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-1111-1111-1111-222222222201"), 300000.0, new TimeSpan(0, 7, 30, 0, 0), "Pending", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000023") },
                    { new Guid("55555555-5555-5555-5555-000000000017"), "APP202605210017", new Guid("eeeeeeee-0042-0042-0042-000000000042"), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0042-0042-0042-000000000042"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111110"), 2500000.0, new TimeSpan(0, 7, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000019") },
                    { new Guid("55555555-5555-5555-5555-000000000018"), "APP202605190018", new Guid("eeeeeeee-0089-0089-0089-000000000089"), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0089-0089-0089-000000000089"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111103"), 600000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000006") },
                    { new Guid("55555555-5555-5555-5555-000000000019"), "APP202605210019", new Guid("eeeeeeee-0018-0018-0018-000000000018"), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0018-0018-0018-000000000018"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111109"), 650000.0, new TimeSpan(0, 7, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000017") },
                    { new Guid("55555555-5555-5555-5555-000000000020"), "APP202605200020", new Guid("eeeeeeee-0019-0019-0019-000000000019"), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0019-0019-0019-000000000019"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111106"), 1500000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000012") },
                    { new Guid("55555555-5555-5555-5555-000000000021"), "APP202605200021", new Guid("eeeeeeee-0062-0062-0062-000000000062"), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0062-0062-0062-000000000062"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111107"), 450000.0, new TimeSpan(0, 7, 30, 0, 0), "Completed", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000013") },
                    { new Guid("55555555-5555-5555-5555-000000000022"), "APP202605190022", new Guid("eeeeeeee-0032-0032-0032-000000000032"), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0032-0032-0032-000000000032"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111104"), 650000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000008") },
                    { new Guid("55555555-5555-5555-5555-000000000023"), "APP202605190023", new Guid("eeeeeeee-0093-0093-0093-000000000093"), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0093-0093-0093-000000000093"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111104"), 650000.0, new TimeSpan(0, 7, 30, 0, 0), "InProgress", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000007") },
                    { new Guid("55555555-5555-5555-5555-000000000024"), "APP202605190024", new Guid("eeeeeeee-0006-0006-0006-000000000006"), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0006-0006-0006-000000000006"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111103"), 600000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000006") },
                    { new Guid("55555555-5555-5555-5555-000000000025"), "APP202605180025", new Guid("eeeeeeee-0022-0022-0022-000000000022"), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0022-0022-0022-000000000022"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111102"), 2800000.0, new TimeSpan(0, 7, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000003") },
                    { new Guid("55555555-5555-5555-5555-000000000026"), "APP202605210026", new Guid("eeeeeeee-0043-0043-0043-000000000043"), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0043-0043-0043-000000000043"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111108"), 500000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000016") },
                    { new Guid("55555555-5555-5555-5555-000000000027"), "APP202605240027", new Guid("eeeeeeee-0080-0080-0080-000000000080"), new DateTime(2026, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0080-0080-0080-000000000080"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111102"), 2800000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000030") },
                    { new Guid("55555555-5555-5555-5555-000000000028"), "APP202605200028", new Guid("eeeeeeee-0032-0032-0032-000000000032"), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0032-0032-0032-000000000032"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111107"), 450000.0, new TimeSpan(0, 7, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000013") },
                    { new Guid("55555555-5555-5555-5555-000000000029"), "APP202605220029", new Guid("eeeeeeee-0027-0027-0027-000000000027"), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0027-0027-0027-000000000027"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-1111-1111-1111-111111111101"), 500000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000022") },
                    { new Guid("55555555-5555-5555-5555-000000000030"), "APP202605190030", new Guid("eeeeeeee-0066-0066-0066-000000000066"), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0066-0066-0066-000000000066"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111105"), 1800000.0, new TimeSpan(0, 7, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000009") },
                    { new Guid("55555555-5555-5555-5555-000000000031"), "APP202605240031", new Guid("eeeeeeee-0083-0083-0083-000000000083"), new DateTime(2026, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0083-0083-0083-000000000083"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-1111-1111-1111-111111111101"), 1500000.0, new TimeSpan(0, 7, 30, 0, 0), "InProgress", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000028") },
                    { new Guid("55555555-5555-5555-5555-000000000032"), "APP202605210032", new Guid("eeeeeeee-0040-0040-0040-000000000040"), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0040-0040-0040-000000000040"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111110"), 2500000.0, new TimeSpan(0, 13, 30, 0, 0), "Completed", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000020") },
                    { new Guid("55555555-5555-5555-5555-000000000033"), "APP202605210033", new Guid("eeeeeeee-0054-0054-0054-000000000054"), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0054-0054-0054-000000000054"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111108"), 500000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000016") },
                    { new Guid("55555555-5555-5555-5555-000000000034"), "APP202605200034", new Guid("eeeeeeee-0003-0003-0003-000000000003"), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0003-0003-0003-000000000003"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111106"), 1500000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000012") },
                    { new Guid("55555555-5555-5555-5555-000000000035"), "APP202605240035", new Guid("eeeeeeee-0012-0012-0012-000000000012"), new DateTime(2026, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0012-0012-0012-000000000012"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-1111-1111-1111-222222222201"), 300000.0, new TimeSpan(0, 7, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000029") },
                    { new Guid("55555555-5555-5555-5555-000000000036"), "APP202605190036", new Guid("eeeeeeee-0051-0051-0051-000000000051"), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0051-0051-0051-000000000051"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111105"), 1800000.0, new TimeSpan(0, 7, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000009") },
                    { new Guid("55555555-5555-5555-5555-000000000037"), "APP202605190037", new Guid("eeeeeeee-0072-0072-0072-000000000072"), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0072-0072-0072-000000000072"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111105"), 1800000.0, new TimeSpan(0, 7, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000009") },
                    { new Guid("55555555-5555-5555-5555-000000000038"), "APP202605230038", new Guid("eeeeeeee-0082-0082-0082-000000000082"), new DateTime(2026, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0082-0082-0082-000000000082"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-1111-1111-1111-111111111101"), 1500000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000025") },
                    { new Guid("55555555-5555-5555-5555-000000000039"), "APP202605200039", new Guid("eeeeeeee-0011-0011-0011-000000000011"), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0011-0011-0011-000000000011"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111106"), 1500000.0, new TimeSpan(0, 13, 30, 0, 0), "Pending", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000012") },
                    { new Guid("55555555-5555-5555-5555-000000000040"), "APP202605180040", new Guid("eeeeeeee-0064-0064-0064-000000000064"), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0064-0064-0064-000000000064"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111103"), 600000.0, new TimeSpan(0, 7, 30, 0, 0), "InProgress", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000005") },
                    { new Guid("55555555-5555-5555-5555-000000000041"), "APP202605180041", new Guid("eeeeeeee-0050-0050-0050-000000000050"), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0050-0050-0050-000000000050"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111101"), 1500000.0, new TimeSpan(0, 13, 30, 0, 0), "Pending", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000002") },
                    { new Guid("55555555-5555-5555-5555-000000000042"), "APP202605220042", new Guid("eeeeeeee-0062-0062-0062-000000000062"), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0062-0062-0062-000000000062"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-1111-1111-1111-111111111101"), 500000.0, new TimeSpan(0, 13, 30, 0, 0), "Completed", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000022") },
                    { new Guid("55555555-5555-5555-5555-000000000043"), "APP202605210043", new Guid("eeeeeeee-0094-0094-0094-000000000094"), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0094-0094-0094-000000000094"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111109"), 650000.0, new TimeSpan(0, 7, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000017") },
                    { new Guid("55555555-5555-5555-5555-000000000044"), "APP202605180044", new Guid("eeeeeeee-0048-0048-0048-000000000048"), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0048-0048-0048-000000000048"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111102"), 2800000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000004") },
                    { new Guid("55555555-5555-5555-5555-000000000045"), "APP202605190045", new Guid("eeeeeeee-0002-0002-0002-000000000002"), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0002-0002-0002-000000000002"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111104"), 650000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000008") },
                    { new Guid("55555555-5555-5555-5555-000000000046"), "APP202605220046", new Guid("eeeeeeee-0027-0027-0027-000000000027"), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0027-0027-0027-000000000027"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-1111-1111-1111-111111111101"), 500000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000022") },
                    { new Guid("55555555-5555-5555-5555-000000000047"), "APP202605240047", new Guid("eeeeeeee-0065-0065-0065-000000000065"), new DateTime(2026, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0065-0065-0065-000000000065"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-1111-1111-1111-222222222201"), 300000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000029") },
                    { new Guid("55555555-5555-5555-5555-000000000048"), "APP202605220048", new Guid("eeeeeeee-0020-0020-0020-000000000020"), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0020-0020-0020-000000000020"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-1111-1111-1111-111111111101"), 500000.0, new TimeSpan(0, 13, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000022") },
                    { new Guid("55555555-5555-5555-5555-000000000049"), "APP202605190049", new Guid("eeeeeeee-0087-0087-0087-000000000087"), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0087-0087-0087-000000000087"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111105"), 1800000.0, new TimeSpan(0, 13, 30, 0, 0), "Pending", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000010") },
                    { new Guid("55555555-5555-5555-5555-000000000050"), "APP202605200050", new Guid("eeeeeeee-0030-0030-0030-000000000030"), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "Khám tổng quát", new Guid("bbbbbbbb-0030-0030-0030-000000000030"), new Guid("00000000-0000-0000-0000-000000000000"), "Level0", new Guid("22222222-3333-3333-3333-111111111107"), 450000.0, new TimeSpan(0, 7, 30, 0, 0), "Approved", "Online", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-8888-8888-8888-000000000013") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000001"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000002"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000003"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000004"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000005"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000006"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000007"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000008"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000009"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000010"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000011"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000012"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000014"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000015"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000016"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000017"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000018"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000019"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000020"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000021"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000022"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000023"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000024"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000025"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000026"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000027"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000028"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000029"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000030"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000031"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000032"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000033"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000034"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000035"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000036"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000037"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000038"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000039"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000040"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000041"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000042"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000043"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000044"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000045"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000046"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000047"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000048"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000049"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000050"));
        }
    }
}
