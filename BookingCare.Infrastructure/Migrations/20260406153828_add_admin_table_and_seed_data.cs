using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_admin_table_and_seed_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenExpiry", "TwoFactorEnabled", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("aaaaaaaa-1111-1111-1111-111111111111"), 0, "admin-c1d2-e3f4-g5h6-78901234567", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "admin.quang@bookingcare.vn", true, true, null, "ADMIN.QUANG@BOOKINGCARE.VN", "ADMIN.QUANG@BOOKINGCARE.VN", "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==", "0988888888", true, null, "ADMIN_SEC_STAMP_001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "admin.quang@bookingcare.vn" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-0000-0000-0000-000000000000"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_1.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1111-1111-1111-111111111111"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_2.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-2222-2222-2222-222222222222"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_1_.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_3.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-4444-4444-4444-444444444444"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_2.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-5555-5555-5555-555555555555"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_4.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-6666-6666-6666-666666666666"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_5.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-7777-7777-7777-777777777777"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_6.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-8888-8888-8888-888888888888"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_7.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-9999-9999-9999-999999999999"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_8.jpg");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111101"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/specialty/CoXuongKhop.png");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111102"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/specialty/TieuHoa.png");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111103"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/specialty/TimMach.png");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111104"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/specialty/SanPhuKhoa.png");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111105"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/specialty/NhiKhoa.png");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111106"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/specialty/DaLieu.png");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111107"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/specialty/TaiMuiHong.png");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111108"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/specialty/Mat.png");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111109"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/specialty/ThanKinh.png");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111110"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare-resources/static/specialty/RangHamMat.png");

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "AdminCode", "FullName", "IsActive", "UserId" },
                values: new object[] { new Guid("bbbbbbbb-2222-2222-2222-222222222222"), "ADM-001", "Nguyễn Minh Quang", true, new Guid("aaaaaaaa-1111-1111-1111-111111111111") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("34994df5-6435-430c-8fd3-e578da6ed929"), new Guid("aaaaaaaa-1111-1111-1111-111111111111") });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("34994df5-6435-430c-8fd3-e578da6ed929"), new Guid("aaaaaaaa-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-1111-1111-1111-111111111111"));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-0000-0000-0000-000000000000"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare/doctors/pham-nhu-hai.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1111-1111-1111-111111111111"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare/doctors/nguyen-trong-hung.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-2222-2222-2222-222222222222"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare/doctors/do-thi-tuong-van.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare/doctors/le-ngoc-thanh.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-4444-4444-4444-444444444444"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare/doctors/tran-thi-dung.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-5555-5555-5555-555555555555"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare/doctors/pham-nhat-an.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-6666-6666-6666-666666666666"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare/doctors/vu-nguyet-minh.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-7777-7777-7777-777777777777"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare/doctors/tran-huu-thang.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-8888-8888-8888-888888888888"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare/doctors/hoang-cuong.jpg");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-9999-9999-9999-999999999999"),
                column: "AvatarUrl",
                value: "https://storage.googleapis.com/bookingcare/doctors/nguyen-van-huong.jpg");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111101"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare/specialties/co-xuong-khop.jpg");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111102"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare/specialties/tieu-hoa.jpg");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111103"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare/specialties/tim-mach.jpg");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111104"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare/specialties/san-phu-khoa.jpg");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111105"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare/specialties/nhi-khoa.jpg");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111106"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare/specialties/da-lieu.jpg");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111107"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare/specialties/tai-mui-hong.jpg");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111108"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare/specialties/mat.jpg");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111109"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare/specialties/than-kinh.jpg");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111110"),
                column: "ImageUrl",
                value: "https://storage.googleapis.com/bookingcare/specialties/rang-ham-mat.jpg");
        }
    }
}
