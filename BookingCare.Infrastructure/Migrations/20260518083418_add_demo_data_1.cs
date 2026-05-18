using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_demo_data_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenExpiry", "TwoFactorEnabled", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("eeeeeeee-0001-0001-0001-000000000001"), 0, "c1a2b3d4-0001-0001-0001-ef1234567890", new DateTime(2026, 1, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.vanminh@bookingcare.vn", true, true, null, "NGUYEN.VANMINH@BOOKINGCARE.VN", "NGUYEN.VANMINH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000001", true, null, "STAMP000000000001", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 1, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.vanminh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0002-0002-0002-000000000002"), 0, "c1a2b3d4-0002-0002-0002-ef1234567890", new DateTime(2026, 1, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.thihoa@bookingcare.vn", true, true, null, "TRAN.THIHOA@BOOKINGCARE.VN", "TRAN.THIHOA@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000002", true, null, "STAMP000000000002", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 1, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.thihoa@bookingcare.vn" },
                    { new Guid("eeeeeeee-0003-0003-0003-000000000003"), 0, "c1a2b3d4-0003-0003-0003-ef1234567890", new DateTime(2026, 1, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.quocbao@bookingcare.vn", true, true, null, "LE.QUOCBAO@BOOKINGCARE.VN", "LE.QUOCBAO@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000003", true, null, "STAMP000000000003", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 1, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.quocbao@bookingcare.vn" },
                    { new Guid("eeeeeeee-0004-0004-0004-000000000004"), 0, "c1a2b3d4-0004-0004-0004-ef1234567890", new DateTime(2026, 1, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.ngoclan@bookingcare.vn", true, true, null, "PHAM.NGOCLAN@BOOKINGCARE.VN", "PHAM.NGOCLAN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000004", true, null, "STAMP000000000004", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 1, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.ngoclan@bookingcare.vn" },
                    { new Guid("eeeeeeee-0005-0005-0005-000000000005"), 0, "c1a2b3d4-0005-0005-0005-ef1234567890", new DateTime(2026, 1, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "hoang.tiendat@bookingcare.vn", true, true, null, "HOANG.TIENDAT@BOOKINGCARE.VN", "HOANG.TIENDAT@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000005", true, null, "STAMP000000000005", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 1, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "hoang.tiendat@bookingcare.vn" },
                    { new Guid("eeeeeeee-0006-0006-0006-000000000006"), 0, "c1a2b3d4-0006-0006-0006-ef1234567890", new DateTime(2026, 1, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), "vo.thithanh@bookingcare.vn", true, true, null, "VO.THITHANH@BOOKINGCARE.VN", "VO.THITHANH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000006", true, null, "STAMP000000000006", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 1, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), "vo.thithanh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0007-0007-0007-000000000007"), 0, "c1a2b3d4-0007-0007-0007-ef1234567890", new DateTime(2026, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "dang.hunganh@bookingcare.vn", true, true, null, "DANG.HUNGANH@BOOKINGCARE.VN", "DANG.HUNGANH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000007", true, null, "STAMP000000000007", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "dang.hunganh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0008-0008-0008-000000000008"), 0, "c1a2b3d4-0008-0008-0008-ef1234567890", new DateTime(2026, 1, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), "bui.thanhtung@bookingcare.vn", true, true, null, "BUI.THANHTUNG@BOOKINGCARE.VN", "BUI.THANHTUNG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000008", true, null, "STAMP000000000008", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 1, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), "bui.thanhtung@bookingcare.vn" },
                    { new Guid("eeeeeeee-0009-0009-0009-000000000009"), 0, "c1a2b3d4-0009-0009-0009-ef1234567890", new DateTime(2026, 1, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), "do.thimylinh@bookingcare.vn", true, true, null, "DO.THIMYLINH@BOOKINGCARE.VN", "DO.THIMYLINH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000009", true, null, "STAMP000000000009", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 1, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), "do.thimylinh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0010-0010-0010-000000000010"), 0, "c1a2b3d4-0010-0010-0010-ef1234567890", new DateTime(2026, 1, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.phuongnhi@bookingcare.vn", true, true, null, "NGUYEN.PHUONGNHI@BOOKINGCARE.VN", "NGUYEN.PHUONGNHI@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000010", true, null, "STAMP000000000010", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 1, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.phuongnhi@bookingcare.vn" },
                    { new Guid("eeeeeeee-0011-0011-0011-000000000011"), 0, "c1a2b3d4-0011-0011-0011-ef1234567890", new DateTime(2026, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.vanlong@bookingcare.vn", true, true, null, "TRAN.VANLONG@BOOKINGCARE.VN", "TRAN.VANLONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000011", true, null, "STAMP000000000011", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.vanlong@bookingcare.vn" },
                    { new Guid("eeeeeeee-0012-0012-0012-000000000012"), 0, "c1a2b3d4-0012-0012-0012-ef1234567890", new DateTime(2026, 1, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.thidiemhuong@bookingcare.vn", true, true, null, "LE.THIDIEMHUONG@BOOKINGCARE.VN", "LE.THIDIEMHUONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000012", true, null, "STAMP000000000012", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 1, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.thidiemhuong@bookingcare.vn" },
                    { new Guid("eeeeeeee-0013-0013-0013-000000000013"), 0, "c1a2b3d4-0013-0013-0013-ef1234567890", new DateTime(2026, 1, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.trongnghia@bookingcare.vn", true, true, null, "PHAM.TRONGNGHIA@BOOKINGCARE.VN", "PHAM.TRONGNGHIA@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000013", true, null, "STAMP000000000013", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 1, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.trongnghia@bookingcare.vn" },
                    { new Guid("eeeeeeee-0014-0014-0014-000000000014"), 0, "c1a2b3d4-0014-0014-0014-ef1234567890", new DateTime(2026, 1, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), "hoang.kimchi@bookingcare.vn", true, true, null, "HOANG.KIMCHI@BOOKINGCARE.VN", "HOANG.KIMCHI@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000014", true, null, "STAMP000000000014", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 1, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), "hoang.kimchi@bookingcare.vn" },
                    { new Guid("eeeeeeee-0015-0015-0015-000000000015"), 0, "c1a2b3d4-0015-0015-0015-ef1234567890", new DateTime(2026, 1, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "vo.minhduc@bookingcare.vn", true, true, null, "VO.MINHDUC@BOOKINGCARE.VN", "VO.MINHDUC@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000015", true, null, "STAMP000000000015", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 1, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "vo.minhduc@bookingcare.vn" },
                    { new Guid("eeeeeeee-0016-0016-0016-000000000016"), 0, "c1a2b3d4-0016-0016-0016-ef1234567890", new DateTime(2026, 2, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.thikimanh@bookingcare.vn", true, true, null, "NGUYEN.THIKIMANH@BOOKINGCARE.VN", "NGUYEN.THIKIMANH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000016", true, null, "STAMP000000000016", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 2, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.thikimanh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0017-0017-0017-000000000017"), 0, "c1a2b3d4-0017-0017-0017-ef1234567890", new DateTime(2026, 2, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.quanghuy@bookingcare.vn", true, true, null, "TRAN.QUANGHUY@BOOKINGCARE.VN", "TRAN.QUANGHUY@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000017", true, null, "STAMP000000000017", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 2, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.quanghuy@bookingcare.vn" },
                    { new Guid("eeeeeeee-0018-0018-0018-000000000018"), 0, "c1a2b3d4-0018-0018-0018-ef1234567890", new DateTime(2026, 2, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.thuyduong@bookingcare.vn", true, true, null, "LE.THUYDUONG@BOOKINGCARE.VN", "LE.THUYDUONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000018", true, null, "STAMP000000000018", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 2, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.thuyduong@bookingcare.vn" },
                    { new Guid("eeeeeeee-0019-0019-0019-000000000019"), 0, "c1a2b3d4-0019-0019-0019-ef1234567890", new DateTime(2026, 2, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.anhtuan@bookingcare.vn", true, true, null, "PHAM.ANHTUAN@BOOKINGCARE.VN", "PHAM.ANHTUAN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000019", true, null, "STAMP000000000019", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 2, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.anhtuan@bookingcare.vn" },
                    { new Guid("eeeeeeee-0020-0020-0020-000000000020"), 0, "c1a2b3d4-0020-0020-0020-ef1234567890", new DateTime(2026, 2, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "bui.thingocmai@bookingcare.vn", true, true, null, "BUI.THINGOCMAI@BOOKINGCARE.VN", "BUI.THINGOCMAI@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000020", true, null, "STAMP000000000020", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 2, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "bui.thingocmai@bookingcare.vn" },
                    { new Guid("eeeeeeee-0021-0021-0021-000000000021"), 0, "c1a2b3d4-0021-0021-0021-ef1234567890", new DateTime(2026, 2, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "do.viethung@bookingcare.vn", true, true, null, "DO.VIETHUNG@BOOKINGCARE.VN", "DO.VIETHUNG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000021", true, null, "STAMP000000000021", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 2, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "do.viethung@bookingcare.vn" },
                    { new Guid("eeeeeeee-0022-0022-0022-000000000022"), 0, "c1a2b3d4-0022-0022-0022-ef1234567890", new DateTime(2026, 2, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.bichngoc@bookingcare.vn", true, true, null, "NGUYEN.BICHNGOC@BOOKINGCARE.VN", "NGUYEN.BICHNGOC@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000022", true, null, "STAMP000000000022", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 2, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.bichngoc@bookingcare.vn" },
                    { new Guid("eeeeeeee-0023-0023-0023-000000000023"), 0, "c1a2b3d4-0023-0023-0023-ef1234567890", new DateTime(2026, 2, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.hoanglam@bookingcare.vn", true, true, null, "TRAN.HOANGLAM@BOOKINGCARE.VN", "TRAN.HOANGLAM@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000023", true, null, "STAMP000000000023", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 2, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.hoanglam@bookingcare.vn" },
                    { new Guid("eeeeeeee-0024-0024-0024-000000000024"), 0, "c1a2b3d4-0024-0024-0024-ef1234567890", new DateTime(2026, 2, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.thanhphuong@bookingcare.vn", true, true, null, "LE.THANHPHUONG@BOOKINGCARE.VN", "LE.THANHPHUONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000024", true, null, "STAMP000000000024", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 2, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.thanhphuong@bookingcare.vn" },
                    { new Guid("eeeeeeee-0025-0025-0025-000000000025"), 0, "c1a2b3d4-0025-0025-0025-ef1234567890", new DateTime(2026, 2, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.ducmanh@bookingcare.vn", true, true, null, "PHAM.DUCMANH@BOOKINGCARE.VN", "PHAM.DUCMANH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000025", true, null, "STAMP000000000025", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 2, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.ducmanh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0026-0026-0026-000000000026"), 0, "c1a2b3d4-0026-0026-0026-ef1234567890", new DateTime(2026, 2, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), "vo.thuhang@bookingcare.vn", true, true, null, "VO.THUHANG@BOOKINGCARE.VN", "VO.THUHANG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000026", true, null, "STAMP000000000026", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 2, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), "vo.thuhang@bookingcare.vn" },
                    { new Guid("eeeeeeee-0027-0027-0027-000000000027"), 0, "c1a2b3d4-0027-0027-0027-ef1234567890", new DateTime(2026, 2, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "hoang.vantu@bookingcare.vn", true, true, null, "HOANG.VANTU@BOOKINGCARE.VN", "HOANG.VANTU@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000027", true, null, "STAMP000000000027", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 2, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "hoang.vantu@bookingcare.vn" },
                    { new Guid("eeeeeeee-0028-0028-0028-000000000028"), 0, "c1a2b3d4-0028-0028-0028-ef1234567890", new DateTime(2026, 2, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), "dang.thilananh@bookingcare.vn", true, true, null, "DANG.THILANANH@BOOKINGCARE.VN", "DANG.THILANANH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000028", true, null, "STAMP000000000028", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 2, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), "dang.thilananh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0029-0029-0029-000000000029"), 0, "c1a2b3d4-0029-0029-0029-ef1234567890", new DateTime(2026, 2, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), "bui.trongkhoa@bookingcare.vn", true, true, null, "BUI.TRONGKHOA@BOOKINGCARE.VN", "BUI.TRONGKHOA@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000029", true, null, "STAMP000000000029", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 2, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), "bui.trongkhoa@bookingcare.vn" },
                    { new Guid("eeeeeeee-0030-0030-0030-000000000030"), 0, "c1a2b3d4-0030-0030-0030-ef1234567890", new DateTime(2026, 2, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.thithuyvan@bookingcare.vn", true, true, null, "NGUYEN.THITHUYVAN@BOOKINGCARE.VN", "NGUYEN.THITHUYVAN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000030", true, null, "STAMP000000000030", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 2, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.thithuyvan@bookingcare.vn" },
                    { new Guid("eeeeeeee-0031-0031-0031-000000000031"), 0, "c1a2b3d4-0031-0031-0031-ef1234567890", new DateTime(2026, 2, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.ngocson@bookingcare.vn", true, true, null, "TRAN.NGOCSON@BOOKINGCARE.VN", "TRAN.NGOCSON@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000031", true, null, "STAMP000000000031", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 2, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.ngocson@bookingcare.vn" },
                    { new Guid("eeeeeeee-0032-0032-0032-000000000032"), 0, "c1a2b3d4-0032-0032-0032-ef1234567890", new DateTime(2026, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.thibich@bookingcare.vn", true, true, null, "LE.THIBICH@BOOKINGCARE.VN", "LE.THIBICH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000032", true, null, "STAMP000000000032", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.thibich@bookingcare.vn" },
                    { new Guid("eeeeeeee-0033-0033-0033-000000000033"), 0, "c1a2b3d4-0033-0033-0033-ef1234567890", new DateTime(2026, 3, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.xuanhai@bookingcare.vn", true, true, null, "PHAM.XUANHAI@BOOKINGCARE.VN", "PHAM.XUANHAI@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000033", true, null, "STAMP000000000033", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.xuanhai@bookingcare.vn" },
                    { new Guid("eeeeeeee-0034-0034-0034-000000000034"), 0, "c1a2b3d4-0034-0034-0034-ef1234567890", new DateTime(2026, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "vo.thidiem@bookingcare.vn", true, true, null, "VO.THIDIEM@BOOKINGCARE.VN", "VO.THIDIEM@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000034", true, null, "STAMP000000000034", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "vo.thidiem@bookingcare.vn" },
                    { new Guid("eeeeeeee-0035-0035-0035-000000000035"), 0, "c1a2b3d4-0035-0035-0035-ef1234567890", new DateTime(2026, 3, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.trongphat@bookingcare.vn", true, true, null, "NGUYEN.TRONGPHAT@BOOKINGCARE.VN", "NGUYEN.TRONGPHAT@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000035", true, null, "STAMP000000000035", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.trongphat@bookingcare.vn" },
                    { new Guid("eeeeeeee-0036-0036-0036-000000000036"), 0, "c1a2b3d4-0036-0036-0036-ef1234567890", new DateTime(2026, 3, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.thiphuongthanh@bookingcare.vn", true, true, null, "TRAN.THIPHUONGTHANH@BOOKINGCARE.VN", "TRAN.THIPHUONGTHANH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000036", true, null, "STAMP000000000036", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.thiphuongthanh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0037-0037-0037-000000000037"), 0, "c1a2b3d4-0037-0037-0037-ef1234567890", new DateTime(2026, 3, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.vanhieu@bookingcare.vn", true, true, null, "LE.VANHIEU@BOOKINGCARE.VN", "LE.VANHIEU@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000037", true, null, "STAMP000000000037", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.vanhieu@bookingcare.vn" },
                    { new Guid("eeeeeeee-0038-0038-0038-000000000038"), 0, "c1a2b3d4-0038-0038-0038-ef1234567890", new DateTime(2026, 3, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.thihong@bookingcare.vn", true, true, null, "PHAM.THIHONG@BOOKINGCARE.VN", "PHAM.THIHONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000038", true, null, "STAMP000000000038", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.thihong@bookingcare.vn" },
                    { new Guid("eeeeeeee-0039-0039-0039-000000000039"), 0, "c1a2b3d4-0039-0039-0039-ef1234567890", new DateTime(2026, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), "hoang.trungkien@bookingcare.vn", true, true, null, "HOANG.TRUNGKIEN@BOOKINGCARE.VN", "HOANG.TRUNGKIEN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000039", true, null, "STAMP000000000039", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), "hoang.trungkien@bookingcare.vn" },
                    { new Guid("eeeeeeee-0040-0040-0040-000000000040"), 0, "c1a2b3d4-0040-0040-0040-ef1234567890", new DateTime(2026, 3, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.thiminhtam@bookingcare.vn", true, true, null, "NGUYEN.THIMINHTAM@BOOKINGCARE.VN", "NGUYEN.THIMINHTAM@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000040", true, null, "STAMP000000000040", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.thiminhtam@bookingcare.vn" },
                    { new Guid("eeeeeeee-0041-0041-0041-000000000041"), 0, "c1a2b3d4-0041-0041-0041-ef1234567890", new DateTime(2026, 3, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), "vo.quocviet@bookingcare.vn", true, true, null, "VO.QUOCVIET@BOOKINGCARE.VN", "VO.QUOCVIET@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000041", true, null, "STAMP000000000041", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), "vo.quocviet@bookingcare.vn" },
                    { new Guid("eeeeeeee-0042-0042-0042-000000000042"), 0, "c1a2b3d4-0042-0042-0042-ef1234567890", new DateTime(2026, 3, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.thilanphuong@bookingcare.vn", true, true, null, "TRAN.THILANPHUONG@BOOKINGCARE.VN", "TRAN.THILANPHUONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000042", true, null, "STAMP000000000042", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.thilanphuong@bookingcare.vn" },
                    { new Guid("eeeeeeee-0043-0043-0043-000000000043"), 0, "c1a2b3d4-0043-0043-0043-ef1234567890", new DateTime(2026, 3, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.hoangthai@bookingcare.vn", true, true, null, "LE.HOANGTHAI@BOOKINGCARE.VN", "LE.HOANGTHAI@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000043", true, null, "STAMP000000000043", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.hoangthai@bookingcare.vn" },
                    { new Guid("eeeeeeee-0044-0044-0044-000000000044"), 0, "c1a2b3d4-0044-0044-0044-ef1234567890", new DateTime(2026, 3, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.thitramy@bookingcare.vn", true, true, null, "PHAM.THITRAMY@BOOKINGCARE.VN", "PHAM.THITRAMY@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000044", true, null, "STAMP000000000044", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.thitramy@bookingcare.vn" },
                    { new Guid("eeeeeeee-0045-0045-0045-000000000045"), 0, "c1a2b3d4-0045-0045-0045-ef1234567890", new DateTime(2026, 3, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), "hoang.vinhphuc@bookingcare.vn", true, true, null, "HOANG.VINHPHUC@BOOKINGCARE.VN", "HOANG.VINHPHUC@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000045", true, null, "STAMP000000000045", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), "hoang.vinhphuc@bookingcare.vn" },
                    { new Guid("eeeeeeee-0046-0046-0046-000000000046"), 0, "c1a2b3d4-0046-0046-0046-ef1234567890", new DateTime(2026, 3, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.thithanhthao@bookingcare.vn", true, true, null, "NGUYEN.THITHANHTHAO@BOOKINGCARE.VN", "NGUYEN.THITHANHTHAO@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000046", true, null, "STAMP000000000046", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.thithanhthao@bookingcare.vn" },
                    { new Guid("eeeeeeee-0047-0047-0047-000000000047"), 0, "c1a2b3d4-0047-0047-0047-ef1234567890", new DateTime(2026, 3, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), "bui.quangtruong@bookingcare.vn", true, true, null, "BUI.QUANGTRUONG@BOOKINGCARE.VN", "BUI.QUANGTRUONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000047", true, null, "STAMP000000000047", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), "bui.quangtruong@bookingcare.vn" },
                    { new Guid("eeeeeeee-0048-0048-0048-000000000048"), 0, "c1a2b3d4-0048-0048-0048-ef1234567890", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "do.thihaiyen@bookingcare.vn", true, true, null, "DO.THIHAIYEN@BOOKINGCARE.VN", "DO.THIHAIYEN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000048", true, null, "STAMP000000000048", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "do.thihaiyen@bookingcare.vn" },
                    { new Guid("eeeeeeee-0049-0049-0049-000000000049"), 0, "c1a2b3d4-0049-0049-0049-ef1234567890", new DateTime(2026, 3, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.vankhanh@bookingcare.vn", true, true, null, "TRAN.VANKHANH@BOOKINGCARE.VN", "TRAN.VANKHANH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000049", true, null, "STAMP000000000049", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.vankhanh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0050-0050-0050-000000000050"), 0, "c1a2b3d4-0050-0050-0050-ef1234567890", new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.thiminhchau@bookingcare.vn", true, true, null, "LE.THIMINHCHAU@BOOKINGCARE.VN", "LE.THIMINHCHAU@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000050", true, null, "STAMP000000000050", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.thiminhchau@bookingcare.vn" },
                    { new Guid("eeeeeeee-0051-0051-0051-000000000051"), 0, "c1a2b3d4-0051-0051-0051-ef1234567890", new DateTime(2026, 4, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.quocnam@bookingcare.vn", true, true, null, "NGUYEN.QUOCNAM@BOOKINGCARE.VN", "NGUYEN.QUOCNAM@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000051", true, null, "STAMP000000000051", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.quocnam@bookingcare.vn" },
                    { new Guid("eeeeeeee-0052-0052-0052-000000000052"), 0, "c1a2b3d4-0052-0052-0052-ef1234567890", new DateTime(2026, 4, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), "ngo.vananh@bookingcare.vn", true, true, null, "NGO.VANANH@BOOKINGCARE.VN", "NGO.VANANH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000052", true, null, "STAMP000000000052", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), "ngo.vananh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0053-0053-0053-000000000053"), 0, "c1a2b3d4-0053-0053-0053-ef1234567890", new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "phan.ngockhoa@bookingcare.vn", true, true, null, "PHAN.NGOCKHOA@BOOKINGCARE.VN", "PHAN.NGOCKHOA@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000053", true, null, "STAMP000000000053", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "phan.ngockhoa@bookingcare.vn" },
                    { new Guid("eeeeeeee-0054-0054-0054-000000000054"), 0, "c1a2b3d4-0054-0054-0054-ef1234567890", new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "huynh.thanhhung@bookingcare.vn", true, true, null, "HUYNH.THANHHUNG@BOOKINGCARE.VN", "HUYNH.THANHHUNG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000054", true, null, "STAMP000000000054", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "huynh.thanhhung@bookingcare.vn" },
                    { new Guid("eeeeeeee-0055-0055-0055-000000000055"), 0, "c1a2b3d4-0055-0055-0055-ef1234567890", new DateTime(2026, 4, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.thanhtuan@bookingcare.vn", true, true, null, "LE.THANHTUAN@BOOKINGCARE.VN", "LE.THANHTUAN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000055", true, null, "STAMP000000000055", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.thanhtuan@bookingcare.vn" },
                    { new Guid("eeeeeeee-0056-0056-0056-000000000056"), 0, "c1a2b3d4-0056-0056-0056-ef1234567890", new DateTime(2026, 4, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), "duong.ngoctuan@bookingcare.vn", true, true, null, "DUONG.NGOCTUAN@BOOKINGCARE.VN", "DUONG.NGOCTUAN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000056", true, null, "STAMP000000000056", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), "duong.ngoctuan@bookingcare.vn" },
                    { new Guid("eeeeeeee-0057-0057-0057-000000000057"), 0, "c1a2b3d4-0057-0057-0057-ef1234567890", new DateTime(2026, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "phan.ngocanh@bookingcare.vn", true, true, null, "PHAN.NGOCANH@BOOKINGCARE.VN", "PHAN.NGOCANH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000057", true, null, "STAMP000000000057", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "phan.ngocanh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0058-0058-0058-000000000058"), 0, "c1a2b3d4-0058-0058-0058-ef1234567890", new DateTime(2026, 4, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), "ho.quocphat@bookingcare.vn", true, true, null, "HO.QUOCPHAT@BOOKINGCARE.VN", "HO.QUOCPHAT@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000058", true, null, "STAMP000000000058", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), "ho.quocphat@bookingcare.vn" },
                    { new Guid("eeeeeeee-0059-0059-0059-000000000059"), 0, "c1a2b3d4-0059-0059-0059-ef1234567890", new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "phan.bichvy@bookingcare.vn", true, true, null, "PHAN.BICHVY@BOOKINGCARE.VN", "PHAN.BICHVY@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000059", true, null, "STAMP000000000059", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "phan.bichvy@bookingcare.vn" },
                    { new Guid("eeeeeeee-0060-0060-0060-000000000060"), 0, "c1a2b3d4-0060-0060-0060-ef1234567890", new DateTime(2026, 4, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), "huynh.dinhkhoa@bookingcare.vn", true, true, null, "HUYNH.DINHKHOA@BOOKINGCARE.VN", "HUYNH.DINHKHOA@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000060", true, null, "STAMP000000000060", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), "huynh.dinhkhoa@bookingcare.vn" },
                    { new Guid("eeeeeeee-0061-0061-0061-000000000061"), 0, "c1a2b3d4-0061-0061-0061-ef1234567890", new DateTime(2026, 4, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "bui.vannam@bookingcare.vn", true, true, null, "BUI.VANNAM@BOOKINGCARE.VN", "BUI.VANNAM@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000061", true, null, "STAMP000000000061", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "bui.vannam@bookingcare.vn" },
                    { new Guid("eeeeeeee-0062-0062-0062-000000000062"), 0, "c1a2b3d4-0062-0062-0062-ef1234567890", new DateTime(2026, 4, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), "phan.hoangbao@bookingcare.vn", true, true, null, "PHAN.HOANGBAO@BOOKINGCARE.VN", "PHAN.HOANGBAO@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000062", true, null, "STAMP000000000062", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), "phan.hoangbao@bookingcare.vn" },
                    { new Guid("eeeeeeee-0063-0063-0063-000000000063"), 0, "c1a2b3d4-0063-0063-0063-ef1234567890", new DateTime(2026, 4, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), "duong.thulinh@bookingcare.vn", true, true, null, "DUONG.THULINH@BOOKINGCARE.VN", "DUONG.THULINH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000063", true, null, "STAMP000000000063", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), "duong.thulinh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0064-0064-0064-000000000064"), 0, "c1a2b3d4-0064-0064-0064-ef1234567890", new DateTime(2026, 4, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "ngo.kimhuong@bookingcare.vn", true, true, null, "NGO.KIMHUONG@BOOKINGCARE.VN", "NGO.KIMHUONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000064", true, null, "STAMP000000000064", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "ngo.kimhuong@bookingcare.vn" },
                    { new Guid("eeeeeeee-0065-0065-0065-000000000065"), 0, "c1a2b3d4-0065-0065-0065-ef1234567890", new DateTime(2026, 4, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.thihoa@bookingcare.vn", true, true, null, "LE.THIHOA@BOOKINGCARE.VN", "LE.THIHOA@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000065", true, null, "STAMP000000000065", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.thihoa@bookingcare.vn" },
                    { new Guid("eeeeeeee-0066-0066-0066-000000000066"), 0, "c1a2b3d4-0066-0066-0066-ef1234567890", new DateTime(2026, 4, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), "ho.thanhlong@bookingcare.vn", true, true, null, "HO.THANHLONG@BOOKINGCARE.VN", "HO.THANHLONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000066", true, null, "STAMP000000000066", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), "ho.thanhlong@bookingcare.vn" },
                    { new Guid("eeeeeeee-0067-0067-0067-000000000067"), 0, "c1a2b3d4-0067-0067-0067-ef1234567890", new DateTime(2026, 4, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.ngoclam@bookingcare.vn", true, true, null, "PHAM.NGOCLAM@BOOKINGCARE.VN", "PHAM.NGOCLAM@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000067", true, null, "STAMP000000000067", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.ngoclam@bookingcare.vn" },
                    { new Guid("eeeeeeee-0068-0068-0068-000000000068"), 0, "c1a2b3d4-0068-0068-0068-ef1234567890", new DateTime(2026, 4, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), "ngo.thuyen@bookingcare.vn", true, true, null, "NGO.THUYEN@BOOKINGCARE.VN", "NGO.THUYEN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000068", true, null, "STAMP000000000068", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), "ngo.thuyen@bookingcare.vn" },
                    { new Guid("eeeeeeee-0069-0069-0069-000000000069"), 0, "c1a2b3d4-0069-0069-0069-ef1234567890", new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.quochieu@bookingcare.vn", true, true, null, "PHAM.QUOCHIEU@BOOKINGCARE.VN", "PHAM.QUOCHIEU@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000069", true, null, "STAMP000000000069", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.quochieu@bookingcare.vn" },
                    { new Guid("eeeeeeee-0070-0070-0070-000000000070"), 0, "c1a2b3d4-0070-0070-0070-ef1234567890", new DateTime(2026, 4, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), "huynh.thuyngan@bookingcare.vn", true, true, null, "HUYNH.THUYNGAN@BOOKINGCARE.VN", "HUYNH.THUYNGAN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000070", true, null, "STAMP000000000070", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), "huynh.thuyngan@bookingcare.vn" },
                    { new Guid("eeeeeeee-0071-0071-0071-000000000071"), 0, "c1a2b3d4-0071-0071-0071-ef1234567890", new DateTime(2026, 4, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.ngocthao@bookingcare.vn", true, true, null, "NGUYEN.NGOCTHAO@BOOKINGCARE.VN", "NGUYEN.NGOCTHAO@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000071", true, null, "STAMP000000000071", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.ngocthao@bookingcare.vn" },
                    { new Guid("eeeeeeee-0072-0072-0072-000000000072"), 0, "c1a2b3d4-0072-0072-0072-ef1234567890", new DateTime(2026, 4, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.dinhtuan@bookingcare.vn", true, true, null, "LE.DINHTUAN@BOOKINGCARE.VN", "LE.DINHTUAN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000072", true, null, "STAMP000000000072", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.dinhtuan@bookingcare.vn" },
                    { new Guid("eeeeeeee-0073-0073-0073-000000000073"), 0, "c1a2b3d4-0073-0073-0073-ef1234567890", new DateTime(2026, 4, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), "vo.ngoclong@bookingcare.vn", true, true, null, "VO.NGOCLONG@BOOKINGCARE.VN", "VO.NGOCLONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000073", true, null, "STAMP000000000073", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), "vo.ngoclong@bookingcare.vn" },
                    { new Guid("eeeeeeee-0074-0074-0074-000000000074"), 0, "c1a2b3d4-0074-0074-0074-ef1234567890", new DateTime(2026, 4, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "ho.maiyen@bookingcare.vn", true, true, null, "HO.MAIYEN@BOOKINGCARE.VN", "HO.MAIYEN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000074", true, null, "STAMP000000000074", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "ho.maiyen@bookingcare.vn" },
                    { new Guid("eeeeeeee-0075-0075-0075-000000000075"), 0, "c1a2b3d4-0075-0075-0075-ef1234567890", new DateTime(2026, 4, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.ducanh@bookingcare.vn", true, true, null, "LE.DUCANH@BOOKINGCARE.VN", "LE.DUCANH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000075", true, null, "STAMP000000000075", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.ducanh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0076-0076-0076-000000000076"), 0, "c1a2b3d4-0076-0076-0076-ef1234567890", new DateTime(2026, 4, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.vannam@bookingcare.vn", true, true, null, "LE.VANNAM@BOOKINGCARE.VN", "LE.VANNAM@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000076", true, null, "STAMP000000000076", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), "le.vannam@bookingcare.vn" },
                    { new Guid("eeeeeeee-0077-0077-0077-000000000077"), 0, "c1a2b3d4-0077-0077-0077-ef1234567890", new DateTime(2026, 4, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "vu.quochieu@bookingcare.vn", true, true, null, "VU.QUOCHIEU@BOOKINGCARE.VN", "VU.QUOCHIEU@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000077", true, null, "STAMP000000000077", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "vu.quochieu@bookingcare.vn" },
                    { new Guid("eeeeeeee-0078-0078-0078-000000000078"), 0, "c1a2b3d4-0078-0078-0078-ef1234567890", new DateTime(2026, 4, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), "vu.diemngan@bookingcare.vn", true, true, null, "VU.DIEMNGAN@BOOKINGCARE.VN", "VU.DIEMNGAN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000078", true, null, "STAMP000000000078", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), "vu.diemngan@bookingcare.vn" },
                    { new Guid("eeeeeeee-0079-0079-0079-000000000079"), 0, "c1a2b3d4-0079-0079-0079-ef1234567890", new DateTime(2026, 4, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "do.kieuhuong@bookingcare.vn", true, true, null, "DO.KIEUHUONG@BOOKINGCARE.VN", "DO.KIEUHUONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000079", true, null, "STAMP000000000079", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 4, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "do.kieuhuong@bookingcare.vn" },
                    { new Guid("eeeeeeee-0080-0080-0080-000000000080"), 0, "c1a2b3d4-0080-0080-0080-ef1234567890", new DateTime(2026, 5, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "ho.duclam@bookingcare.vn", true, true, null, "HO.DUCLAM@BOOKINGCARE.VN", "HO.DUCLAM@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000080", true, null, "STAMP000000000080", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "ho.duclam@bookingcare.vn" },
                    { new Guid("eeeeeeee-0081-0081-0081-000000000081"), 0, "c1a2b3d4-0081-0081-0081-ef1234567890", new DateTime(2026, 5, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), "hoang.kieulan@bookingcare.vn", true, true, null, "HOANG.KIEULAN@BOOKINGCARE.VN", "HOANG.KIEULAN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000081", true, null, "STAMP000000000081", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), "hoang.kieulan@bookingcare.vn" },
                    { new Guid("eeeeeeee-0082-0082-0082-000000000082"), 0, "c1a2b3d4-0082-0082-0082-ef1234567890", new DateTime(2026, 5, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.thichau@bookingcare.vn", true, true, null, "PHAM.THICHAU@BOOKINGCARE.VN", "PHAM.THICHAU@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000082", true, null, "STAMP000000000082", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), "pham.thichau@bookingcare.vn" },
                    { new Guid("eeeeeeee-0083-0083-0083-000000000083"), 0, "c1a2b3d4-0083-0083-0083-ef1234567890", new DateTime(2026, 5, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "ngo.dinhphat@bookingcare.vn", true, true, null, "NGO.DINHPHAT@BOOKINGCARE.VN", "NGO.DINHPHAT@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000083", true, null, "STAMP000000000083", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "ngo.dinhphat@bookingcare.vn" },
                    { new Guid("eeeeeeee-0084-0084-0084-000000000084"), 0, "c1a2b3d4-0084-0084-0084-ef1234567890", new DateTime(2026, 5, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.kieulinh@bookingcare.vn", true, true, null, "NGUYEN.KIEULINH@BOOKINGCARE.VN", "NGUYEN.KIEULINH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000084", true, null, "STAMP000000000084", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.kieulinh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0085-0085-0085-000000000085"), 0, "c1a2b3d4-0085-0085-0085-ef1234567890", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "hoang.phuonglinh@bookingcare.vn", true, true, null, "HOANG.PHUONGLINH@BOOKINGCARE.VN", "HOANG.PHUONGLINH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000085", true, null, "STAMP000000000085", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "hoang.phuonglinh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0086-0086-0086-000000000086"), 0, "c1a2b3d4-0086-0086-0086-ef1234567890", new DateTime(2026, 5, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), "bui.vananh@bookingcare.vn", true, true, null, "BUI.VANANH@BOOKINGCARE.VN", "BUI.VANANH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000086", true, null, "STAMP000000000086", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), "bui.vananh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0087-0087-0087-000000000087"), 0, "c1a2b3d4-0087-0087-0087-ef1234567890", new DateTime(2026, 5, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.ngoctuan@bookingcare.vn", true, true, null, "TRAN.NGOCTUAN@BOOKINGCARE.VN", "TRAN.NGOCTUAN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000087", true, null, "STAMP000000000087", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "tran.ngoctuan@bookingcare.vn" },
                    { new Guid("eeeeeeee-0088-0088-0088-000000000088"), 0, "c1a2b3d4-0088-0088-0088-ef1234567890", new DateTime(2026, 5, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), "ho.conglong@bookingcare.vn", true, true, null, "HO.CONGLONG@BOOKINGCARE.VN", "HO.CONGLONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000088", true, null, "STAMP000000000088", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), "ho.conglong@bookingcare.vn" },
                    { new Guid("eeeeeeee-0089-0089-0089-000000000089"), 0, "c1a2b3d4-0089-0089-0089-ef1234567890", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "ngo.hoanglong@bookingcare.vn", true, true, null, "NGO.HOANGLONG@BOOKINGCARE.VN", "NGO.HOANGLONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000089", true, null, "STAMP000000000089", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "ngo.hoanglong@bookingcare.vn" },
                    { new Guid("eeeeeeee-0090-0090-0090-000000000090"), 0, "c1a2b3d4-0090-0090-0090-ef1234567890", new DateTime(2026, 5, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), "vu.bichhuong@bookingcare.vn", true, true, null, "VU.BICHHUONG@BOOKINGCARE.VN", "VU.BICHHUONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000090", true, null, "STAMP000000000090", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), "vu.bichhuong@bookingcare.vn" },
                    { new Guid("eeeeeeee-0091-0091-0091-000000000091"), 0, "c1a2b3d4-0091-0091-0091-ef1234567890", new DateTime(2026, 5, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "bui.ngocanh@bookingcare.vn", true, true, null, "BUI.NGOCANH@BOOKINGCARE.VN", "BUI.NGOCANH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000091", true, null, "STAMP000000000091", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "bui.ngocanh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0092-0092-0092-000000000092"), 0, "c1a2b3d4-0092-0092-0092-ef1234567890", new DateTime(2026, 5, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), "phan.ngocphong@bookingcare.vn", true, true, null, "PHAN.NGOCPHONG@BOOKINGCARE.VN", "PHAN.NGOCPHONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000092", true, null, "STAMP000000000092", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), "phan.ngocphong@bookingcare.vn" },
                    { new Guid("eeeeeeee-0093-0093-0093-000000000093"), 0, "c1a2b3d4-0093-0093-0093-ef1234567890", new DateTime(2026, 5, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), "dang.thuyen@bookingcare.vn", true, true, null, "DANG.THUYEN@BOOKINGCARE.VN", "DANG.THUYEN@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000093", true, null, "STAMP000000000093", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), "dang.thuyen@bookingcare.vn" },
                    { new Guid("eeeeeeee-0094-0094-0094-000000000094"), 0, "c1a2b3d4-0094-0094-0094-ef1234567890", new DateTime(2026, 5, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "dang.congdung@bookingcare.vn", true, true, null, "DANG.CONGDUNG@BOOKINGCARE.VN", "DANG.CONGDUNG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000094", true, null, "STAMP000000000094", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "dang.congdung@bookingcare.vn" },
                    { new Guid("eeeeeeee-0095-0095-0095-000000000095"), 0, "c1a2b3d4-0095-0095-0095-ef1234567890", new DateTime(2026, 5, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), "vo.quoclong@bookingcare.vn", true, true, null, "VO.QUOCLONG@BOOKINGCARE.VN", "VO.QUOCLONG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000095", true, null, "STAMP000000000095", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), "vo.quoclong@bookingcare.vn" },
                    { new Guid("eeeeeeee-0096-0096-0096-000000000096"), 0, "c1a2b3d4-0096-0096-0096-ef1234567890", new DateTime(2026, 5, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), "ly.bichanh@bookingcare.vn", true, true, null, "LY.BICHANH@BOOKINGCARE.VN", "LY.BICHANH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000096", true, null, "STAMP000000000096", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), "ly.bichanh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0097-0097-0097-000000000097"), 0, "c1a2b3d4-0097-0097-0097-ef1234567890", new DateTime(2026, 5, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.duclam@bookingcare.vn", true, true, null, "NGUYEN.DUCLAM@BOOKINGCARE.VN", "NGUYEN.DUCLAM@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000097", true, null, "STAMP000000000097", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.duclam@bookingcare.vn" },
                    { new Guid("eeeeeeee-0098-0098-0098-000000000098"), 0, "c1a2b3d4-0098-0098-0098-ef1234567890", new DateTime(2026, 5, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), "ngo.thuyanh@bookingcare.vn", true, true, null, "NGO.THUYANH@BOOKINGCARE.VN", "NGO.THUYANH@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000098", true, null, "STAMP000000000098", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), "ngo.thuyanh@bookingcare.vn" },
                    { new Guid("eeeeeeee-0099-0099-0099-000000000099"), 0, "c1a2b3d4-0099-0099-0099-ef1234567890", new DateTime(2026, 5, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "do.hoangdat@bookingcare.vn", true, true, null, "DO.HOANGDAT@BOOKINGCARE.VN", "DO.HOANGDAT@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000099", true, null, "STAMP000000000099", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "do.hoangdat@bookingcare.vn" },
                    { new Guid("eeeeeeee-0100-0100-0100-000000000100"), 0, "c1a2b3d4-0100-0100-0100-ef1234567890", new DateTime(2026, 5, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), "do.thithao@bookingcare.vn", true, true, null, "DO.THITHAO@BOOKINGCARE.VN", "DO.THITHAO@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAEIeZRoabDjzx3z2xmKc0n/KaTIwOgWtJI+BvxtEZgAlYABXbgVS5Slsyq6yJ+egH4A==", "0901000100", true, null, "STAMP000000000100", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), "do.thithao@bookingcare.vn" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "PatientCode", "UserId" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-0001-0001-0001-000000000001"), "BN2026010500001", new Guid("eeeeeeee-0001-0001-0001-000000000001") },
                    { new Guid("aaaaaaaa-0002-0002-0002-000000000002"), "BN2026010700002", new Guid("eeeeeeee-0002-0002-0002-000000000002") },
                    { new Guid("aaaaaaaa-0003-0003-0003-000000000003"), "BN2026010900003", new Guid("eeeeeeee-0003-0003-0003-000000000003") },
                    { new Guid("aaaaaaaa-0004-0004-0004-000000000004"), "BN2026011000004", new Guid("eeeeeeee-0004-0004-0004-000000000004") },
                    { new Guid("aaaaaaaa-0005-0005-0005-000000000005"), "BN2026011200005", new Guid("eeeeeeee-0005-0005-0005-000000000005") },
                    { new Guid("aaaaaaaa-0006-0006-0006-000000000006"), "BN2026011300006", new Guid("eeeeeeee-0006-0006-0006-000000000006") },
                    { new Guid("aaaaaaaa-0007-0007-0007-000000000007"), "BN2026011500007", new Guid("eeeeeeee-0007-0007-0007-000000000007") },
                    { new Guid("aaaaaaaa-0008-0008-0008-000000000008"), "BN2026011700008", new Guid("eeeeeeee-0008-0008-0008-000000000008") },
                    { new Guid("aaaaaaaa-0009-0009-0009-000000000009"), "BN2026011800009", new Guid("eeeeeeee-0009-0009-0009-000000000009") },
                    { new Guid("aaaaaaaa-0010-0010-0010-000000000010"), "BN2026012000010", new Guid("eeeeeeee-0010-0010-0010-000000000010") },
                    { new Guid("aaaaaaaa-0011-0011-0011-000000000011"), "BN2026012200011", new Guid("eeeeeeee-0011-0011-0011-000000000011") },
                    { new Guid("aaaaaaaa-0012-0012-0012-000000000012"), "BN2026012400012", new Guid("eeeeeeee-0012-0012-0012-000000000012") },
                    { new Guid("aaaaaaaa-0013-0013-0013-000000000013"), "BN2026012500013", new Guid("eeeeeeee-0013-0013-0013-000000000013") },
                    { new Guid("aaaaaaaa-0014-0014-0014-000000000014"), "BN2026012700014", new Guid("eeeeeeee-0014-0014-0014-000000000014") },
                    { new Guid("aaaaaaaa-0015-0015-0015-000000000015"), "BN2026012800015", new Guid("eeeeeeee-0015-0015-0015-000000000015") },
                    { new Guid("aaaaaaaa-0016-0016-0016-000000000016"), "BN2026020100016", new Guid("eeeeeeee-0016-0016-0016-000000000016") },
                    { new Guid("aaaaaaaa-0017-0017-0017-000000000017"), "BN2026020300017", new Guid("eeeeeeee-0017-0017-0017-000000000017") },
                    { new Guid("aaaaaaaa-0018-0018-0018-000000000018"), "BN2026020500018", new Guid("eeeeeeee-0018-0018-0018-000000000018") },
                    { new Guid("aaaaaaaa-0019-0019-0019-000000000019"), "BN2026020600019", new Guid("eeeeeeee-0019-0019-0019-000000000019") },
                    { new Guid("aaaaaaaa-0020-0020-0020-000000000020"), "BN2026020800020", new Guid("eeeeeeee-0020-0020-0020-000000000020") },
                    { new Guid("aaaaaaaa-0021-0021-0021-000000000021"), "BN2026021000021", new Guid("eeeeeeee-0021-0021-0021-000000000021") },
                    { new Guid("aaaaaaaa-0022-0022-0022-000000000022"), "BN2026021200022", new Guid("eeeeeeee-0022-0022-0022-000000000022") },
                    { new Guid("aaaaaaaa-0023-0023-0023-000000000023"), "BN2026021400023", new Guid("eeeeeeee-0023-0023-0023-000000000023") },
                    { new Guid("aaaaaaaa-0024-0024-0024-000000000024"), "BN2026021500024", new Guid("eeeeeeee-0024-0024-0024-000000000024") },
                    { new Guid("aaaaaaaa-0025-0025-0025-000000000025"), "BN2026021700025", new Guid("eeeeeeee-0025-0025-0025-000000000025") },
                    { new Guid("aaaaaaaa-0026-0026-0026-000000000026"), "BN2026021900026", new Guid("eeeeeeee-0026-0026-0026-000000000026") },
                    { new Guid("aaaaaaaa-0027-0027-0027-000000000027"), "BN2026022000027", new Guid("eeeeeeee-0027-0027-0027-000000000027") },
                    { new Guid("aaaaaaaa-0028-0028-0028-000000000028"), "BN2026022200028", new Guid("eeeeeeee-0028-0028-0028-000000000028") },
                    { new Guid("aaaaaaaa-0029-0029-0029-000000000029"), "BN2026022400029", new Guid("eeeeeeee-0029-0029-0029-000000000029") },
                    { new Guid("aaaaaaaa-0030-0030-0030-000000000030"), "BN2026022500030", new Guid("eeeeeeee-0030-0030-0030-000000000030") },
                    { new Guid("aaaaaaaa-0031-0031-0031-000000000031"), "BN2026022700031", new Guid("eeeeeeee-0031-0031-0031-000000000031") },
                    { new Guid("aaaaaaaa-0032-0032-0032-000000000032"), "BN2026030100032", new Guid("eeeeeeee-0032-0032-0032-000000000032") },
                    { new Guid("aaaaaaaa-0033-0033-0033-000000000033"), "BN2026030300033", new Guid("eeeeeeee-0033-0033-0033-000000000033") },
                    { new Guid("aaaaaaaa-0034-0034-0034-000000000034"), "BN2026030500034", new Guid("eeeeeeee-0034-0034-0034-000000000034") },
                    { new Guid("aaaaaaaa-0035-0035-0035-000000000035"), "BN2026030700035", new Guid("eeeeeeee-0035-0035-0035-000000000035") },
                    { new Guid("aaaaaaaa-0036-0036-0036-000000000036"), "BN2026030800036", new Guid("eeeeeeee-0036-0036-0036-000000000036") },
                    { new Guid("aaaaaaaa-0037-0037-0037-000000000037"), "BN2026031000037", new Guid("eeeeeeee-0037-0037-0037-000000000037") },
                    { new Guid("aaaaaaaa-0038-0038-0038-000000000038"), "BN2026031200038", new Guid("eeeeeeee-0038-0038-0038-000000000038") },
                    { new Guid("aaaaaaaa-0039-0039-0039-000000000039"), "BN2026031400039", new Guid("eeeeeeee-0039-0039-0039-000000000039") },
                    { new Guid("aaaaaaaa-0040-0040-0040-000000000040"), "BN2026031500040", new Guid("eeeeeeee-0040-0040-0040-000000000040") },
                    { new Guid("aaaaaaaa-0041-0041-0041-000000000041"), "BN2026031700041", new Guid("eeeeeeee-0041-0041-0041-000000000041") },
                    { new Guid("aaaaaaaa-0042-0042-0042-000000000042"), "BN2026031900042", new Guid("eeeeeeee-0042-0042-0042-000000000042") },
                    { new Guid("aaaaaaaa-0043-0043-0043-000000000043"), "BN2026032000043", new Guid("eeeeeeee-0043-0043-0043-000000000043") },
                    { new Guid("aaaaaaaa-0044-0044-0044-000000000044"), "BN2026032200044", new Guid("eeeeeeee-0044-0044-0044-000000000044") },
                    { new Guid("aaaaaaaa-0045-0045-0045-000000000045"), "BN2026032400045", new Guid("eeeeeeee-0045-0045-0045-000000000045") },
                    { new Guid("aaaaaaaa-0046-0046-0046-000000000046"), "BN2026032500046", new Guid("eeeeeeee-0046-0046-0046-000000000046") },
                    { new Guid("aaaaaaaa-0047-0047-0047-000000000047"), "BN2026032700047", new Guid("eeeeeeee-0047-0047-0047-000000000047") },
                    { new Guid("aaaaaaaa-0048-0048-0048-000000000048"), "BN2026032800048", new Guid("eeeeeeee-0048-0048-0048-000000000048") },
                    { new Guid("aaaaaaaa-0049-0049-0049-000000000049"), "BN2026032900049", new Guid("eeeeeeee-0049-0049-0049-000000000049") },
                    { new Guid("aaaaaaaa-0050-0050-0050-000000000050"), "BN2026033000050", new Guid("eeeeeeee-0050-0050-0050-000000000050") },
                    { new Guid("aaaaaaaa-0051-0051-0051-000000000051"), "BN2026040200051", new Guid("eeeeeeee-0051-0051-0051-000000000051") },
                    { new Guid("aaaaaaaa-0052-0052-0052-000000000052"), "BN2026040300052", new Guid("eeeeeeee-0052-0052-0052-000000000052") },
                    { new Guid("aaaaaaaa-0053-0053-0053-000000000053"), "BN2026040400053", new Guid("eeeeeeee-0053-0053-0053-000000000053") },
                    { new Guid("aaaaaaaa-0054-0054-0054-000000000054"), "BN2026040500054", new Guid("eeeeeeee-0054-0054-0054-000000000054") },
                    { new Guid("aaaaaaaa-0055-0055-0055-000000000055"), "BN2026040600055", new Guid("eeeeeeee-0055-0055-0055-000000000055") },
                    { new Guid("aaaaaaaa-0056-0056-0056-000000000056"), "BN2026040700056", new Guid("eeeeeeee-0056-0056-0056-000000000056") },
                    { new Guid("aaaaaaaa-0057-0057-0057-000000000057"), "BN2026040800057", new Guid("eeeeeeee-0057-0057-0057-000000000057") },
                    { new Guid("aaaaaaaa-0058-0058-0058-000000000058"), "BN2026040900058", new Guid("eeeeeeee-0058-0058-0058-000000000058") },
                    { new Guid("aaaaaaaa-0059-0059-0059-000000000059"), "BN2026041000059", new Guid("eeeeeeee-0059-0059-0059-000000000059") },
                    { new Guid("aaaaaaaa-0060-0060-0060-000000000060"), "BN2026041100060", new Guid("eeeeeeee-0060-0060-0060-000000000060") },
                    { new Guid("aaaaaaaa-0061-0061-0061-000000000061"), "BN2026041200061", new Guid("eeeeeeee-0061-0061-0061-000000000061") },
                    { new Guid("aaaaaaaa-0062-0062-0062-000000000062"), "BN2026041300062", new Guid("eeeeeeee-0062-0062-0062-000000000062") },
                    { new Guid("aaaaaaaa-0063-0063-0063-000000000063"), "BN2026041400063", new Guid("eeeeeeee-0063-0063-0063-000000000063") },
                    { new Guid("aaaaaaaa-0064-0064-0064-000000000064"), "BN2026041500064", new Guid("eeeeeeee-0064-0064-0064-000000000064") },
                    { new Guid("aaaaaaaa-0065-0065-0065-000000000065"), "BN2026041600065", new Guid("eeeeeeee-0065-0065-0065-000000000065") },
                    { new Guid("aaaaaaaa-0066-0066-0066-000000000066"), "BN2026041700066", new Guid("eeeeeeee-0066-0066-0066-000000000066") },
                    { new Guid("aaaaaaaa-0067-0067-0067-000000000067"), "BN2026041800067", new Guid("eeeeeeee-0067-0067-0067-000000000067") },
                    { new Guid("aaaaaaaa-0068-0068-0068-000000000068"), "BN2026041900068", new Guid("eeeeeeee-0068-0068-0068-000000000068") },
                    { new Guid("aaaaaaaa-0069-0069-0069-000000000069"), "BN2026042000069", new Guid("eeeeeeee-0069-0069-0069-000000000069") },
                    { new Guid("aaaaaaaa-0070-0070-0070-000000000070"), "BN2026042100070", new Guid("eeeeeeee-0070-0070-0070-000000000070") },
                    { new Guid("aaaaaaaa-0071-0071-0071-000000000071"), "BN2026042200071", new Guid("eeeeeeee-0071-0071-0071-000000000071") },
                    { new Guid("aaaaaaaa-0072-0072-0072-000000000072"), "BN2026042300072", new Guid("eeeeeeee-0072-0072-0072-000000000072") },
                    { new Guid("aaaaaaaa-0073-0073-0073-000000000073"), "BN2026042400073", new Guid("eeeeeeee-0073-0073-0073-000000000073") },
                    { new Guid("aaaaaaaa-0074-0074-0074-000000000074"), "BN2026042500074", new Guid("eeeeeeee-0074-0074-0074-000000000074") },
                    { new Guid("aaaaaaaa-0075-0075-0075-000000000075"), "BN2026042600075", new Guid("eeeeeeee-0075-0075-0075-000000000075") },
                    { new Guid("aaaaaaaa-0076-0076-0076-000000000076"), "BN2026042700076", new Guid("eeeeeeee-0076-0076-0076-000000000076") },
                    { new Guid("aaaaaaaa-0077-0077-0077-000000000077"), "BN2026042800077", new Guid("eeeeeeee-0077-0077-0077-000000000077") },
                    { new Guid("aaaaaaaa-0078-0078-0078-000000000078"), "BN2026042900078", new Guid("eeeeeeee-0078-0078-0078-000000000078") },
                    { new Guid("aaaaaaaa-0079-0079-0079-000000000079"), "BN2026043000079", new Guid("eeeeeeee-0079-0079-0079-000000000079") },
                    { new Guid("aaaaaaaa-0080-0080-0080-000000000080"), "BN2026050100080", new Guid("eeeeeeee-0080-0080-0080-000000000080") },
                    { new Guid("aaaaaaaa-0081-0081-0081-000000000081"), "BN2026050200081", new Guid("eeeeeeee-0081-0081-0081-000000000081") },
                    { new Guid("aaaaaaaa-0082-0082-0082-000000000082"), "BN2026050300082", new Guid("eeeeeeee-0082-0082-0082-000000000082") },
                    { new Guid("aaaaaaaa-0083-0083-0083-000000000083"), "BN2026050400083", new Guid("eeeeeeee-0083-0083-0083-000000000083") },
                    { new Guid("aaaaaaaa-0084-0084-0084-000000000084"), "BN2026050500084", new Guid("eeeeeeee-0084-0084-0084-000000000084") },
                    { new Guid("aaaaaaaa-0085-0085-0085-000000000085"), "BN2026050600085", new Guid("eeeeeeee-0085-0085-0085-000000000085") },
                    { new Guid("aaaaaaaa-0086-0086-0086-000000000086"), "BN2026050700086", new Guid("eeeeeeee-0086-0086-0086-000000000086") },
                    { new Guid("aaaaaaaa-0087-0087-0087-000000000087"), "BN2026050800087", new Guid("eeeeeeee-0087-0087-0087-000000000087") },
                    { new Guid("aaaaaaaa-0088-0088-0088-000000000088"), "BN2026050900088", new Guid("eeeeeeee-0088-0088-0088-000000000088") },
                    { new Guid("aaaaaaaa-0089-0089-0089-000000000089"), "BN2026051000089", new Guid("eeeeeeee-0089-0089-0089-000000000089") },
                    { new Guid("aaaaaaaa-0090-0090-0090-000000000090"), "BN2026051100090", new Guid("eeeeeeee-0090-0090-0090-000000000090") },
                    { new Guid("aaaaaaaa-0091-0091-0091-000000000091"), "BN2026051200091", new Guid("eeeeeeee-0091-0091-0091-000000000091") },
                    { new Guid("aaaaaaaa-0092-0092-0092-000000000092"), "BN2026051300092", new Guid("eeeeeeee-0092-0092-0092-000000000092") },
                    { new Guid("aaaaaaaa-0093-0093-0093-000000000093"), "BN2026051400093", new Guid("eeeeeeee-0093-0093-0093-000000000093") },
                    { new Guid("aaaaaaaa-0094-0094-0094-000000000094"), "BN2026051500094", new Guid("eeeeeeee-0094-0094-0094-000000000094") },
                    { new Guid("aaaaaaaa-0095-0095-0095-000000000095"), "BN2026051600095", new Guid("eeeeeeee-0095-0095-0095-000000000095") },
                    { new Guid("aaaaaaaa-0096-0096-0096-000000000096"), "BN2026051700096", new Guid("eeeeeeee-0096-0096-0096-000000000096") },
                    { new Guid("aaaaaaaa-0097-0097-0097-000000000097"), "BN2026051800097", new Guid("eeeeeeee-0097-0097-0097-000000000097") },
                    { new Guid("aaaaaaaa-0098-0098-0098-000000000098"), "BN2026051900098", new Guid("eeeeeeee-0098-0098-0098-000000000098") },
                    { new Guid("aaaaaaaa-0099-0099-0099-000000000099"), "BN2026052000099", new Guid("eeeeeeee-0099-0099-0099-000000000099") },
                    { new Guid("aaaaaaaa-0100-0100-0100-000000000100"), "BN2026052100100", new Guid("eeeeeeee-0100-0100-0100-000000000100") }
                });

            migrationBuilder.InsertData(
                table: "PatientProfiles",
                columns: new[] { "Id", "BloodType", "CitizenId", "CreatedDate", "DateOfBirth", "FullName", "Gender", "MedicalHistory", "PatientId", "PhoneNumber", "ProfileCode", "Relationship", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("bbbbbbbb-0001-0001-0001-000000000001"), "A_Positive", "079092000011", new DateTime(2026, 1, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn Minh", "Male", null, new Guid("aaaaaaaa-0001-0001-0001-000000000001"), "0901000001", "HS2026010500001", "MySelf", null },
                    { new Guid("bbbbbbbb-0002-0002-0002-000000000002"), "B_Positive", "079095000022", new DateTime(2026, 1, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị Hoa", "Female", null, new Guid("aaaaaaaa-0002-0002-0002-000000000002"), "0901000002", "HS2026010700002", "MySelf", null },
                    { new Guid("bbbbbbbb-0003-0003-0003-000000000003"), "O_Positive", "079088000033", new DateTime(2026, 1, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Quốc Bảo", "Male", null, new Guid("aaaaaaaa-0003-0003-0003-000000000003"), "0901000003", "HS2026010900003", "MySelf", null },
                    { new Guid("bbbbbbbb-0004-0004-0004-000000000004"), "AB_Positive", "079098000044", new DateTime(2026, 1, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Ngọc Lan", "Female", null, new Guid("aaaaaaaa-0004-0004-0004-000000000004"), "0901000004", "HS2026011000004", "MySelf", null },
                    { new Guid("bbbbbbbb-0005-0005-0005-000000000005"), "B_Negative", "079090000055", new DateTime(2026, 1, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoàng Tiến Đạt", "Male", "Tiểu đường type 2", new Guid("aaaaaaaa-0005-0005-0005-000000000005"), "0901000005", "HS2026011200005", "MySelf", null },
                    { new Guid("bbbbbbbb-0006-0006-0006-000000000006"), "A_Positive", "079093000066", new DateTime(2026, 1, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Võ Thị Thanh", "Female", null, new Guid("aaaaaaaa-0006-0006-0006-000000000006"), "0901000006", "HS2026011300006", "MySelf", null },
                    { new Guid("bbbbbbbb-0007-0007-0007-000000000007"), "O_Negative", "079097000077", new DateTime(2026, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1997, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đặng Hùng Anh", "Female", null, new Guid("aaaaaaaa-0007-0007-0007-000000000007"), "0901000007", "HS2026011500007", "MySelf", null },
                    { new Guid("bbbbbbbb-0008-0008-0008-000000000008"), "A_Positive", "079085000088", new DateTime(2026, 1, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bùi Thành Tùng", "Male", "Huyết áp cao", new Guid("aaaaaaaa-0008-0008-0008-000000000008"), "0901000008", "HS2026011700008", "MySelf", null },
                    { new Guid("bbbbbbbb-0009-0009-0009-000000000009"), "Unknown", "079000000099", new DateTime(2026, 1, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đỗ Thị Mỹ Linh", "Female", null, new Guid("aaaaaaaa-0009-0009-0009-000000000009"), "0901000009", "HS2026011800009", "MySelf", null },
                    { new Guid("bbbbbbbb-0010-0010-0010-000000000010"), "B_Positive", "079096000100", new DateTime(2026, 1, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Phương Nhi", "Female", null, new Guid("aaaaaaaa-0010-0010-0010-000000000010"), "0901000010", "HS2026012000010", "MySelf", null },
                    { new Guid("bbbbbbbb-0011-0011-0011-000000000011"), "O_Positive", "079091000110", new DateTime(2026, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Văn Long", "Male", null, new Guid("aaaaaaaa-0011-0011-0011-000000000011"), "0901000011", "HS2026012200011", "MySelf", null },
                    { new Guid("bbbbbbbb-0012-0012-0012-000000000012"), "A_Negative", "079094000120", new DateTime(2026, 1, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Thị Diễm Hương", "Female", "Dị ứng penicillin", new Guid("aaaaaaaa-0012-0012-0012-000000000012"), "0901000012", "HS2026012400012", "MySelf", null },
                    { new Guid("bbbbbbbb-0013-0013-0013-000000000013"), "B_Positive", "079087000130", new DateTime(2026, 1, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Trọng Nghĩa", "Male", null, new Guid("aaaaaaaa-0013-0013-0013-000000000013"), "0901000013", "HS2026012500013", "MySelf", null },
                    { new Guid("bbbbbbbb-0014-0014-0014-000000000014"), "AB_Negative", "079099000140", new DateTime(2026, 1, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoàng Kim Chi", "Female", null, new Guid("aaaaaaaa-0014-0014-0014-000000000014"), "0901000014", "HS2026012700014", "MySelf", null },
                    { new Guid("bbbbbbbb-0015-0015-0015-000000000015"), "O_Positive", "079093000150", new DateTime(2026, 1, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Võ Minh Đức", "Male", null, new Guid("aaaaaaaa-0015-0015-0015-000000000015"), "0901000015", "HS2026012800015", "MySelf", null },
                    { new Guid("bbbbbbbb-0016-0016-0016-000000000016"), "A_Positive", "079001000160", new DateTime(2026, 2, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị Kim Ánh", "Female", null, new Guid("aaaaaaaa-0016-0016-0016-000000000016"), "0901000016", "HS2026020100016", "MySelf", null },
                    { new Guid("bbbbbbbb-0017-0017-0017-000000000017"), "B_Positive", "079089000170", new DateTime(2026, 2, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Quang Huy", "Male", "Viêm khớp", new Guid("aaaaaaaa-0017-0017-0017-000000000017"), "0901000017", "HS2026020300017", "MySelf", null },
                    { new Guid("bbbbbbbb-0018-0018-0018-000000000018"), "Unknown", "079095000180", new DateTime(2026, 2, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Thùy Dương", "Female", null, new Guid("aaaaaaaa-0018-0018-0018-000000000018"), "0901000018", "HS2026020500018", "MySelf", null },
                    { new Guid("bbbbbbbb-0019-0019-0019-000000000019"), "O_Negative", "079086000190", new DateTime(2026, 2, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Anh Tuấn", "Male", "Gan nhiễm mỡ", new Guid("aaaaaaaa-0019-0019-0019-000000000019"), "0901000019", "HS2026020600019", "MySelf", null },
                    { new Guid("bbbbbbbb-0020-0020-0020-000000000020"), "A_Positive", "079098000200", new DateTime(2026, 2, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bùi Thị Ngọc Mai", "Female", null, new Guid("aaaaaaaa-0020-0020-0020-000000000020"), "0901000020", "HS2026020800020", "MySelf", null },
                    { new Guid("bbbbbbbb-0021-0021-0021-000000000021"), "AB_Positive", "079092000210", new DateTime(2026, 2, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đỗ Việt Hùng", "Male", null, new Guid("aaaaaaaa-0021-0021-0021-000000000021"), "0901000021", "HS2026021000021", "MySelf", null },
                    { new Guid("bbbbbbbb-0022-0022-0022-000000000022"), "B_Negative", "079097000220", new DateTime(2026, 2, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1997, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Bích Ngọc", "Female", null, new Guid("aaaaaaaa-0022-0022-0022-000000000022"), "0901000022", "HS2026021200022", "MySelf", null },
                    { new Guid("bbbbbbbb-0023-0023-0023-000000000023"), "A_Positive", "079084000230", new DateTime(2026, 2, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1984, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Hoàng Lâm", "Male", "Huyết áp cao, mỡ máu", new Guid("aaaaaaaa-0023-0023-0023-000000000023"), "0901000023", "HS2026021400023", "MySelf", null },
                    { new Guid("bbbbbbbb-0024-0024-0024-000000000024"), "O_Positive", "079096000240", new DateTime(2026, 2, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Thanh Phương", "Female", null, new Guid("aaaaaaaa-0024-0024-0024-000000000024"), "0901000024", "HS2026021500024", "MySelf", null },
                    { new Guid("bbbbbbbb-0025-0025-0025-000000000025"), "B_Positive", "079090000250", new DateTime(2026, 2, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Đức Mạnh", "Male", null, new Guid("aaaaaaaa-0025-0025-0025-000000000025"), "0901000025", "HS2026021700025", "MySelf", null },
                    { new Guid("bbbbbbbb-0026-0026-0026-000000000026"), "A_Negative", "079000000260", new DateTime(2026, 2, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Võ Thu Hằng", "Female", null, new Guid("aaaaaaaa-0026-0026-0026-000000000026"), "0901000026", "HS2026021900026", "MySelf", null },
                    { new Guid("bbbbbbbb-0027-0027-0027-000000000027"), "Unknown", "079088000270", new DateTime(2026, 2, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoàng Văn Tú", "Male", null, new Guid("aaaaaaaa-0027-0027-0027-000000000027"), "0901000027", "HS2026022000027", "MySelf", null },
                    { new Guid("bbbbbbbb-0028-0028-0028-000000000028"), "AB_Positive", "079094000280", new DateTime(2026, 2, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đặng Thị Lan Anh", "Female", null, new Guid("aaaaaaaa-0028-0028-0028-000000000028"), "0901000028", "HS2026022200028", "MySelf", null },
                    { new Guid("bbbbbbbb-0029-0029-0029-000000000029"), "O_Positive", "079091000290", new DateTime(2026, 2, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bùi Trọng Khoa", "Male", "Dạ dày", new Guid("aaaaaaaa-0029-0029-0029-000000000029"), "0901000029", "HS2026022400029", "MySelf", null },
                    { new Guid("bbbbbbbb-0030-0030-0030-000000000030"), "B_Positive", "079093000300", new DateTime(2026, 2, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị Thùy Vân", "Female", null, new Guid("aaaaaaaa-0030-0030-0030-000000000030"), "0901000030", "HS2026022500030", "MySelf", null },
                    { new Guid("bbbbbbbb-0031-0031-0031-000000000031"), "A_Positive", "079087000310", new DateTime(2026, 2, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Ngọc Sơn", "Male", null, new Guid("aaaaaaaa-0031-0031-0031-000000000031"), "0901000031", "HS2026022700031", "MySelf", null },
                    { new Guid("bbbbbbbb-0032-0032-0032-000000000032"), "O_Negative", "079099000320", new DateTime(2026, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Thị Bích", "Female", null, new Guid("aaaaaaaa-0032-0032-0032-000000000032"), "0901000032", "HS2026030100032", "MySelf", null },
                    { new Guid("bbbbbbbb-0033-0033-0033-000000000033"), "B_Positive", "079085000330", new DateTime(2026, 3, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Xuân Hải", "Male", "Tiểu đường type 2, huyết áp", new Guid("aaaaaaaa-0033-0033-0033-000000000033"), "0901000033", "HS2026030300033", "MySelf", null },
                    { new Guid("bbbbbbbb-0034-0034-0034-000000000034"), "A_Positive", "079097000340", new DateTime(2026, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1997, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Võ Thị Diễm", "Female", null, new Guid("aaaaaaaa-0034-0034-0034-000000000034"), "0901000034", "HS2026030500034", "MySelf", null },
                    { new Guid("bbbbbbbb-0035-0035-0035-000000000035"), "AB_Negative", "079095000350", new DateTime(2026, 3, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Trọng Phát", "Male", null, new Guid("aaaaaaaa-0035-0035-0035-000000000035"), "0901000035", "HS2026030700035", "MySelf", null },
                    { new Guid("bbbbbbbb-0036-0036-0036-000000000036"), "O_Positive", "079092000360", new DateTime(2026, 3, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị Phương Thanh", "Female", null, new Guid("aaaaaaaa-0036-0036-0036-000000000036"), "0901000036", "HS2026030800036", "MySelf", null },
                    { new Guid("bbbbbbbb-0037-0037-0037-000000000037"), "B_Negative", "079083000370", new DateTime(2026, 3, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1983, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Văn Hiếu", "Male", "Sỏi thận", new Guid("aaaaaaaa-0037-0037-0037-000000000037"), "0901000037", "HS2026031000037", "MySelf", null },
                    { new Guid("bbbbbbbb-0038-0038-0038-000000000038"), "A_Positive", "079096000380", new DateTime(2026, 3, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Thị Hồng", "Female", null, new Guid("aaaaaaaa-0038-0038-0038-000000000038"), "0901000038", "HS2026031200038", "MySelf", null },
                    { new Guid("bbbbbbbb-0039-0039-0039-000000000039"), "Unknown", "079089000390", new DateTime(2026, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoàng Trung Kiên", "Male", null, new Guid("aaaaaaaa-0039-0039-0039-000000000039"), "0901000039", "HS2026031400039", "MySelf", null },
                    { new Guid("bbbbbbbb-0040-0040-0040-000000000040"), "O_Positive", "079002000400", new DateTime(2026, 3, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2002, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị Minh Tâm", "Female", null, new Guid("aaaaaaaa-0040-0040-0040-000000000040"), "0901000040", "HS2026031500040", "MySelf", null },
                    { new Guid("bbbbbbbb-0041-0041-0041-000000000041"), "A_Positive", "079094000410", new DateTime(2026, 3, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Võ Quốc Việt", "Male", null, new Guid("aaaaaaaa-0041-0041-0041-000000000041"), "0901000041", "HS2026031700041", "MySelf", null },
                    { new Guid("bbbbbbbb-0042-0042-0042-000000000042"), "B_Positive", "079098000420", new DateTime(2026, 3, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị Lan Phương", "Female", "Dị ứng hải sản", new Guid("aaaaaaaa-0042-0042-0042-000000000042"), "0901000042", "HS2026031900042", "MySelf", null },
                    { new Guid("bbbbbbbb-0043-0043-0043-000000000043"), "AB_Positive", "079086000430", new DateTime(2026, 3, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Hoàng Thái", "Male", null, new Guid("aaaaaaaa-0043-0043-0043-000000000043"), "0901000043", "HS2026032000043", "MySelf", null },
                    { new Guid("bbbbbbbb-0044-0044-0044-000000000044"), "O_Negative", "079001000440", new DateTime(2026, 3, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Thị Trà My", "Female", null, new Guid("aaaaaaaa-0044-0044-0044-000000000044"), "0901000044", "HS2026032200044", "MySelf", null },
                    { new Guid("bbbbbbbb-0045-0045-0045-000000000045"), "B_Positive", "079093000450", new DateTime(2026, 3, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoàng Vĩnh Phúc", "Male", null, new Guid("aaaaaaaa-0045-0045-0045-000000000045"), "0901000045", "HS2026032400045", "MySelf", null },
                    { new Guid("bbbbbbbb-0046-0046-0046-000000000046"), "A_Negative", "079095000460", new DateTime(2026, 3, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị Thanh Thảo", "Female", null, new Guid("aaaaaaaa-0046-0046-0046-000000000046"), "0901000046", "HS2026032500046", "MySelf", null },
                    { new Guid("bbbbbbbb-0047-0047-0047-000000000047"), "O_Positive", "079090000470", new DateTime(2026, 3, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bùi Quang Trường", "Male", "Đau lưng mãn tính", new Guid("aaaaaaaa-0047-0047-0047-000000000047"), "0901000047", "HS2026032700047", "MySelf", null },
                    { new Guid("bbbbbbbb-0048-0048-0048-000000000048"), "AB_Positive", "079097000480", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1997, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đỗ Thị Hải Yến", "Female", null, new Guid("aaaaaaaa-0048-0048-0048-000000000048"), "0901000048", "HS2026032800048", "MySelf", null },
                    { new Guid("bbbbbbbb-0049-0049-0049-000000000049"), "A_Positive", "079088000490", new DateTime(2026, 3, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Văn Khánh", "Male", null, new Guid("aaaaaaaa-0049-0049-0049-000000000049"), "0901000049", "HS2026032900049", "MySelf", null },
                    { new Guid("bbbbbbbb-0050-0050-0050-000000000050"), "B_Negative", "079000000500", new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Thị Minh Châu", "Female", null, new Guid("aaaaaaaa-0050-0050-0050-000000000050"), "0901000050", "HS2026033000050", "MySelf", null },
                    { new Guid("bbbbbbbb-0051-0051-0051-000000000051"), "O_Positive", "079840000051", new DateTime(2026, 4, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1984, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Quốc Nam", "Male", null, new Guid("aaaaaaaa-0051-0051-0051-000000000051"), "0901000051", "HS2026040200051", "MySelf", null },
                    { new Guid("bbbbbbbb-0052-0052-0052-000000000052"), "AB_Negative", "079750000052", new DateTime(2026, 4, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1975, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngô Văn Anh", "Male", null, new Guid("aaaaaaaa-0052-0052-0052-000000000052"), "0901000052", "HS2026040300052", "MySelf", null },
                    { new Guid("bbbbbbbb-0053-0053-0053-000000000053"), "A_Negative", "079840000053", new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1984, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phan Ngọc Khoa", "Male", null, new Guid("aaaaaaaa-0053-0053-0053-000000000053"), "0901000053", "HS2026040400053", "MySelf", null },
                    { new Guid("bbbbbbbb-0054-0054-0054-000000000054"), "B_Positive", "079870000054", new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Huỳnh Thành Hùng", "Male", null, new Guid("aaaaaaaa-0054-0054-0054-000000000054"), "0901000054", "HS2026040500054", "MySelf", null },
                    { new Guid("bbbbbbbb-0055-0055-0055-000000000055"), "A_Negative", "079920000055", new DateTime(2026, 4, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Thành Tuấn", "Male", null, new Guid("aaaaaaaa-0055-0055-0055-000000000055"), "0901000055", "HS2026040600055", "MySelf", null },
                    { new Guid("bbbbbbbb-0056-0056-0056-000000000056"), "A_Negative", "079940000056", new DateTime(2026, 4, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dương Ngọc Tuấn", "Male", null, new Guid("aaaaaaaa-0056-0056-0056-000000000056"), "0901000056", "HS2026040700056", "MySelf", null },
                    { new Guid("bbbbbbbb-0057-0057-0057-000000000057"), "A_Positive", "079840000057", new DateTime(2026, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1984, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phan Ngọc Anh", "Female", null, new Guid("aaaaaaaa-0057-0057-0057-000000000057"), "0901000057", "HS2026040800057", "MySelf", null },
                    { new Guid("bbbbbbbb-0058-0058-0058-000000000058"), "B_Positive", "079100000058", new DateTime(2026, 4, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hồ Quốc Phát", "Male", null, new Guid("aaaaaaaa-0058-0058-0058-000000000058"), "0901000058", "HS2026040900058", "MySelf", null },
                    { new Guid("bbbbbbbb-0059-0059-0059-000000000059"), "O_Negative", "079740000059", new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1974, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phan Bích Vy", "Female", null, new Guid("aaaaaaaa-0059-0059-0059-000000000059"), "0901000059", "HS2026041000059", "MySelf", null },
                    { new Guid("bbbbbbbb-0060-0060-0060-000000000060"), "AB_Negative", "079870000060", new DateTime(2026, 4, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Huỳnh Đình Khoa", "Male", null, new Guid("aaaaaaaa-0060-0060-0060-000000000060"), "0901000060", "HS2026041100060", "MySelf", null },
                    { new Guid("bbbbbbbb-0061-0061-0061-000000000061"), "A_Negative", "079720000061", new DateTime(2026, 4, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1972, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bùi Văn Nam", "Male", null, new Guid("aaaaaaaa-0061-0061-0061-000000000061"), "0901000061", "HS2026041200061", "MySelf", null },
                    { new Guid("bbbbbbbb-0062-0062-0062-000000000062"), "AB_Positive", "079900000062", new DateTime(2026, 4, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phan Hoàng Bảo", "Male", null, new Guid("aaaaaaaa-0062-0062-0062-000000000062"), "0901000062", "HS2026041300062", "MySelf", null },
                    { new Guid("bbbbbbbb-0063-0063-0063-000000000063"), "AB_Negative", "079780000063", new DateTime(2026, 4, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dương Thu Linh", "Female", null, new Guid("aaaaaaaa-0063-0063-0063-000000000063"), "0901000063", "HS2026041400063", "MySelf", null },
                    { new Guid("bbbbbbbb-0064-0064-0064-000000000064"), "AB_Negative", "079930000064", new DateTime(2026, 4, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngô Kim Hương", "Female", null, new Guid("aaaaaaaa-0064-0064-0064-000000000064"), "0901000064", "HS2026041500064", "MySelf", null },
                    { new Guid("bbbbbbbb-0065-0065-0065-000000000065"), "B_Negative", "079790000065", new DateTime(2026, 4, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1979, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Thị Hoa", "Female", null, new Guid("aaaaaaaa-0065-0065-0065-000000000065"), "0901000065", "HS2026041600065", "MySelf", null },
                    { new Guid("bbbbbbbb-0066-0066-0066-000000000066"), "AB_Negative", "079990000066", new DateTime(2026, 4, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hồ Thành Long", "Male", null, new Guid("aaaaaaaa-0066-0066-0066-000000000066"), "0901000066", "HS2026041700066", "MySelf", null },
                    { new Guid("bbbbbbbb-0067-0067-0067-000000000067"), "O_Positive", "079870000067", new DateTime(2026, 4, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Ngọc Lâm", "Male", null, new Guid("aaaaaaaa-0067-0067-0067-000000000067"), "0901000067", "HS2026041800067", "MySelf", null },
                    { new Guid("bbbbbbbb-0068-0068-0068-000000000068"), "A_Negative", "079700000068", new DateTime(2026, 4, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1970, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngô Thu Yến", "Female", null, new Guid("aaaaaaaa-0068-0068-0068-000000000068"), "0901000068", "HS2026041900068", "MySelf", null },
                    { new Guid("bbbbbbbb-0069-0069-0069-000000000069"), "O_Negative", "079020000069", new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2002, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Quốc Hiếu", "Male", null, new Guid("aaaaaaaa-0069-0069-0069-000000000069"), "0901000069", "HS2026042000069", "MySelf", null },
                    { new Guid("bbbbbbbb-0070-0070-0070-000000000070"), "B_Positive", "079030000070", new DateTime(2026, 4, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2003, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Huỳnh Thùy Ngân", "Female", null, new Guid("aaaaaaaa-0070-0070-0070-000000000070"), "0901000070", "HS2026042100070", "MySelf", null },
                    { new Guid("bbbbbbbb-0071-0071-0071-000000000071"), "A_Positive", "079890000071", new DateTime(2026, 4, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Ngọc Thảo", "Female", null, new Guid("aaaaaaaa-0071-0071-0071-000000000071"), "0901000071", "HS2026042200071", "MySelf", null },
                    { new Guid("bbbbbbbb-0072-0072-0072-000000000072"), "AB_Positive", "079040000072", new DateTime(2026, 4, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2004, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Đình Tuấn", "Male", null, new Guid("aaaaaaaa-0072-0072-0072-000000000072"), "0901000072", "HS2026042300072", "MySelf", null },
                    { new Guid("bbbbbbbb-0073-0073-0073-000000000073"), "A_Positive", "079970000073", new DateTime(2026, 4, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1997, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Võ Ngọc Long", "Male", null, new Guid("aaaaaaaa-0073-0073-0073-000000000073"), "0901000073", "HS2026042400073", "MySelf", null },
                    { new Guid("bbbbbbbb-0074-0074-0074-000000000074"), "A_Positive", "079030000074", new DateTime(2026, 4, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2003, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hồ Mai Yến", "Female", null, new Guid("aaaaaaaa-0074-0074-0074-000000000074"), "0901000074", "HS2026042500074", "MySelf", null },
                    { new Guid("bbbbbbbb-0075-0075-0075-000000000075"), "A_Positive", "079070000075", new DateTime(2026, 4, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2007, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Đức Anh", "Male", null, new Guid("aaaaaaaa-0075-0075-0075-000000000075"), "0901000075", "HS2026042600075", "MySelf", null },
                    { new Guid("bbbbbbbb-0076-0076-0076-000000000076"), "B_Positive", "079740000076", new DateTime(2026, 4, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1974, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Văn Nam", "Male", null, new Guid("aaaaaaaa-0076-0076-0076-000000000076"), "0901000076", "HS2026042700076", "MySelf", null },
                    { new Guid("bbbbbbbb-0077-0077-0077-000000000077"), "O_Negative", "079010000077", new DateTime(2026, 4, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vũ Quốc Hiếu", "Male", null, new Guid("aaaaaaaa-0077-0077-0077-000000000077"), "0901000077", "HS2026042800077", "MySelf", null },
                    { new Guid("bbbbbbbb-0078-0078-0078-000000000078"), "O_Positive", "079960000078", new DateTime(2026, 4, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vũ Diễm Ngân", "Female", null, new Guid("aaaaaaaa-0078-0078-0078-000000000078"), "0901000078", "HS2026042900078", "MySelf", null },
                    { new Guid("bbbbbbbb-0079-0079-0079-000000000079"), "O_Positive", "079990000079", new DateTime(2026, 4, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đỗ Kiều Hương", "Female", null, new Guid("aaaaaaaa-0079-0079-0079-000000000079"), "0901000079", "HS2026043000079", "MySelf", null },
                    { new Guid("bbbbbbbb-0080-0080-0080-000000000080"), "A_Positive", "079760000080", new DateTime(2026, 5, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1976, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hồ Đức Lâm", "Male", null, new Guid("aaaaaaaa-0080-0080-0080-000000000080"), "0901000080", "HS2026050100080", "MySelf", null },
                    { new Guid("bbbbbbbb-0081-0081-0081-000000000081"), "O_Positive", "079870000081", new DateTime(2026, 5, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoàng Kiều Lan", "Female", null, new Guid("aaaaaaaa-0081-0081-0081-000000000081"), "0901000081", "HS2026050200081", "MySelf", null },
                    { new Guid("bbbbbbbb-0082-0082-0082-000000000082"), "A_Positive", "079040000082", new DateTime(2026, 5, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2004, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Thị Châu", "Female", null, new Guid("aaaaaaaa-0082-0082-0082-000000000082"), "0901000082", "HS2026050300082", "MySelf", null },
                    { new Guid("bbbbbbbb-0083-0083-0083-000000000083"), "O_Negative", "079830000083", new DateTime(2026, 5, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1983, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngô Đình Phát", "Male", null, new Guid("aaaaaaaa-0083-0083-0083-000000000083"), "0901000083", "HS2026050400083", "MySelf", null },
                    { new Guid("bbbbbbbb-0084-0084-0084-000000000084"), "AB_Negative", "079990000084", new DateTime(2026, 5, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Kiều Linh", "Female", null, new Guid("aaaaaaaa-0084-0084-0084-000000000084"), "0901000084", "HS2026050500084", "MySelf", null },
                    { new Guid("bbbbbbbb-0085-0085-0085-000000000085"), "AB_Negative", "079830000085", new DateTime(2026, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1983, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoàng Phương Linh", "Female", null, new Guid("aaaaaaaa-0085-0085-0085-000000000085"), "0901000085", "HS2026050600085", "MySelf", null },
                    { new Guid("bbbbbbbb-0086-0086-0086-000000000086"), "AB_Negative", "079070000086", new DateTime(2026, 5, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2007, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bùi Văn Anh", "Male", null, new Guid("aaaaaaaa-0086-0086-0086-000000000086"), "0901000086", "HS2026050700086", "MySelf", null },
                    { new Guid("bbbbbbbb-0087-0087-0087-000000000087"), "O_Positive", "079810000087", new DateTime(2026, 5, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1981, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Ngọc Tuấn", "Male", null, new Guid("aaaaaaaa-0087-0087-0087-000000000087"), "0901000087", "HS2026050800087", "MySelf", null },
                    { new Guid("bbbbbbbb-0088-0088-0088-000000000088"), "Unknown", "079850000088", new DateTime(2026, 5, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hồ Công Long", "Male", null, new Guid("aaaaaaaa-0088-0088-0088-000000000088"), "0901000088", "HS2026050900088", "MySelf", null },
                    { new Guid("bbbbbbbb-0089-0089-0089-000000000089"), "A_Positive", "079030000089", new DateTime(2026, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2003, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngô Hoàng Long", "Male", null, new Guid("aaaaaaaa-0089-0089-0089-000000000089"), "0901000089", "HS2026051000089", "MySelf", null },
                    { new Guid("bbbbbbbb-0090-0090-0090-000000000090"), "A_Negative", "079780000090", new DateTime(2026, 5, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vũ Bích Hương", "Female", null, new Guid("aaaaaaaa-0090-0090-0090-000000000090"), "0901000090", "HS2026051100090", "MySelf", null },
                    { new Guid("bbbbbbbb-0091-0091-0091-000000000091"), "O_Positive", "079990000091", new DateTime(2026, 5, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bùi Ngọc Anh", "Female", null, new Guid("aaaaaaaa-0091-0091-0091-000000000091"), "0901000091", "HS2026051200091", "MySelf", null },
                    { new Guid("bbbbbbbb-0092-0092-0092-000000000092"), "A_Positive", "079780000092", new DateTime(2026, 5, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phan Ngọc Phong", "Male", null, new Guid("aaaaaaaa-0092-0092-0092-000000000092"), "0901000092", "HS2026051300092", "MySelf", null },
                    { new Guid("bbbbbbbb-0093-0093-0093-000000000093"), "AB_Negative", "079040000093", new DateTime(2026, 5, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2004, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đặng Thu Yến", "Female", null, new Guid("aaaaaaaa-0093-0093-0093-000000000093"), "0901000093", "HS2026051400093", "MySelf", null },
                    { new Guid("bbbbbbbb-0094-0094-0094-000000000094"), "AB_Negative", "079860000094", new DateTime(2026, 5, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đặng Công Dũng", "Male", null, new Guid("aaaaaaaa-0094-0094-0094-000000000094"), "0901000094", "HS2026051500094", "MySelf", null },
                    { new Guid("bbbbbbbb-0095-0095-0095-000000000095"), "A_Positive", "079830000095", new DateTime(2026, 5, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1983, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Võ Quốc Long", "Male", null, new Guid("aaaaaaaa-0095-0095-0095-000000000095"), "0901000095", "HS2026051600095", "MySelf", null },
                    { new Guid("bbbbbbbb-0096-0096-0096-000000000096"), "A_Negative", "079750000096", new DateTime(2026, 5, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1975, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lý Bích Anh", "Female", null, new Guid("aaaaaaaa-0096-0096-0096-000000000096"), "0901000096", "HS2026051700096", "MySelf", null },
                    { new Guid("bbbbbbbb-0097-0097-0097-000000000097"), "O_Negative", "079780000097", new DateTime(2026, 5, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Đức Lâm", "Male", null, new Guid("aaaaaaaa-0097-0097-0097-000000000097"), "0901000097", "HS2026051800097", "MySelf", null },
                    { new Guid("bbbbbbbb-0098-0098-0098-000000000098"), "O_Negative", "079770000098", new DateTime(2026, 5, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1977, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngô Thùy Anh", "Female", null, new Guid("aaaaaaaa-0098-0098-0098-000000000098"), "0901000098", "HS2026051900098", "MySelf", null },
                    { new Guid("bbbbbbbb-0099-0099-0099-000000000099"), "Unknown", "079790000099", new DateTime(2026, 5, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1979, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đỗ Hoàng Đạt", "Male", null, new Guid("aaaaaaaa-0099-0099-0099-000000000099"), "0901000099", "HS2026052000099", "MySelf", null },
                    { new Guid("bbbbbbbb-0100-0100-0100-000000000100"), "O_Positive", "079830000100", new DateTime(2026, 5, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1983, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đỗ Thị Thảo", "Female", null, new Guid("aaaaaaaa-0100-0100-0100-000000000100"), "0901000100", "HS2026052100100", "MySelf", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0001-0001-0001-000000000001"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0002-0002-0002-000000000002"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0003-0003-0003-000000000003"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0004-0004-0004-000000000004"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0005-0005-0005-000000000005"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0006-0006-0006-000000000006"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0007-0007-0007-000000000007"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0008-0008-0008-000000000008"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0009-0009-0009-000000000009"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0010-0010-0010-000000000010"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0011-0011-0011-000000000011"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0012-0012-0012-000000000012"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0013-0013-0013-000000000013"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0014-0014-0014-000000000014"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0015-0015-0015-000000000015"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0016-0016-0016-000000000016"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0017-0017-0017-000000000017"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0018-0018-0018-000000000018"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0019-0019-0019-000000000019"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0020-0020-0020-000000000020"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0021-0021-0021-000000000021"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0022-0022-0022-000000000022"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0023-0023-0023-000000000023"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0024-0024-0024-000000000024"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0025-0025-0025-000000000025"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0026-0026-0026-000000000026"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0027-0027-0027-000000000027"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0028-0028-0028-000000000028"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0029-0029-0029-000000000029"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0030-0030-0030-000000000030"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0031-0031-0031-000000000031"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0032-0032-0032-000000000032"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0033-0033-0033-000000000033"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0034-0034-0034-000000000034"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0035-0035-0035-000000000035"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0036-0036-0036-000000000036"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0037-0037-0037-000000000037"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0038-0038-0038-000000000038"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0039-0039-0039-000000000039"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0040-0040-0040-000000000040"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0041-0041-0041-000000000041"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0042-0042-0042-000000000042"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0043-0043-0043-000000000043"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0044-0044-0044-000000000044"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0045-0045-0045-000000000045"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0046-0046-0046-000000000046"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0047-0047-0047-000000000047"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0048-0048-0048-000000000048"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0049-0049-0049-000000000049"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0050-0050-0050-000000000050"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0051-0051-0051-000000000051"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0052-0052-0052-000000000052"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0053-0053-0053-000000000053"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0054-0054-0054-000000000054"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0055-0055-0055-000000000055"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0056-0056-0056-000000000056"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0057-0057-0057-000000000057"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0058-0058-0058-000000000058"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0059-0059-0059-000000000059"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0060-0060-0060-000000000060"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0061-0061-0061-000000000061"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0062-0062-0062-000000000062"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0063-0063-0063-000000000063"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0064-0064-0064-000000000064"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0065-0065-0065-000000000065"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0066-0066-0066-000000000066"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0067-0067-0067-000000000067"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0068-0068-0068-000000000068"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0069-0069-0069-000000000069"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0070-0070-0070-000000000070"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0071-0071-0071-000000000071"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0072-0072-0072-000000000072"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0073-0073-0073-000000000073"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0074-0074-0074-000000000074"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0075-0075-0075-000000000075"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0076-0076-0076-000000000076"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0077-0077-0077-000000000077"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0078-0078-0078-000000000078"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0079-0079-0079-000000000079"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0080-0080-0080-000000000080"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0081-0081-0081-000000000081"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0082-0082-0082-000000000082"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0083-0083-0083-000000000083"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0084-0084-0084-000000000084"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0085-0085-0085-000000000085"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0086-0086-0086-000000000086"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0087-0087-0087-000000000087"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0088-0088-0088-000000000088"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0089-0089-0089-000000000089"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0090-0090-0090-000000000090"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0091-0091-0091-000000000091"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0092-0092-0092-000000000092"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0093-0093-0093-000000000093"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0094-0094-0094-000000000094"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0095-0095-0095-000000000095"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0096-0096-0096-000000000096"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0097-0097-0097-000000000097"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0098-0098-0098-000000000098"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0099-0099-0099-000000000099"));

            migrationBuilder.DeleteData(
                table: "PatientProfiles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0100-0100-0100-000000000100"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0001-0001-0001-000000000001"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0002-0002-0002-000000000002"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0003-0003-0003-000000000003"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0004-0004-0004-000000000004"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0005-0005-0005-000000000005"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0006-0006-0006-000000000006"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0007-0007-0007-000000000007"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0008-0008-0008-000000000008"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0009-0009-0009-000000000009"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0010-0010-0010-000000000010"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0011-0011-0011-000000000011"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0012-0012-0012-000000000012"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0013-0013-0013-000000000013"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0014-0014-0014-000000000014"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0015-0015-0015-000000000015"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0016-0016-0016-000000000016"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0017-0017-0017-000000000017"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0018-0018-0018-000000000018"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0019-0019-0019-000000000019"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0020-0020-0020-000000000020"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0021-0021-0021-000000000021"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0022-0022-0022-000000000022"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0023-0023-0023-000000000023"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0024-0024-0024-000000000024"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0025-0025-0025-000000000025"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0026-0026-0026-000000000026"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0027-0027-0027-000000000027"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0028-0028-0028-000000000028"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0029-0029-0029-000000000029"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0030-0030-0030-000000000030"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0031-0031-0031-000000000031"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0032-0032-0032-000000000032"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0033-0033-0033-000000000033"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0034-0034-0034-000000000034"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0035-0035-0035-000000000035"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0036-0036-0036-000000000036"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0037-0037-0037-000000000037"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0038-0038-0038-000000000038"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0039-0039-0039-000000000039"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0040-0040-0040-000000000040"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0041-0041-0041-000000000041"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0042-0042-0042-000000000042"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0043-0043-0043-000000000043"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0044-0044-0044-000000000044"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0045-0045-0045-000000000045"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0046-0046-0046-000000000046"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0047-0047-0047-000000000047"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0048-0048-0048-000000000048"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0049-0049-0049-000000000049"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0050-0050-0050-000000000050"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0051-0051-0051-000000000051"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0052-0052-0052-000000000052"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0053-0053-0053-000000000053"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0054-0054-0054-000000000054"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0055-0055-0055-000000000055"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0056-0056-0056-000000000056"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0057-0057-0057-000000000057"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0058-0058-0058-000000000058"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0059-0059-0059-000000000059"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0060-0060-0060-000000000060"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0061-0061-0061-000000000061"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0062-0062-0062-000000000062"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0063-0063-0063-000000000063"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0064-0064-0064-000000000064"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0065-0065-0065-000000000065"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0066-0066-0066-000000000066"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0067-0067-0067-000000000067"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0068-0068-0068-000000000068"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0069-0069-0069-000000000069"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0070-0070-0070-000000000070"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0071-0071-0071-000000000071"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0072-0072-0072-000000000072"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0073-0073-0073-000000000073"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0074-0074-0074-000000000074"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0075-0075-0075-000000000075"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0076-0076-0076-000000000076"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0077-0077-0077-000000000077"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0078-0078-0078-000000000078"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0079-0079-0079-000000000079"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0080-0080-0080-000000000080"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0081-0081-0081-000000000081"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0082-0082-0082-000000000082"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0083-0083-0083-000000000083"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0084-0084-0084-000000000084"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0085-0085-0085-000000000085"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0086-0086-0086-000000000086"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0087-0087-0087-000000000087"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0088-0088-0088-000000000088"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0089-0089-0089-000000000089"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0090-0090-0090-000000000090"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0091-0091-0091-000000000091"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0092-0092-0092-000000000092"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0093-0093-0093-000000000093"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0094-0094-0094-000000000094"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0095-0095-0095-000000000095"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0096-0096-0096-000000000096"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0097-0097-0097-000000000097"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0098-0098-0098-000000000098"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0099-0099-0099-000000000099"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0100-0100-0100-000000000100"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0001-0001-0001-000000000001"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0002-0002-0002-000000000002"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0003-0003-0003-000000000003"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0004-0004-0004-000000000004"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0005-0005-0005-000000000005"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0006-0006-0006-000000000006"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0007-0007-0007-000000000007"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0008-0008-0008-000000000008"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0009-0009-0009-000000000009"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0010-0010-0010-000000000010"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0011-0011-0011-000000000011"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0012-0012-0012-000000000012"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0013-0013-0013-000000000013"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0014-0014-0014-000000000014"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0015-0015-0015-000000000015"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0016-0016-0016-000000000016"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0017-0017-0017-000000000017"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0018-0018-0018-000000000018"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0019-0019-0019-000000000019"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0020-0020-0020-000000000020"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0021-0021-0021-000000000021"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0022-0022-0022-000000000022"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0023-0023-0023-000000000023"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0024-0024-0024-000000000024"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0025-0025-0025-000000000025"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0026-0026-0026-000000000026"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0027-0027-0027-000000000027"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0028-0028-0028-000000000028"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0029-0029-0029-000000000029"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0030-0030-0030-000000000030"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0031-0031-0031-000000000031"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0032-0032-0032-000000000032"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0033-0033-0033-000000000033"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0034-0034-0034-000000000034"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0035-0035-0035-000000000035"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0036-0036-0036-000000000036"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0037-0037-0037-000000000037"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0038-0038-0038-000000000038"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0039-0039-0039-000000000039"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0040-0040-0040-000000000040"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0041-0041-0041-000000000041"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0042-0042-0042-000000000042"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0043-0043-0043-000000000043"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0044-0044-0044-000000000044"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0045-0045-0045-000000000045"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0046-0046-0046-000000000046"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0047-0047-0047-000000000047"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0048-0048-0048-000000000048"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0049-0049-0049-000000000049"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0050-0050-0050-000000000050"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0051-0051-0051-000000000051"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0052-0052-0052-000000000052"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0053-0053-0053-000000000053"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0054-0054-0054-000000000054"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0055-0055-0055-000000000055"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0056-0056-0056-000000000056"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0057-0057-0057-000000000057"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0058-0058-0058-000000000058"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0059-0059-0059-000000000059"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0060-0060-0060-000000000060"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0061-0061-0061-000000000061"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0062-0062-0062-000000000062"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0063-0063-0063-000000000063"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0064-0064-0064-000000000064"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0065-0065-0065-000000000065"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0066-0066-0066-000000000066"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0067-0067-0067-000000000067"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0068-0068-0068-000000000068"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0069-0069-0069-000000000069"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0070-0070-0070-000000000070"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0071-0071-0071-000000000071"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0072-0072-0072-000000000072"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0073-0073-0073-000000000073"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0074-0074-0074-000000000074"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0075-0075-0075-000000000075"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0076-0076-0076-000000000076"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0077-0077-0077-000000000077"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0078-0078-0078-000000000078"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0079-0079-0079-000000000079"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0080-0080-0080-000000000080"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0081-0081-0081-000000000081"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0082-0082-0082-000000000082"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0083-0083-0083-000000000083"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0084-0084-0084-000000000084"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0085-0085-0085-000000000085"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0086-0086-0086-000000000086"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0087-0087-0087-000000000087"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0088-0088-0088-000000000088"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0089-0089-0089-000000000089"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0090-0090-0090-000000000090"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0091-0091-0091-000000000091"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0092-0092-0092-000000000092"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0093-0093-0093-000000000093"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0094-0094-0094-000000000094"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0095-0095-0095-000000000095"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0096-0096-0096-000000000096"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0097-0097-0097-000000000097"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0098-0098-0098-000000000098"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0099-0099-0099-000000000099"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0100-0100-0100-000000000100"));
        }
    }
}
