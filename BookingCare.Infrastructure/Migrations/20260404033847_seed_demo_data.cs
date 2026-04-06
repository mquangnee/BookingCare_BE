using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seed_demo_data : Migration
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenExpiry", "TwoFactorEnabled", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("dddddddd-0000-0000-0000-000000000000"), 0, "f0j1k2g3-h4i5-6789-3456-78901234569", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.phamnhuhai@bookingcare.vn", true, true, null, "BS.PHAMNHUHAI@BOOKINGCARE.VN", "BS.PHAMNHUHAI@BOOKINGCARE.VN", "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==", "0901234560", true, null, "H3P7O3B3ZV7L7A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.phamnhuhai@bookingcare.vn" },
                    { new Guid("dddddddd-1111-1111-1111-111111111111"), 0, "c1a2b3d4-e5f6-7890-abcd-ef1234567890", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.nguyentronghung@bookingcare.vn", true, true, null, "BS.NGUYENTRONGHUNG@BOOKINGCARE.VN", "BS.NGUYENTRONGHUNG@BOOKINGCARE.VN", "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==", "0901234561", true, null, "YUP7O3B3ZV7L7R", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.nguyentronghung@bookingcare.vn" },
                    { new Guid("dddddddd-2222-2222-2222-222222222222"), 0, "d2b3c4e5-f6a7-8901-bcde-f01234567891", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.dothituongvan@bookingcare.vn", true, true, null, "BS.DOTHITUONGVAN@BOOKINGCARE.VN", "BS.DOTHITUONGVAN@BOOKINGCARE.VN", "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==", "0901234562", true, null, "ZVP7O3B3ZV7L7S", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.dothituongvan@bookingcare.vn" },
                    { new Guid("dddddddd-3333-3333-3333-333333333333"), 0, "e3c4d5f6-a7b8-9012-cdef-01234567892", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.lengocthanh@bookingcare.vn", true, true, null, "BS.LENGOCTHANH@BOOKINGCARE.VN", "BS.LENGOCTHANH@BOOKINGCARE.VN", "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==", "0901234563", true, null, "AWP7O3B3ZV7L7T", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.lengocthanh@bookingcare.vn" },
                    { new Guid("dddddddd-4444-4444-4444-444444444444"), 0, "f4d5e6a7-b8c9-0123-def0-12345678903", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.tranthidung@bookingcare.vn", true, true, null, "BS.TRANTHIDUNG@BOOKINGCARE.VN", "BS.TRANTHIDUNG@BOOKINGCARE.VN", "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==", "0901234564", true, null, "BXP7O3B3ZV7L7U", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.tranthidung@bookingcare.vn" },
                    { new Guid("dddddddd-5555-5555-5555-555555555555"), 0, "a5e6f7b8-c9d0-1234-ef01-23456789014", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.phamnhatan@bookingcare.vn", true, true, null, "BS.PHAMNHATAN@BOOKINGCARE.VN", "BS.PHAMNHATAN@BOOKINGCARE.VN", "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==", "0901234565", true, null, "CYP7O3B3ZV7L7V", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.phamnhatan@bookingcare.vn" },
                    { new Guid("dddddddd-6666-6666-6666-666666666666"), 0, "b6f7g8c9-d0e1-2345-f012-34567890125", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.vunguyetminh@bookingcare.vn", true, true, null, "BS.VUNGUYETMINH@BOOKINGCARE.VN", "BS.VUNGUYETMINH@BOOKINGCARE.VN", "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==", "0901234566", true, null, "DZP7O3B3ZV7L7W", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.vunguyetminh@bookingcare.vn" },
                    { new Guid("dddddddd-7777-7777-7777-777777777777"), 0, "c7g8h9d0-e1f2-3456-0123-45678901236", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.tranhuuthang@bookingcare.vn", true, true, null, "BS.TRANHUUTHANG@BOOKINGCARE.VN", "BS.TRANHUUTHANG@BOOKINGCARE.VN", "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==", "0901234567", true, null, "E0P7O3B3ZV7L7X", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.tranhuuthang@bookingcare.vn" },
                    { new Guid("dddddddd-8888-8888-8888-888888888888"), 0, "d8h9i0e1-f2g3-4567-1234-56789012347", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.hoangcuong@bookingcare.vn", true, true, null, "BS.HOANGCUONG@BOOKINGCARE.VN", "BS.HOANGCUONG@BOOKINGCARE.VN", "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==", "0901234568", true, null, "F1P7O3B3ZV7L7Y", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.hoangcuong@bookingcare.vn" },
                    { new Guid("dddddddd-9999-9999-9999-999999999999"), 0, "e9i0j1f2-g3h4-5678-2345-67890123458", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.nguyenvanhuong@bookingcare.vn", true, true, null, "BS.NGUYENVANHUONG@BOOKINGCARE.VN", "BS.NGUYENVANHUONG@BOOKINGCARE.VN", "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==", "0901234569", true, null, "G2P7O3B3ZV7L7Z", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "bs.nguyenvanhuong@bookingcare.vn" }
                });

            migrationBuilder.InsertData(
                table: "NotificationTypes",
                columns: new[] { "Id", "Content", "CreatedDate", "TemplateMessage" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-1111-4fab-a615-8ad7e60d763a"), 1, new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "{0} muốn chia sẻ hồ sơ y tế '{1}' với bạn (Quyền: {2}). Bạn có muốn nhận không?" },
                    { new Guid("b2c3d4e5-2222-4fab-a615-8ad7e60d763a"), 2, new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "{0} đã ĐỒNG Ý nhận quản lý hồ sơ '{1}' của bạn." },
                    { new Guid("c3d4e5f6-3333-4fab-a615-8ad7e60d763a"), 3, new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "{0} đã TỪ CHỐI nhận chia sẻ hồ sơ '{1}'." },
                    { new Guid("d4e5f6a7-4444-4fab-a615-8ad7e60d763a"), 4, new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "{0} đã ngừng chia sẻ hồ sơ '{1}' với bạn. Bạn không còn quyền truy cập hồ sơ này." }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "SpecialtyCode", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111101"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám và điều trị các bệnh lý về hệ vận động, xương khớp.", "https://storage.googleapis.com/bookingcare-resources/static/specialty/CoXuongKhop.png", "Cơ Xương Khớp", "CK-001", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111102"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên khoa dạ dày, đại tràng, gan mật và nội soi tiêu hóa.", "https://storage.googleapis.com/bookingcare-resources/static/specialty/TieuHoa.png", "Tiêu hóa", "CK-002", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111103"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Điều trị cao huyết áp, suy tim và các bệnh lý mạch vành.", "https://storage.googleapis.com/bookingcare-resources/static/specialty/TimMach.png", "Tim mạch", "CK-003", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111104"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Chăm sóc thai kỳ, sinh sản và các bệnh lý phụ khoa nữ giới.", "https://storage.googleapis.com/bookingcare-resources/static/specialty/SanPhuKhoa.png", "Sản Phụ khoa", "CK-004", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111105"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám và điều trị các bệnh lý thường gặp ở trẻ sơ sinh và trẻ nhỏ.", "https://storage.googleapis.com/bookingcare-resources/static/specialty/NhiKhoa.png", "Nhi khoa", "CK-005", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111106"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Điều trị mụn, nám, dị ứng da và thẩm mỹ công nghệ cao.", "https://storage.googleapis.com/bookingcare-resources/static/specialty/DaLieu.png", "Da liễu", "CK-006", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111107"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám và điều trị viêm xoang, viêm họng, các bệnh lý tai mũi họng.", "https://storage.googleapis.com/bookingcare-resources/static/specialty/TaiMuiHong.png", "Tai Mũi Họng", "CK-007", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111108"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám mắt tổng quát, đo thị lực và điều trị tật khúc xạ.", "https://storage.googleapis.com/bookingcare-resources/static/specialty/Mat.png", "Mắt", "CK-008", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111109"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Chẩn đoán rối loạn thần kinh, đau đầu, tiền đình và não bộ.", "https://storage.googleapis.com/bookingcare-resources/static/specialty/ThanKinh.png", "Thần kinh", "CK-009", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-1111-1111-111111111110"), new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Nha khoa tổng quát, nhổ răng khôn và thẩm mỹ răng sứ.", "https://storage.googleapis.com/bookingcare-resources/static/specialty/RangHamMat.png", "Răng Hàm Mặt", "CK-010", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-0000-0000-0000-000000000000") },
                    { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-1111-1111-1111-111111111111") },
                    { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-2222-2222-2222-222222222222") },
                    { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-3333-3333-3333-333333333333") },
                    { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-4444-4444-4444-444444444444") },
                    { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-5555-5555-5555-555555555555") },
                    { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-6666-6666-6666-666666666666") },
                    { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-7777-7777-7777-777777777777") },
                    { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-8888-8888-8888-888888888888") },
                    { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-9999-9999-9999-999999999999") }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "AvatarUrl", "CitizenId", "DateOfBirth", "Description", "DoctorCode", "ExperienceYears", "FullName", "Gender", "Position", "SpecialtyId", "SubSpecialties", "UserId", "WorkingHistory" },
                values: new object[,]
                {
                    { new Guid("33333333-0000-0000-0000-000000000000"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_1.jpg", "001083000555", new DateTime(1983, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ giỏi chuyên môn về chỉnh nha và tiểu phẫu răng khôn, luôn đặt tiêu chí thẩm mỹ và an toàn lên hàng đầu.", "BS-010", 17, "Phạm Như Hải", 0, 1, new Guid("11111111-1111-1111-1111-111111111110"), "[\"Ni\\u1EC1ng r\\u0103ng th\\u1EA9m m\\u1EF9\",\"Nh\\u1ED5 r\\u0103ng kh\\u00F4n m\\u1ECDc l\\u1EC7ch\"]", new Guid("dddddddd-0000-0000-0000-000000000000"), "Bệnh viện Răng Hàm Mặt Trung Ương (2008-Nay)" },
                    { new Guid("33333333-1111-1111-1111-111111111111"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_2.jpg", "001075000123", new DateTime(1975, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia hàng đầu về các bệnh lý Cơ xương khớp. Nguyên Trưởng khoa Cơ xương khớp Bệnh viện Bạch Mai.", "BS-001", 25, "Nguyễn Trọng Hưng", 0, 3, new Guid("11111111-1111-1111-1111-111111111101"), "[\"N\\u1ED9i c\\u01A1 x\\u01B0\\u01A1ng kh\\u1EDBp\",\"Ph\\u1EE5c h\\u1ED3i ch\\u1EE9c n\\u0103ng\"]", new Guid("dddddddd-1111-1111-1111-111111111111"), "Bệnh viện Bạch Mai (2000-2015); Bệnh viện Đại học Y Hà Nội (2015-Nay)" },
                    { new Guid("33333333-2222-2222-2222-222222222222"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_1_.jpg", "001182000456", new DateTime(1982, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Có nhiều năm kinh nghiệm trong lĩnh vực nội soi tiêu hóa không đau. Đã tu nghiệp chuyên sâu tại Nhật Bản.", "BS-002", 18, "Đỗ Thị Tường Vân", 1, 1, new Guid("11111111-1111-1111-1111-111111111102"), "[\"N\\u1ED9i soi ti\\u00EAu h\\u00F3a\",\"B\\u1EC7nh l\\u00FD gan m\\u1EADt\"]", new Guid("dddddddd-2222-2222-2222-222222222222"), "Bệnh viện Việt Đức (2006-Nay)" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_3.jpg", "001080000789", new DateTime(1980, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ chuyên khoa sâu về can thiệp tim mạch và điều trị các bệnh lý tăng huyết áp, suy tim.", "BS-003", 20, "Lê Ngọc Thành", 0, 2, new Guid("11111111-1111-1111-1111-111111111103"), "[\"Ngo\\u1EA1i tim m\\u1EA1ch\",\"Si\\u00EAu \\u00E2m tim\"]", new Guid("dddddddd-3333-3333-3333-333333333333"), "Bệnh viện Tim Hà Nội (2005-Nay)" },
                    { new Guid("33333333-4444-4444-4444-444444444444"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_2.jpg", "001188000321", new DateTime(1988, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ trẻ tận tâm, giỏi chuyên môn về siêu âm dị tật thai nhi 4D/5D và chăm sóc sức khỏe sinh sản.", "BS-004", 12, "Trần Thị Dung", 1, 0, new Guid("11111111-1111-1111-1111-111111111104"), "[\"Si\\u00EAu \\u00E2m thai k\\u1EF3\",\"V\\u00F4 sinh hi\\u1EBFm mu\\u1ED9n\"]", new Guid("dddddddd-4444-4444-4444-444444444444"), "Bệnh viện Phụ Sản Trung Ương (2012-Nay)" },
                    { new Guid("33333333-5555-5555-5555-555555555555"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_4.jpg", "001065000654", new DateTime(1965, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia đầu ngành về Nhi khoa. Nguyên Phó Giám đốc Bệnh viện Nhi Trung Ương.", "BS-005", 35, "Phạm Nhật An", 0, 4, new Guid("11111111-1111-1111-1111-111111111105"), "[\"Truy\\u1EC1n nhi\\u1EC5m nhi\",\"H\\u00F4 h\\u1EA5p nhi\"]", new Guid("dddddddd-5555-5555-5555-555555555555"), "Bệnh viện Nhi Trung Ương (1990-Nay)" },
                    { new Guid("33333333-6666-6666-6666-666666666666"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_5.jpg", "001185000111", new DateTime(1985, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia da liễu thẩm mỹ, ứng dụng laser trong điều trị sẹo, nám và các bệnh lý viêm da cơ địa.", "BS-006", 15, "Vũ Nguyệt Minh", 1, 1, new Guid("11111111-1111-1111-1111-111111111106"), "[\"\\u0110i\\u1EC1u tr\\u1ECB m\\u1EE5n\",\"Th\\u1EA9m m\\u1EF9 da c\\u00F4ng ngh\\u1EC7 cao\"]", new Guid("dddddddd-6666-6666-6666-666666666666"), "Bệnh viện Da liễu Trung Ương (2010-Nay)" },
                    { new Guid("33333333-7777-7777-7777-777777777777"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_6.jpg", "001072000222", new DateTime(1972, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phó Giáo sư chuyên thực hiện các ca phẫu thuật Tai Mũi Họng phức tạp, đặc biệt là vi phẫu thanh quản.", "BS-007", 28, "Trần Hữu Thắng", 0, 3, new Guid("11111111-1111-1111-1111-111111111107"), "[\"Ph\\u1EABu thu\\u1EADt n\\u1ED9i soi m\\u0169i xoang\",\"C\\u1EAFt amidan\"]", new Guid("dddddddd-7777-7777-7777-777777777777"), "Bệnh viện Tai Mũi Họng Trung Ương (1998-Nay)" },
                    { new Guid("33333333-8888-8888-8888-888888888888"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_7.jpg", "001078000333", new DateTime(1978, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiến sĩ chuyên khoa Mắt với nhiều kinh nghiệm trong phẫu thuật Phaco và Lasik điều trị cận thị.", "BS-008", 22, "Hoàng Cương", 0, 2, new Guid("11111111-1111-1111-1111-111111111108"), "[\"Kh\\u00FAc x\\u1EA1 nh\\u00E3n khoa\",\"\\u0110\\u1EE5c th\\u1EE7y tinh th\\u1EC3\"]", new Guid("dddddddd-8888-8888-8888-888888888888"), "Bệnh viện Mắt Trung Ương (2002-Nay)" },
                    { new Guid("33333333-9999-9999-9999-999999999999"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_8.jpg", "001068000444", new DateTime(1968, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia về ngoại thần kinh và thần kinh học lâm sàng. Điều trị thành công hàng ngàn ca rối loạn vận động.", "BS-009", 30, "Nguyễn Văn Hướng", 0, 3, new Guid("11111111-1111-1111-1111-111111111109"), "[\"\\u0110\\u1ED9ng kinh\",\"Parkinson\",\"\\u0110au \\u0111\\u1EA7u m\\u1EA1n t\\u00EDnh\"]", new Guid("dddddddd-9999-9999-9999-999999999999"), "Bệnh viện Hữu nghị Việt Đức (1995-Nay)" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedDate", "Description", "DoctorId", "DurationInMinutes", "IsActive", "Name", "Position", "Price", "ServiceCode", "SpecialtyId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("22222222-1111-1111-1111-111111111101"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám và chẩn đoán chuyên sâu các bệnh lý về xương khớp cùng Phó Giáo sư.", null, 15, true, "Khám Phó Giáo sư - Cơ Xương Khớp", 3, 500000.0, "SRV-KHAM-CK01-PGS", new Guid("11111111-1111-1111-1111-111111111101"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111102"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Tư vấn và điều trị các vấn đề về dạ dày, đại tràng, men gan cao.", null, 15, true, "Khám Thạc sĩ - Tiêu hóa", 1, 300000.0, "SRV-KHAM-CK02-THS", new Guid("11111111-1111-1111-1111-111111111102"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111103"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám tầm soát cao huyết áp, thiếu máu cơ tim, suy tim.", null, 15, true, "Khám Tiến sĩ - Tim mạch", 2, 400000.0, "SRV-KHAM-CK03-TS", new Guid("11111111-1111-1111-1111-111111111103"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111104"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám thai định kỳ, viêm nhiễm phụ khoa thông thường.", null, 15, true, "Khám Bác sĩ chuyên khoa - Sản Phụ khoa", 0, 200000.0, "SRV-KHAM-CK04-BS", new Guid("11111111-1111-1111-1111-111111111104"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111105"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám và chẩn đoán các ca bệnh lý hô hấp, tiêu hóa khó ở trẻ em.", null, 20, true, "Khám Giáo sư - Nhi khoa", 4, 800000.0, "SRV-KHAM-CK05-GS", new Guid("11111111-1111-1111-1111-111111111105"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111106"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám mụn, nám, tàn nhang và tư vấn phác đồ chăm sóc da chuẩn y khoa.", null, 15, true, "Khám Thạc sĩ - Da liễu", 1, 350000.0, "SRV-KHAM-CK06-THS", new Guid("11111111-1111-1111-1111-111111111106"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111107"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám và nội soi Tai Mũi Họng, chỉ định phẫu thuật amidan/VA.", null, 15, true, "Khám Phó Giáo sư - Tai Mũi Họng", 3, 500000.0, "SRV-KHAM-CK07-PGS", new Guid("11111111-1111-1111-1111-111111111107"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111108"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám chuyên sâu đáy mắt, giác mạc và tư vấn mổ cận Lasik/Phaco.", null, 15, true, "Khám Tiến sĩ - Mắt", 2, 400000.0, "SRV-KHAM-CK08-TS", new Guid("11111111-1111-1111-1111-111111111108"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111109"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám rối loạn tiền đình, đau đầu mạn tính, mất ngủ kéo dài.", null, 20, true, "Khám Phó Giáo sư - Thần kinh", 3, 600000.0, "SRV-KHAM-CK09-PGS", new Guid("11111111-1111-1111-1111-111111111109"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111110"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám tổng quát sức khỏe răng miệng, lên phác đồ niềng răng/trồng Implant.", null, 20, true, "Khám Thạc sĩ - Răng Hàm Mặt", 1, 300000.0, "SRV-KHAM-CK10-THS", new Guid("11111111-1111-1111-1111-111111111110"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-222222222201"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám các bệnh lý đau mỏi vai gáy, thoái hóa khớp cơ bản.", null, 15, true, "Khám Thạc sĩ/Bác sĩ CKI - Cơ Xương Khớp", 1, 300000.0, "SRV-KHAM-CK01-THS", new Guid("11111111-1111-1111-1111-111111111101"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-222222222202"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám chuyên sâu bệnh lý tiêu hóa phức tạp cùng chuyên gia đầu ngành.", null, 20, true, "Khám Giáo sư - Tiêu hóa", 4, 800000.0, "SRV-KHAM-CK02-GS", new Guid("11111111-1111-1111-1111-111111111102"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111101"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Bao gồm thuốc tiêm chính hãng và công thực hiện trực tiếp bởi PGS. Nguyễn Trọng Hưng, giúp bôi trơn và giảm đau khớp gối.", new Guid("33333333-1111-1111-1111-111111111111"), 30, true, "Tiêm chất nhờn khớp gối (Hyaluronic Acid)", null, 1500000.0, "SRV-DV-TIEMKHOP", new Guid("11111111-1111-1111-1111-111111111101"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111102"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Nội soi không đau, an toàn, có test vi khuẩn HP. Trực tiếp thực hiện bởi BS. Đỗ Thị Tường Vân.", new Guid("33333333-2222-2222-2222-222222222222"), 60, true, "Gói Nội soi kép Dạ dày - Đại tràng Gây mê", null, 2800000.0, "SRV-DV-NOISOIME", new Guid("11111111-1111-1111-1111-111111111102"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111103"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Đánh giá cấu trúc, chức năng tim và vận tốc dòng máu. Trực tiếp thực hiện và đọc kết quả bởi TS. Lê Ngọc Thành.", new Guid("33333333-3333-3333-3333-333333333333"), 30, true, "Siêu âm tim Doppler màu", null, 600000.0, "SRV-DV-SIEUAMTIM", new Guid("11111111-1111-1111-1111-111111111103"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111104"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Siêu âm hình thái học thai nhi công nghệ 5D mới nhất, cung cấp video sắc nét. Thực hiện bởi BS. Trần Thị Dung.", new Guid("33333333-4444-4444-4444-444444444444"), 30, true, "Siêu âm thai 5D tầm soát dị tật", null, 650000.0, "SRV-DV-SIEUAM5D", new Guid("11111111-1111-1111-1111-111111111104"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111105"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Tìm nguyên nhân gây hen suyễn, viêm da cơ địa cho trẻ. Đọc kết quả trực tiếp bởi GS. Phạm Nhật An.", new Guid("33333333-5555-5555-5555-555555555555"), 45, true, "Test lẩy da (Prick test) tìm dị nguyên 60 yếu tố", null, 1800000.0, "SRV-DV-TESTDIUNG", new Guid("11111111-1111-1111-1111-111111111105"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111106"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Bắn laser fractional tái tạo bề mặt da, thu nhỏ lỗ chân lông. Thực hiện trực tiếp bởi ThS. Vũ Nguyệt Minh.", new Guid("33333333-6666-6666-6666-666666666666"), 45, true, "Điều trị sẹo rỗ/mụn chuyên sâu bằng Laser CO2", null, 1500000.0, "SRV-DV-LASERCO2", new Guid("11111111-1111-1111-1111-111111111106"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111107"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Sử dụng ống soi siêu nhỏ mềm mại, phù hợp cho cả trẻ em. Trực tiếp thực hiện bởi PGS. Trần Hữu Thắng.", new Guid("33333333-7777-7777-7777-777777777777"), 20, true, "Nội soi Tai Mũi Họng Ống Mềm (Không gây buồn nôn)", null, 450000.0, "SRV-DV-NOISOITMH", new Guid("11111111-1111-1111-1111-111111111107"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111108"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Đánh giá các bệnh lý điểm vàng và thần kinh thị giác. TS. Hoàng Cương trực tiếp đọc kết quả.", new Guid("33333333-8888-8888-8888-888888888888"), 20, true, "Chụp cắt lớp võng mạc (OCT)", null, 500000.0, "SRV-DV-OCT", new Guid("11111111-1111-1111-1111-111111111108"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111109"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Ghi lại hoạt động điện của não để phát hiện sóng động kinh, u não. Phân tích kết quả bởi PGS. Nguyễn Văn Hướng.", new Guid("33333333-9999-9999-9999-999999999999"), 45, true, "Đo điện não đồ (EEG)", null, 650000.0, "SRV-DV-EEG", new Guid("11111111-1111-1111-1111-111111111109"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111110"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Nhổ răng bằng sóng siêu âm không sưng, ít chảy máu. Trực tiếp phẫu thuật bởi ThS. Phạm Như Hải.", new Guid("33333333-0000-0000-0000-000000000000"), 60, true, "Tiểu phẫu nhổ răng khôn mọc ngầm bằng Piezotome", null, 2500000.0, "SRV-DV-NHORANGKHON", new Guid("11111111-1111-1111-1111-111111111110"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-222222222204"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Thủ thuật điều trị viêm lộ tuyến cổ tử cung. Thực hiện bởi BS. Trần Thị Dung.", new Guid("33333333-4444-4444-4444-444444444444"), 45, true, "Cầm máu và áp lạnh cổ tử cung", null, 1200000.0, "SRV-DV-CATTUYENTUYEN", new Guid("11111111-1111-1111-1111-111111111104"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-222222222210"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Công nghệ tẩy trắng răng cắt lạnh an toàn, lên ngay 2-3 tone màu. Thực hiện bởi ThS. Phạm Như Hải.", new Guid("33333333-0000-0000-0000-000000000000"), 60, true, "Tẩy trắng răng Laser Whitening", null, 2200000.0, "SRV-DV-TAYTRANG", new Guid("11111111-1111-1111-1111-111111111110"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "WorkSessions",
                columns: new[] { "Id", "CreatedDate", "DoctorId", "EndTime", "NextAvailableAt", "ServiceId", "StartTime", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("44444444-5555-5555-5555-111111111111"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1111-1111-1111-111111111111"), new DateTime(2026, 4, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111101"), new DateTime(2026, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-5555-5555-5555-555555555555"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-4444-4444-4444-444444444444"), new DateTime(2026, 4, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111104"), new DateTime(2026, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-5555-5555-5555-777777777777"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-5555-5555-5555-555555555555"), new DateTime(2026, 4, 8, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111105"), new DateTime(2026, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-6666-6666-6666-000000000000"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-6666-6666-6666-666666666666"), new DateTime(2026, 4, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111106"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-6666-6666-6666-444444444444"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-0000-0000-0000-000000000000"), new DateTime(2026, 4, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 8, 13, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111110"), new DateTime(2026, 4, 8, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-5555-5555-5555-222222222222"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1111-1111-1111-111111111111"), new DateTime(2026, 4, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 8, 13, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111101"), new DateTime(2026, 4, 8, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-5555-5555-5555-333333333333"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-2222-2222-2222-222222222222"), new DateTime(2026, 4, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111102"), new DateTime(2026, 4, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-5555-5555-5555-444444444444"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 4, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 9, 13, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111103"), new DateTime(2026, 4, 9, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-5555-5555-5555-666666666666"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-4444-4444-4444-444444444444"), new DateTime(2026, 4, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111104"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-5555-5555-5555-888888888888"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-5555-5555-5555-555555555555"), new DateTime(2026, 4, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 9, 8, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111105"), new DateTime(2026, 4, 9, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-5555-5555-5555-999999999999"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-6666-6666-6666-666666666666"), new DateTime(2026, 4, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111106"), new DateTime(2026, 4, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-6666-6666-6666-111111111111"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-7777-7777-7777-777777777777"), new DateTime(2026, 4, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 9, 13, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111107"), new DateTime(2026, 4, 9, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-6666-6666-6666-222222222222"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-8888-8888-8888-888888888888"), new DateTime(2026, 4, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111108"), new DateTime(2026, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-6666-6666-6666-333333333333"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-9999-9999-9999-999999999999"), new DateTime(2026, 4, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 13, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111109"), new DateTime(2026, 4, 10, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-6666-6666-6666-555555555555"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-0000-0000-0000-000000000000"), new DateTime(2026, 4, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-222222222210"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) }
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
                keyValue: new Guid("eb0a010d-c0ed-4fb9-a9a7-96a1a1fdc04c"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-0000-0000-0000-000000000000") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-5555-5555-5555-555555555555") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-6666-6666-6666-666666666666") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-7777-7777-7777-777777777777") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-8888-8888-8888-888888888888") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"), new Guid("dddddddd-9999-9999-9999-999999999999") });

            migrationBuilder.DeleteData(
                table: "NotificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-1111-4fab-a615-8ad7e60d763a"));

            migrationBuilder.DeleteData(
                table: "NotificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-2222-4fab-a615-8ad7e60d763a"));

            migrationBuilder.DeleteData(
                table: "NotificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-3333-4fab-a615-8ad7e60d763a"));

            migrationBuilder.DeleteData(
                table: "NotificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-4444-4fab-a615-8ad7e60d763a"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-1111-1111-1111-111111111102"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-1111-1111-1111-111111111103"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-1111-1111-1111-111111111107"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-1111-1111-1111-111111111108"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-1111-1111-1111-111111111109"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-1111-1111-1111-222222222201"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-1111-1111-1111-222222222202"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-3333-3333-3333-111111111110"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-3333-3333-3333-222222222204"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-5555-5555-5555-111111111111"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-5555-5555-5555-222222222222"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-5555-5555-5555-333333333333"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-5555-5555-5555-444444444444"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-5555-5555-5555-666666666666"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-5555-5555-5555-777777777777"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-5555-5555-5555-888888888888"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-5555-5555-5555-999999999999"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-6666-6666-6666-000000000000"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-6666-6666-6666-111111111111"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-6666-6666-6666-222222222222"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-6666-6666-6666-333333333333"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-6666-6666-6666-444444444444"));

            migrationBuilder.DeleteData(
                table: "WorkSessions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-6666-6666-6666-555555555555"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7ae82885-3b95-46f9-aa2b-6f81e3a19e27"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-1111-1111-1111-111111111101"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-1111-1111-1111-111111111104"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-1111-1111-1111-111111111105"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-1111-1111-1111-111111111106"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-1111-1111-1111-111111111110"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-3333-3333-3333-111111111101"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-3333-3333-3333-111111111102"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-3333-3333-3333-111111111103"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-3333-3333-3333-111111111104"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-3333-3333-3333-111111111105"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-3333-3333-3333-111111111106"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-3333-3333-3333-111111111107"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-3333-3333-3333-111111111108"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-3333-3333-3333-111111111109"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22222222-3333-3333-3333-222222222210"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111101"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111102"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111103"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111104"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111105"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111106"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111107"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111108"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111109"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111110"));
        }
    }
}
