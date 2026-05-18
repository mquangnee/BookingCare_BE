using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_demo_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenExpiry", "TwoFactorEnabled", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("dddddddd-1000-0000-0000-000000000001"), 0, "dummy-concurrency-001", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.tranvanan@bookingcare.vn", true, true, null, "BS.TRANVANAN@BOOKINGCARE.VN", "BS.TRANVANAN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000001", true, null, "DUMMY_STAMP_001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.tranvanan@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000002"), 0, "dummy-concurrency-002", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.lethimai@bookingcare.vn", true, true, null, "BS.LETHIMAI@BOOKINGCARE.VN", "BS.LETHIMAI@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000002", true, null, "DUMMY_STAMP_002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.lethimai@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000003"), 0, "dummy-concurrency-003", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.phamducminh@bookingcare.vn", true, true, null, "BS.PHAMDUCMINH@BOOKINGCARE.VN", "BS.PHAMDUCMINH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000003", true, null, "DUMMY_STAMP_003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.phamducminh@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000004"), 0, "dummy-concurrency-004", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.nguyenhainam@bookingcare.vn", true, true, null, "BS.NGUYENHAINAM@BOOKINGCARE.VN", "BS.NGUYENHAINAM@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000004", true, null, "DUMMY_STAMP_004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.nguyenhainam@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000005"), 0, "dummy-concurrency-005", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.dinhthuha@bookingcare.vn", true, true, null, "BS.DINHTHUHA@BOOKINGCARE.VN", "BS.DINHTHUHA@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000005", true, null, "DUMMY_STAMP_005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.dinhthuha@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000006"), 0, "dummy-concurrency-006", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.vudinhkhang@bookingcare.vn", true, true, null, "BS.VUDINHKHANG@BOOKINGCARE.VN", "BS.VUDINHKHANG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000006", true, null, "DUMMY_STAMP_006", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.vudinhkhang@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000007"), 0, "dummy-concurrency-007", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.tranquynhchi@bookingcare.vn", true, true, null, "BS.TRANQUYNHCHI@BOOKINGCARE.VN", "BS.TRANQUYNHCHI@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000007", true, null, "DUMMY_STAMP_007", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.tranquynhchi@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000008"), 0, "dummy-concurrency-008", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.levandat@bookingcare.vn", true, true, null, "BS.LEVANDAT@BOOKINGCARE.VN", "BS.LEVANDAT@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000008", true, null, "DUMMY_STAMP_008", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.levandat@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000009"), 0, "dummy-concurrency-009", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.hoangbichngoc@bookingcare.vn", true, true, null, "BS.HOANGBICHNGOC@BOOKINGCARE.VN", "BS.HOANGBICHNGOC@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000009", true, null, "DUMMY_STAMP_009", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.hoangbichngoc@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000010"), 0, "dummy-concurrency-010", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.phantuantu@bookingcare.vn", true, true, null, "BS.PHANTUANTU@BOOKINGCARE.VN", "BS.PHANTUANTU@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000010", true, null, "DUMMY_STAMP_010", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.phantuantu@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000011"), 0, "dummy-concurrency-011", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.truongmylinh@bookingcare.vn", true, true, null, "BS.TRUONGMYLINH@BOOKINGCARE.VN", "BS.TRUONGMYLINH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000011", true, null, "DUMMY_STAMP_011", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.truongmylinh@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000012"), 0, "dummy-concurrency-012", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.dangquocbao@bookingcare.vn", true, true, null, "BS.DANGQUOCBAO@BOOKINGCARE.VN", "BS.DANGQUOCBAO@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000012", true, null, "DUMMY_STAMP_012", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.dangquocbao@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000013"), 0, "dummy-concurrency-013", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.buithanhtruc@bookingcare.vn", true, true, null, "BS.BUITHANHTRUC@BOOKINGCARE.VN", "BS.BUITHANHTRUC@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000013", true, null, "DUMMY_STAMP_013", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.buithanhtruc@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000014"), 0, "dummy-concurrency-014", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.ngotrongtri@bookingcare.vn", true, true, null, "BS.NGOTRONGTRI@BOOKINGCARE.VN", "BS.NGOTRONGTRI@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000014", true, null, "DUMMY_STAMP_014", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.ngotrongtri@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000015"), 0, "dummy-concurrency-015", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.lygiahan@bookingcare.vn", true, true, null, "BS.LYGIAHAN@BOOKINGCARE.VN", "BS.LYGIAHAN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000015", true, null, "DUMMY_STAMP_015", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.lygiahan@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000016"), 0, "dummy-concurrency-016", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.vuthithao@bookingcare.vn", true, true, null, "BS.VUTHITHAO@BOOKINGCARE.VN", "BS.VUTHITHAO@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000016", true, null, "DUMMY_STAMP_016", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.vuthithao@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000017"), 0, "dummy-concurrency-017", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.trananhkhoa@bookingcare.vn", true, true, null, "BS.TRANANHKHOA@BOOKINGCARE.VN", "BS.TRANANHKHOA@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000017", true, null, "DUMMY_STAMP_017", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.trananhkhoa@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000018"), 0, "dummy-concurrency-018", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.letuananh@bookingcare.vn", true, true, null, "BS.LETUANANH@BOOKINGCARE.VN", "BS.LETUANANH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000018", true, null, "DUMMY_STAMP_018", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.letuananh@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000019"), 0, "dummy-concurrency-019", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.nguyenyennhi@bookingcare.vn", true, true, null, "BS.NGUYENYENNHI@BOOKINGCARE.VN", "BS.NGUYENYENNHI@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000019", true, null, "DUMMY_STAMP_019", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.nguyenyennhi@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000020"), 0, "dummy-concurrency-020", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.phamminhphuong@bookingcare.vn", true, true, null, "BS.PHAMMINHPHUONG@BOOKINGCARE.VN", "BS.PHAMMINHPHUONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000020", true, null, "DUMMY_STAMP_020", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.phamminhphuong@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000021"), 0, "dummy-concurrency-021", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.tranhuuloc@bookingcare.vn", true, true, null, "BS.TRANHUULOC@BOOKINGCARE.VN", "BS.TRANHUULOC@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000021", true, null, "DUMMY_STAMP_021", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.tranhuuloc@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000022"), 0, "dummy-concurrency-022", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.dinhquangdai@bookingcare.vn", true, true, null, "BS.DINHQUANGDAI@BOOKINGCARE.VN", "BS.DINHQUANGDAI@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000022", true, null, "DUMMY_STAMP_022", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.dinhquangdai@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000023"), 0, "dummy-concurrency-023", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.lephuongoanh@bookingcare.vn", true, true, null, "BS.LEPHUONGOANH@BOOKINGCARE.VN", "BS.LEPHUONGOANH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000023", true, null, "DUMMY_STAMP_023", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.lephuongoanh@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000024"), 0, "dummy-concurrency-024", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.vungochung@bookingcare.vn", true, true, null, "BS.VUNGOCHUNG@BOOKINGCARE.VN", "BS.VUNGOCHUNG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000024", true, null, "DUMMY_STAMP_024", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.vungochung@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000025"), 0, "dummy-concurrency-025", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.hoanganhthu@bookingcare.vn", true, true, null, "BS.HOANGANHTHU@BOOKINGCARE.VN", "BS.HOANGANHTHU@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000025", true, null, "DUMMY_STAMP_025", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.hoanganhthu@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000026"), 0, "dummy-concurrency-026", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.phannhatminh@bookingcare.vn", true, true, null, "BS.PHANNHATMINH@BOOKINGCARE.VN", "BS.PHANNHATMINH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000026", true, null, "DUMMY_STAMP_026", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.phannhatminh@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000027"), 0, "dummy-concurrency-027", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.truongquocviet@bookingcare.vn", true, true, null, "BS.TRUONGQUOCVIET@BOOKINGCARE.VN", "BS.TRUONGQUOCVIET@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000027", true, null, "DUMMY_STAMP_027", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.truongquocviet@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000028"), 0, "dummy-concurrency-028", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.dangthuthuy@bookingcare.vn", true, true, null, "BS.DANGTHUTHUY@BOOKINGCARE.VN", "BS.DANGTHUTHUY@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000028", true, null, "DUMMY_STAMP_028", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.dangthuthuy@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000029"), 0, "dummy-concurrency-029", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.buingochuyen@bookingcare.vn", true, true, null, "BS.BUINGOCHUYEN@BOOKINGCARE.VN", "BS.BUINGOCHUYEN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000029", true, null, "DUMMY_STAMP_029", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.buingochuyen@bookingcare.vn" },
                    { new Guid("dddddddd-1000-0000-0000-000000000030"), 0, "dummy-concurrency-030", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.lamtanphat@bookingcare.vn", true, true, null, "BS.LAMTANPHAT@BOOKINGCARE.VN", "BS.LAMTANPHAT@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0911000030", true, null, "DUMMY_STAMP_030", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.lamtanphat@bookingcare.vn" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedDate", "Description", "DoctorId", "DurationInMinutes", "IsActive", "Name", "Position", "Price", "ServiceCode", "SpecialtyId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("22222222-4444-4444-4444-111111111101"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Chụp X-quang khớp gối kỹ thuật số để đánh giá tình trạng thoái hóa, gai xương.", null, 15, true, "Chụp X-Quang khớp gối", null, 200000.0, "SRV-DV-XQUANG-KHOP", new Guid("11111111-1111-1111-1111-111111111101"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111102"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra tình trạng loãng xương bằng phương pháp DEXA toàn thân.", null, 20, true, "Đo mật độ xương (DEXA)", null, 350000.0, "SRV-DV-DO-LOANGXUONG", new Guid("11111111-1111-1111-1111-111111111101"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111103"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám tổng quát và tư vấn các bệnh lý đường tiêu hóa thông thường.", null, 15, true, "Khám Bác sĩ - Nội tiêu hóa", "Doctor", 200000.0, "SRV-KHAM-CK02-BS", new Guid("11111111-1111-1111-1111-111111111102"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111104"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra vi khuẩn Helicobacter Pylori qua hơi thở, không cần nội soi, an toàn và chính xác.", null, 30, true, "Test hơi thở tìm vi khuẩn HP (C13)", null, 650000.0, "SRV-DV-TESTHP", new Guid("11111111-1111-1111-1111-111111111102"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111105"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Ghi lại hoạt động điện của tim, giúp phát hiện rối loạn nhịp tim và nhồi máu cơ tim.", null, 15, true, "Đo điện tâm đồ (ECG)", null, 150000.0, "SRV-DV-ECG", new Guid("11111111-1111-1111-1111-111111111103"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111106"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám lâm sàng đánh giá nguy cơ đột quỵ và tư vấn các chỉ định cận lâm sàng cần thiết.", null, 30, true, "Khám Thạc sĩ - Tầm soát đột quỵ", "Master", 350000.0, "SRV-KHAM-CK03-THS", new Guid("11111111-1111-1111-1111-111111111103"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111107"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám và tư vấn sức khỏe sinh sản trước khi kết hôn cho nữ giới.", null, 30, true, "Khám tiền hôn nhân (Nữ)", "Doctor", 250000.0, "SRV-KHAM-TIENHONNHAN", new Guid("11111111-1111-1111-1111-111111111104"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111108"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Siêu âm đầu dò âm đạo theo dõi sự phát triển của nang noãn, hỗ trợ thụ thai.", null, 15, true, "Siêu âm canh trứng", null, 200000.0, "SRV-DV-CANHTRUNG", new Guid("11111111-1111-1111-1111-111111111104"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111109"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Đánh giá thể trạng, lên thực đơn và tư vấn chế độ ăn dặm, khắc phục biếng ăn.", null, 20, true, "Khám và tư vấn dinh dưỡng cho bé", "Master", 300000.0, "SRV-KHAM-DINHDUONG", new Guid("11111111-1111-1111-1111-111111111105"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111110"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Thủ thuật làm sạch đường thở cho trẻ bị viêm hô hấp, viêm phế quản.", null, 15, true, "Hút đờm dãi, vệ sinh mũi họng trẻ em", null, 150000.0, "SRV-DV-HUTDOM", new Guid("11111111-1111-1111-1111-111111111105"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111111"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Làm sạch sâu, lấy nhân mụn bằng tăm bông vô khuẩn và chiếu đèn sinh học giảm sưng viêm.", null, 45, true, "Lấy nhân mụn chuẩn y khoa", null, 450000.0, "SRV-DV-LAYNHANMUN", new Guid("11111111-1111-1111-1111-111111111106"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111112"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Đánh giá chi tiết cấu trúc da, độ ẩm, sắc tố và lỗ chân lông.", null, 15, true, "Soi da kỹ thuật số phân tích 3D", null, 100000.0, "SRV-DV-SOIDA", new Guid("11111111-1111-1111-1111-111111111106"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111113"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám và nội soi NBI phát hiện sớm các dấu hiệu bất thường vùng vòm họng.", null, 20, true, "Khám Tiến sĩ - Tầm soát ung thư vòm họng", "DoctorOfPhilosophy", 450000.0, "SRV-KHAM-CK07-TS", new Guid("11111111-1111-1111-1111-111111111107"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111114"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Xử lý các trường hợp hóc xương, dị vật chui vào tai hoặc mũi an toàn, nhanh chóng.", null, 15, true, "Gắp dị vật Tai/Mũi/Họng", null, 300000.0, "SRV-DV-LAYDIVAT", new Guid("11111111-1111-1111-1111-111111111107"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111115"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Đo thị lực, kiểm tra cận, viễn, loạn thị bằng máy điện tử.", null, 20, true, "Đo khúc xạ mắt", null, 150000.0, "SRV-DV-DOKHUCXA", new Guid("11111111-1111-1111-1111-111111111108"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111116"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Lấy bụi, phoi sắt hoặc côn trùng vào mắt dưới kính sinh hiển vi.", null, 15, true, "Lấy dị vật kết mạc, giác mạc", null, 250000.0, "SRV-DV-LAYDIVATMAT", new Guid("11111111-1111-1111-1111-111111111108"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111117"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Thăm khám, đánh giá tâm lý và tư vấn phác đồ điều trị mất ngủ mạn tính.", null, 20, true, "Khám Thạc sĩ - Rối loạn giấc ngủ", "Master", 350000.0, "SRV-KHAM-CK09-THS", new Guid("11111111-1111-1111-1111-111111111109"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111118"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Đánh giá tình trạng tuần hoàn máu não, phát hiện thiểu năng tuần hoàn não.", null, 30, true, "Đo lưu huyết não", null, 200000.0, "SRV-DV-LUUHUYETNAO", new Guid("11111111-1111-1111-1111-111111111109"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111119"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Lấy sạch mảng bám, vôi răng bằng sóng siêu âm không ê buốt và đánh bóng bề mặt răng.", null, 30, true, "Cạo vôi răng và đánh bóng", null, 250000.0, "SRV-DV-CAOVOI", new Guid("11111111-1111-1111-1111-111111111110"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-4444-4444-4444-111111111120"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Phục hình răng sâu, sứt mẻ bằng vật liệu Composite trùng màu răng thật.", null, 45, true, "Trám răng thẩm mỹ Composite", null, 300000.0, "SRV-DV-TRAMRANG", new Guid("11111111-1111-1111-1111-111111111110"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "WorkSessions",
                columns: new[] { "Id", "CreatedDate", "Date", "DoctorId", "EndTime", "ServiceId", "StartTime", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("44444444-8888-8888-8888-000000000001"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1111-1111-1111-111111111111"), new TimeSpan(0, 12, 0, 0, 0), new Guid("22222222-3333-3333-3333-111111111101"), new TimeSpan(0, 7, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000002"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1111-1111-1111-111111111111"), new TimeSpan(0, 17, 30, 0, 0), new Guid("22222222-3333-3333-3333-111111111101"), new TimeSpan(0, 13, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000003"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-2222-2222-2222-222222222222"), new TimeSpan(0, 12, 0, 0, 0), new Guid("22222222-3333-3333-3333-111111111102"), new TimeSpan(0, 7, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000004"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-2222-2222-2222-222222222222"), new TimeSpan(0, 17, 30, 0, 0), new Guid("22222222-3333-3333-3333-111111111102"), new TimeSpan(0, 13, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000005"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), new TimeSpan(0, 12, 0, 0, 0), new Guid("22222222-3333-3333-3333-111111111103"), new TimeSpan(0, 7, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000006"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), new TimeSpan(0, 17, 30, 0, 0), new Guid("22222222-3333-3333-3333-111111111103"), new TimeSpan(0, 13, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000007"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-4444-4444-4444-444444444444"), new TimeSpan(0, 12, 0, 0, 0), new Guid("22222222-3333-3333-3333-111111111104"), new TimeSpan(0, 7, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000008"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-4444-4444-4444-444444444444"), new TimeSpan(0, 17, 30, 0, 0), new Guid("22222222-3333-3333-3333-111111111104"), new TimeSpan(0, 13, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000009"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-5555-5555-5555-555555555555"), new TimeSpan(0, 12, 0, 0, 0), new Guid("22222222-3333-3333-3333-111111111105"), new TimeSpan(0, 7, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000010"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-5555-5555-5555-555555555555"), new TimeSpan(0, 17, 30, 0, 0), new Guid("22222222-3333-3333-3333-111111111105"), new TimeSpan(0, 13, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000011"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-6666-6666-6666-666666666666"), new TimeSpan(0, 12, 0, 0, 0), new Guid("22222222-3333-3333-3333-111111111106"), new TimeSpan(0, 7, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000012"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-6666-6666-6666-666666666666"), new TimeSpan(0, 17, 30, 0, 0), new Guid("22222222-3333-3333-3333-111111111106"), new TimeSpan(0, 13, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000013"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-7777-7777-7777-777777777777"), new TimeSpan(0, 12, 0, 0, 0), new Guid("22222222-3333-3333-3333-111111111107"), new TimeSpan(0, 7, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000014"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-7777-7777-7777-777777777777"), new TimeSpan(0, 17, 30, 0, 0), new Guid("22222222-3333-3333-3333-111111111107"), new TimeSpan(0, 13, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000015"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-8888-8888-8888-888888888888"), new TimeSpan(0, 12, 0, 0, 0), new Guid("22222222-3333-3333-3333-111111111108"), new TimeSpan(0, 7, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000016"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-8888-8888-8888-888888888888"), new TimeSpan(0, 17, 30, 0, 0), new Guid("22222222-3333-3333-3333-111111111108"), new TimeSpan(0, 13, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000017"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-9999-9999-9999-999999999999"), new TimeSpan(0, 12, 0, 0, 0), new Guid("22222222-3333-3333-3333-111111111109"), new TimeSpan(0, 7, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000018"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-9999-9999-9999-999999999999"), new TimeSpan(0, 17, 30, 0, 0), new Guid("22222222-3333-3333-3333-111111111109"), new TimeSpan(0, 13, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000019"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-0000-0000-0000-000000000000"), new TimeSpan(0, 12, 0, 0, 0), new Guid("22222222-3333-3333-3333-111111111110"), new TimeSpan(0, 7, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000020"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-0000-0000-0000-000000000000"), new TimeSpan(0, 17, 30, 0, 0), new Guid("22222222-3333-3333-3333-111111111110"), new TimeSpan(0, 13, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "AvatarUrl", "CitizenId", "DateOfBirth", "Description", "DoctorCode", "ExperienceYears", "FullName", "Gender", "Position", "ServiceId", "SpecialtyId", "UserId", "WorkingHistory" },
                values: new object[,]
                {
                    { new Guid("33333333-1000-0000-0000-000000000001"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_1.jpg", "001080000011", new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ có nhiều năm kinh nghiệm trong khám Cơ Xương Khớp.", "BS-011", 20, "Trần Văn An", "Male", "Doctor", new Guid("22222222-1111-1111-1111-111111111101"), new Guid("11111111-1111-1111-1111-111111111101"), new Guid("dddddddd-1000-0000-0000-000000000001"), "Bệnh viện Đa khoa Tâm Anh" },
                    { new Guid("33333333-1000-0000-0000-000000000002"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_1.jpg", "001085000012", new DateTime(1985, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ tận tâm, giỏi chuyên môn, chuyên điều trị thoái hóa khớp cơ bản.", "BS-012", 15, "Lê Thị Mai", "Female", "Master", new Guid("22222222-1111-1111-1111-222222222201"), new Guid("11111111-1111-1111-1111-111111111101"), new Guid("dddddddd-1000-0000-0000-000000000002"), "Bệnh viện Bạch Mai" },
                    { new Guid("33333333-1000-0000-0000-000000000003"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_2.jpg", "001082000013", new DateTime(1982, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia về các thủ thuật tiêm nội khớp và bôi trơn khớp gối.", "BS-013", 17, "Phạm Đức Minh", "Male", "Doctor", new Guid("22222222-3333-3333-3333-111111111101"), new Guid("11111111-1111-1111-1111-111111111101"), new Guid("dddddddd-1000-0000-0000-000000000003"), "Bệnh viện Đại học Y Hà Nội" },
                    { new Guid("33333333-1000-0000-0000-000000000004"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_3.jpg", "001078000014", new DateTime(1978, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia tư vấn và chẩn đoán các bệnh lý Tiêu hóa, men gan.", "BS-014", 22, "Nguyễn Hải Nam", "Male", "Master", new Guid("22222222-1111-1111-1111-111111111102"), new Guid("11111111-1111-1111-1111-111111111102"), new Guid("dddddddd-1000-0000-0000-000000000004"), "Bệnh viện Chợ Rẫy" },
                    { new Guid("33333333-1000-0000-0000-000000000005"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_2.jpg", "001075000015", new DateTime(1975, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giáo sư đầu ngành với thế mạnh chẩn đoán chuyên sâu hệ Tiêu hóa.", "BS-015", 25, "Đinh Thu Hà", "Female", "Professor", new Guid("22222222-1111-1111-1111-222222222202"), new Guid("11111111-1111-1111-1111-111111111102"), new Guid("dddddddd-1000-0000-0000-000000000005"), "Bệnh viện E" },
                    { new Guid("33333333-1000-0000-0000-000000000006"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_4.jpg", "001083000016", new DateTime(1983, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thế mạnh về thủ thuật nội soi gây mê an toàn, không đau.", "BS-016", 17, "Vũ Đình Khang", "Male", "Doctor", new Guid("22222222-3333-3333-3333-111111111102"), new Guid("11111111-1111-1111-1111-111111111102"), new Guid("dddddddd-1000-0000-0000-000000000006"), "Bệnh viện Việt Đức" },
                    { new Guid("33333333-1000-0000-0000-000000000007"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_3.jpg", "001081000017", new DateTime(1981, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiến sĩ Tim mạch lâm sàng, tầm soát cao huyết áp xuất sắc.", "BS-017", 18, "Trần Quỳnh Chi", "Female", "DoctorOfPhilosophy", new Guid("22222222-1111-1111-1111-111111111103"), new Guid("11111111-1111-1111-1111-111111111103"), new Guid("dddddddd-1000-0000-0000-000000000007"), "Bệnh viện Tim Hà Nội" },
                    { new Guid("33333333-1000-0000-0000-000000000008"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_5.jpg", "001079000018", new DateTime(1979, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ uy tín trong đánh giá và quản lý bệnh mạch vành.", "BS-018", 21, "Lê Văn Đạt", "Male", "DoctorOfPhilosophy", new Guid("22222222-1111-1111-1111-111111111103"), new Guid("11111111-1111-1111-1111-111111111103"), new Guid("dddddddd-1000-0000-0000-000000000008"), "Viện Tim Quốc Gia" },
                    { new Guid("33333333-1000-0000-0000-000000000009"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_4.jpg", "001086000019", new DateTime(1986, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kinh nghiệm thực hiện siêu âm tim Doppler màu cho độ chính xác cao.", "BS-019", 14, "Hoàng Bích Ngọc", "Female", "Doctor", new Guid("22222222-3333-3333-3333-111111111103"), new Guid("11111111-1111-1111-1111-111111111103"), new Guid("dddddddd-1000-0000-0000-000000000009"), "Bệnh viện Xanh Pôn" },
                    { new Guid("33333333-1000-0000-0000-000000000010"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_6.jpg", "001088000020", new DateTime(1988, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia khám Sản Phụ khoa tổng quát và viêm nhiễm phụ khoa.", "BS-020", 12, "Phan Tuấn Tú", "Male", "Doctor", new Guid("22222222-1111-1111-1111-111111111104"), new Guid("11111111-1111-1111-1111-111111111104"), new Guid("dddddddd-1000-0000-0000-000000000010"), "Bệnh viện Phụ Sản Hà Nội" },
                    { new Guid("33333333-1000-0000-0000-000000000011"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_1.jpg", "001084000021", new DateTime(1984, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ có tay nghề cao trong siêu âm thai hình thái học 5D.", "BS-021", 16, "Trương Mỹ Linh", "Female", "Master", new Guid("22222222-3333-3333-3333-111111111104"), new Guid("11111111-1111-1111-1111-111111111104"), new Guid("dddddddd-1000-0000-0000-000000000011"), "Bệnh viện Phụ Sản Trung Ương" },
                    { new Guid("33333333-1000-0000-0000-000000000012"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_7.jpg", "001077000022", new DateTime(1977, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thế mạnh thực hiện các thủ thuật phụ khoa: áp lạnh, cầm máu.", "BS-022", 23, "Đặng Quốc Bảo", "Male", "Doctor", new Guid("22222222-3333-3333-3333-222222222204"), new Guid("11111111-1111-1111-1111-111111111104"), new Guid("dddddddd-1000-0000-0000-000000000012"), "Bệnh viện Bưu Điện" },
                    { new Guid("33333333-1000-0000-0000-000000000013"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_2.jpg", "001072000023", new DateTime(1972, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giáo sư chuyên khoa Nhi, giải quyết tốt các ca bệnh lý trẻ em hô hấp khó.", "BS-023", 27, "Bùi Thanh Trúc", "Female", "Professor", new Guid("22222222-1111-1111-1111-111111111105"), new Guid("11111111-1111-1111-1111-111111111105"), new Guid("dddddddd-1000-0000-0000-000000000013"), "Bệnh viện Nhi Trung Ương" },
                    { new Guid("33333333-1000-0000-0000-000000000014"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_8.jpg", "001076000024", new DateTime(1976, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giáo sư giàu kinh nghiệm, chuyên trị các ca bệnh lý nhi phức tạp.", "BS-024", 24, "Ngô Trọng Trí", "Male", "Professor", new Guid("22222222-1111-1111-1111-111111111105"), new Guid("11111111-1111-1111-1111-111111111105"), new Guid("dddddddd-1000-0000-0000-000000000014"), "Bệnh viện Nhi đồng 1" },
                    { new Guid("33333333-1000-0000-0000-000000000015"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_3.jpg", "001087000025", new DateTime(1987, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia phân tích dị ứng và test lẩy da tìm dị nguyên.", "BS-025", 13, "Lý Gia Hân", "Female", "Doctor", new Guid("22222222-3333-3333-3333-111111111105"), new Guid("11111111-1111-1111-1111-111111111105"), new Guid("dddddddd-1000-0000-0000-000000000015"), "Bệnh viện Đa khoa Tâm Anh" },
                    { new Guid("33333333-1000-0000-0000-000000000016"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_4.jpg", "001089000026", new DateTime(1989, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ Da liễu tận tình, chuyên tư vấn chăm sóc da chuẩn y khoa.", "BS-026", 11, "Vũ Thị Thảo", "Female", "Master", new Guid("22222222-1111-1111-1111-111111111106"), new Guid("11111111-1111-1111-1111-111111111106"), new Guid("dddddddd-1000-0000-0000-000000000016"), "Bệnh viện Da liễu Trung Ương" },
                    { new Guid("33333333-1000-0000-0000-000000000017"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_1.jpg", "001085000027", new DateTime(1985, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kinh nghiệm điều trị các bệnh mụn, nám, và viêm da lâu năm.", "BS-027", 15, "Trần Anh Khoa", "Male", "Master", new Guid("22222222-1111-1111-1111-111111111106"), new Guid("11111111-1111-1111-1111-111111111106"), new Guid("dddddddd-1000-0000-0000-000000000017"), "Bệnh viện Da liễu Hà Nội" },
                    { new Guid("33333333-1000-0000-0000-000000000018"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_2.jpg", "001082000028", new DateTime(1982, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia bắn Laser CO2 trị sẹo rỗ chuyên sâu, hiệu quả.", "BS-028", 18, "Lê Tuấn Anh", "Male", "Doctor", new Guid("22222222-3333-3333-3333-111111111106"), new Guid("11111111-1111-1111-1111-111111111106"), new Guid("dddddddd-1000-0000-0000-000000000018"), "Viện Thẩm mỹ Y khoa" },
                    { new Guid("33333333-1000-0000-0000-000000000019"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_1.jpg", "001078000029", new DateTime(1978, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phó Giáo sư chỉ định và trực tiếp phẫu thuật cắt Amidan chuyên môn cao.", "BS-029", 22, "Nguyễn Yến Nhi", "Female", "AssociateProfessor", new Guid("22222222-1111-1111-1111-111111111107"), new Guid("11111111-1111-1111-1111-111111111107"), new Guid("dddddddd-1000-0000-0000-000000000019"), "Bệnh viện Tai Mũi Họng Trung Ương" },
                    { new Guid("33333333-1000-0000-0000-000000000020"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_2.jpg", "001075000030", new DateTime(1975, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ giàu kinh nghiệm về bệnh lý Tai Mũi Họng người lớn và trẻ nhỏ.", "BS-030", 25, "Phạm Minh Phương", "Female", "AssociateProfessor", new Guid("22222222-1111-1111-1111-111111111107"), new Guid("11111111-1111-1111-1111-111111111107"), new Guid("dddddddd-1000-0000-0000-000000000020"), "Bệnh viện Bạch Mai" },
                    { new Guid("33333333-1000-0000-0000-000000000021"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_3.jpg", "001084000031", new DateTime(1984, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ có nhiều kinh nghiệm sử dụng kĩ thuật nội soi ống mềm không buồn nôn.", "BS-031", 16, "Trần Hữu Lộc", "Male", "Doctor", new Guid("22222222-3333-3333-3333-111111111107"), new Guid("11111111-1111-1111-1111-111111111107"), new Guid("dddddddd-1000-0000-0000-000000000021"), "Bệnh viện 108" },
                    { new Guid("33333333-1000-0000-0000-000000000022"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_4.jpg", "001080000032", new DateTime(1980, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia về đáy mắt, tư vấn kỹ lưỡng các vấn đề về võng mạc.", "BS-032", 20, "Đinh Quang Đại", "Male", "DoctorOfPhilosophy", new Guid("22222222-1111-1111-1111-111111111108"), new Guid("11111111-1111-1111-1111-111111111108"), new Guid("dddddddd-1000-0000-0000-000000000022"), "Bệnh viện Mắt Trung Ương" },
                    { new Guid("33333333-1000-0000-0000-000000000023"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_3.jpg", "001083000033", new DateTime(1983, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiến sĩ có tay nghề cao trong khám điều trị các tật khúc xạ.", "BS-033", 17, "Lê Phương Oanh", "Female", "DoctorOfPhilosophy", new Guid("22222222-1111-1111-1111-111111111108"), new Guid("11111111-1111-1111-1111-111111111108"), new Guid("dddddddd-1000-0000-0000-000000000023"), "Bệnh viện Mắt Sài Gòn" },
                    { new Guid("33333333-1000-0000-0000-000000000024"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_5.jpg", "001086000034", new DateTime(1986, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chụp và đọc kết quả cắt lớp võng mạc OCT vô cùng chuẩn xác.", "BS-034", 14, "Vũ Ngọc Hùng", "Male", "Doctor", new Guid("22222222-3333-3333-3333-111111111108"), new Guid("11111111-1111-1111-1111-111111111108"), new Guid("dddddddd-1000-0000-0000-000000000024"), "Bệnh viện Đại học Y Dược" },
                    { new Guid("33333333-1000-0000-0000-000000000025"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_4.jpg", "001072000035", new DateTime(1972, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phó giáo sư Nội thần kinh, đặc trị mất ngủ và rối loạn tiền đình.", "BS-035", 28, "Hoàng Anh Thư", "Female", "AssociateProfessor", new Guid("22222222-1111-1111-1111-111111111109"), new Guid("11111111-1111-1111-1111-111111111109"), new Guid("dddddddd-1000-0000-0000-000000000025"), "Bệnh viện Chợ Rẫy" },
                    { new Guid("33333333-1000-0000-0000-000000000026"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_6.jpg", "001076000036", new DateTime(1976, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia dày dạn kinh nghiệm về các bệnh lý đau đầu mạn tính.", "BS-036", 24, "Phan Nhật Minh", "Male", "AssociateProfessor", new Guid("22222222-1111-1111-1111-111111111109"), new Guid("11111111-1111-1111-1111-111111111109"), new Guid("dddddddd-1000-0000-0000-000000000026"), "Bệnh viện Quân Y 103" },
                    { new Guid("33333333-1000-0000-0000-000000000027"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_7.jpg", "001085000037", new DateTime(1985, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên chẩn đoán điện não đồ (EEG) tìm nguyên nhân bệnh lý.", "BS-037", 15, "Trương Quốc Việt", "Male", "Doctor", new Guid("22222222-3333-3333-3333-111111111109"), new Guid("11111111-1111-1111-1111-111111111109"), new Guid("dddddddd-1000-0000-0000-000000000027"), "Bệnh viện Hữu nghị Việt Đức" },
                    { new Guid("33333333-1000-0000-0000-000000000028"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_1.jpg", "001088000038", new DateTime(1988, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ Răng Hàm Mặt tận tâm, nhẹ nhàng trong lên phác đồ niềng răng.", "BS-038", 12, "Đặng Thu Thủy", "Female", "Master", new Guid("22222222-1111-1111-1111-111111111110"), new Guid("11111111-1111-1111-1111-111111111110"), new Guid("dddddddd-1000-0000-0000-000000000028"), "Nha Khoa Quốc Tế" },
                    { new Guid("33333333-1000-0000-0000-000000000029"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_2.jpg", "001090000039", new DateTime(1990, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thế mạnh thực hiện các ca nhổ răng khôn Piezotome không đau.", "BS-039", 10, "Bùi Ngọc Huyền", "Female", "Doctor", new Guid("22222222-3333-3333-3333-111111111110"), new Guid("11111111-1111-1111-1111-111111111110"), new Guid("dddddddd-1000-0000-0000-000000000029"), "Bệnh viện Răng Hàm Mặt Trung Ương" },
                    { new Guid("33333333-1000-0000-0000-000000000030"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_8.jpg", "001087000040", new DateTime(1987, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nha sĩ thẩm mỹ chuyên tẩy trắng răng và phục hình.", "BS-040", 13, "Lâm Tấn Phát", "Male", "Doctor", new Guid("22222222-3333-3333-3333-222222222210"), new Guid("11111111-1111-1111-1111-111111111110"), new Guid("dddddddd-1000-0000-0000-000000000030"), "Phòng khám Đa khoa Quốc tế" }
                });

            migrationBuilder.InsertData(
                table: "WorkSessions",
                columns: new[] { "Id", "CreatedDate", "Date", "DoctorId", "EndTime", "ServiceId", "StartTime", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("44444444-8888-8888-8888-000000000021"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1000-0000-0000-000000000001"), new TimeSpan(0, 12, 0, 0, 0), new Guid("22222222-1111-1111-1111-111111111101"), new TimeSpan(0, 7, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000022"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1000-0000-0000-000000000001"), new TimeSpan(0, 17, 30, 0, 0), new Guid("22222222-1111-1111-1111-111111111101"), new TimeSpan(0, 13, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000023"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1000-0000-0000-000000000002"), new TimeSpan(0, 12, 0, 0, 0), new Guid("22222222-1111-1111-1111-222222222201"), new TimeSpan(0, 7, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000024"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1000-0000-0000-000000000002"), new TimeSpan(0, 17, 30, 0, 0), new Guid("22222222-1111-1111-1111-222222222201"), new TimeSpan(0, 13, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000025"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1000-0000-0000-000000000003"), new TimeSpan(0, 12, 0, 0, 0), new Guid("22222222-3333-3333-3333-111111111101"), new TimeSpan(0, 7, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000026"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1000-0000-0000-000000000003"), new TimeSpan(0, 17, 30, 0, 0), new Guid("22222222-3333-3333-3333-111111111101"), new TimeSpan(0, 13, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000027"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1000-0000-0000-000000000004"), new TimeSpan(0, 12, 0, 0, 0), new Guid("22222222-1111-1111-1111-111111111102"), new TimeSpan(0, 7, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000028"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1000-0000-0000-000000000004"), new TimeSpan(0, 17, 30, 0, 0), new Guid("22222222-1111-1111-1111-111111111102"), new TimeSpan(0, 13, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000029"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1000-0000-0000-000000000005"), new TimeSpan(0, 12, 0, 0, 0), new Guid("22222222-1111-1111-1111-222222222202"), new TimeSpan(0, 7, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-8888-8888-8888-000000000030"), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1000-0000-0000-000000000005"), new TimeSpan(0, 17, 30, 0, 0), new Guid("22222222-1111-1111-1111-222222222202"), new TimeSpan(0, 13, 30, 0, 0), new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111101"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111102"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111103"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111104"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111105"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111106"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111107"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111108"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111109"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111110"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111111"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111112"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111113"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111114"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111115"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111116"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111117"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111118"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111119"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-4444-4444-4444-111111111120"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000001"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000002"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000003"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000004"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000005"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000006"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000007"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000008"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000009"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000010"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000011"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000012"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000013"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000014"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000015"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000016"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000017"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000018"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000019"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000020"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000021"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000022"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000023"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000024"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000025"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000026"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000027"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000028"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000029"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-8888-8888-8888-000000000030"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1000-0000-0000-000000000005"));
        }
    }
}
