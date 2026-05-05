# 🏥 BookingCare — Backend API

> Hệ thống đặt lịch khám bệnh trực tuyến — Backend RESTful API xây dựng trên nền tảng ASP.NET Core theo kiến trúc Clean Architecture.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-94%25-239120?style=flat-square&logo=csharp)
![Docker](https://img.shields.io/badge/Docker-ready-2496ED?style=flat-square&logo=docker)
![License](https://img.shields.io/badge/license-MIT-green?style=flat-square)

---

## 📖 Giới thiệu dự án

**BookingCare** là một hệ thống đặt lịch khám bệnh trực tuyến, cho phép bệnh nhân tìm kiếm bác sĩ, xem lịch làm việc và đặt lịch hẹn khám bệnh một cách tiện lợi. Đây là phần **Backend API** của hệ thống, đảm nhận toàn bộ logic nghiệp vụ, xác thực người dùng và giao tiếp với cơ sở dữ liệu.

Dự án được xây dựng theo mô hình **Clean Architecture**, giúp tách biệt rõ ràng các tầng nghiệp vụ, dễ dàng mở rộng, bảo trì và kiểm thử. Hệ thống được đóng gói bằng Docker và hỗ trợ triển khai lên môi trường đám mây (Google Cloud Run).

---

## 👥 Các đối tượng sử dụng

| Đối tượng | Mô tả |
|---|---|
| **Bệnh nhân** | Tìm kiếm bác sĩ, xem lịch khám, đặt lịch hẹn và quản lý lịch sử khám bệnh |
| **Bác sĩ** | Quản lý lịch làm việc, xem danh sách bệnh nhân đặt lịch, cập nhật thông tin cá nhân |
| **Phòng khám / Bệnh viện** | Quản lý đội ngũ bác sĩ, chuyên khoa và lịch trực của cơ sở |
| **Quản trị viên (Admin)** | Quản lý toàn bộ hệ thống, phân quyền người dùng, theo dõi hoạt động |
| **Lập trình viên / Frontend** | Tích hợp qua RESTful API để xây dựng giao diện web hoặc mobile |

---

## 🎯 Mục đích xây dựng

- Số hóa quy trình đặt lịch khám bệnh, giảm thiểu tình trạng chờ đợi và quá tải tại các cơ sở y tế.
- Cung cấp nền tảng kết nối bệnh nhân với bác sĩ một cách minh bạch, nhanh chóng và thuận tiện.
- Xây dựng một Backend API chuẩn hóa, có thể tích hợp với nhiều loại giao diện (web, mobile).
- Ứng dụng kiến trúc phần mềm hiện đại (Clean Architecture) nhằm đảm bảo khả năng mở rộng và bảo trì lâu dài.
- Thực hành triển khai CI/CD và container hóa ứng dụng với Docker trên môi trường đám mây.

---

## ⚙️ Các chức năng chính

### Xác thực & Phân quyền
- Đăng ký, đăng nhập tài khoản (JWT Authentication)
- Phân quyền theo vai trò: Admin, Bác sĩ, Bệnh nhân
- Refresh token, đổi mật khẩu, quên mật khẩu

### Quản lý người dùng
- Tạo, cập nhật, xóa tài khoản người dùng
- Quản lý hồ sơ cá nhân (thông tin, ảnh đại diện)
- Phân quyền và quản lý vai trò

### Quản lý bác sĩ
- Thêm/sửa/xóa thông tin bác sĩ
- Liên kết bác sĩ với chuyên khoa và phòng khám
- Tìm kiếm và lọc bác sĩ theo chuyên khoa, địa điểm

### Quản lý phòng khám & chuyên khoa
- Quản lý thông tin phòng khám, cơ sở y tế
- Quản lý danh mục chuyên khoa

### Quản lý lịch khám
- Bác sĩ thiết lập lịch làm việc (khung giờ khám)
- Bệnh nhân đặt lịch hẹn khám theo khung giờ trống
- Hủy lịch hẹn, xác nhận lịch hẹn
- Gửi thông báo/email nhắc lịch khám

### Lịch sử & Hồ sơ khám bệnh
- Xem lịch sử đặt lịch của bệnh nhân
- Theo dõi trạng thái lịch hẹn (chờ xác nhận, đã xác nhận, đã khám, đã hủy)

### Quản trị hệ thống
- Dashboard thống kê tổng quan
- Quản lý toàn bộ người dùng và lịch khám

---

## 🛠️ Công nghệ sử dụng

### Backend & Framework
| Công nghệ | Mô tả |
|---|---|
| **ASP.NET Core (.NET 10)** | Framework chính để xây dựng RESTful API |
| **C#** | Ngôn ngữ lập trình chính (chiếm ~95% codebase) |
| **Entity Framework Core** | ORM để tương tác với cơ sở dữ liệu |
| **JWT (JSON Web Token)** | Xác thực và phân quyền người dùng |

### Kiến trúc
| Pattern | Mô tả |
|---|---|
| **Clean Architecture** | Tách biệt Domain, Application, Infrastructure, API |
| **CQRS / MediatR** | Phân tách Command và Query trong tầng Application |
| **Repository Pattern** | Trừu tượng hóa tầng truy cập dữ liệu |

### DevOps & Triển khai
| Công nghệ | Mô tả |
|---|---|
| **Docker** | Container hóa ứng dụng |
| **GitHub Actions** | CI/CD tự động build và deploy |
| **Google Cloud Run** | Nền tảng triển khai đám mây (port 8080) |

### Cấu trúc dự án
```
BookingCare_BE/
├── BookingCare.Api/            # Presentation Layer — Controllers, Middleware, Startup
├── BookingCare.Application/    # Application Layer — Use Cases, CQRS, DTOs
├── BookingCare.Domain/         # Domain Layer — Entities, Interfaces, Business Rules
├── BookingCare.Infrastructure/ # Infrastructure Layer — EF Core, Repositories, Services
├── BookingCare.Shared/         # Shared — Constants, Helpers, Common Models
├── Dockerfile                  # Docker build config
└── BookingCare_BE.slnx         # Solution file
```

---

## 🚀 Cài đặt và sử dụng

### Yêu cầu hệ thống

- [.NET SDK 10.0+](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started) (tùy chọn, để chạy bằng container)
- SQL Server hoặc PostgreSQL (tùy cấu hình)
- Git

---

### 1. Clone repository

```bash
git clone https://github.com/mquangnee/BookingCare_BE.git
cd BookingCare_BE
```

---

### 2. Cấu hình môi trường

Tạo file `appsettings.Development.json` trong thư mục `BookingCare.Api/` và điền các thông tin cần thiết:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BookingCareDB;User Id=sa;Password=YourPassword;"
  },
  "JwtSettings": {
    "SecretKey": "your-secret-key-here",
    "Issuer": "BookingCareAPI",
    "Audience": "BookingCareClient",
    "ExpiryMinutes": 60
  },
  "EmailSettings": {
    "SmtpHost": "smtp.gmail.com",
    "SmtpPort": 587,
    "SenderEmail": "your-email@gmail.com",
    "SenderPassword": "your-app-password"
  }
}
```

---

### 3. Chạy Migration & Tạo database

```bash
cd BookingCare.Api
dotnet ef database update
```

---

### 4. Chạy ứng dụng (Local)

```bash
dotnet restore
dotnet run --project BookingCare.Api
```

API sẽ chạy tại: `https://localhost:5001` hoặc `http://localhost:5000`

Swagger UI: `https://localhost:5001/swagger`

---

### 5. Chạy bằng Docker

**Build image:**
```bash
docker build -t bookingcare-be .
```

**Chạy container:**
```bash
docker run -d \
  -p 8080:8080 \
  -e ConnectionStrings__DefaultConnection="your-connection-string" \
  -e JwtSettings__SecretKey="your-secret-key" \
  --name bookingcare-api \
  bookingcare-be
```

API sẽ chạy tại: `http://localhost:8080`

---

### 6. Chạy bằng Docker Compose (khuyến nghị)

Tạo file `docker-compose.yml`:

```yaml
version: '3.8'
services:
  api:
    build: .
    ports:
      - "8080:8080"
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ConnectionStrings__DefaultConnection=Server=db;Database=BookingCareDB;User Id=sa;Password=YourPassword!
    depends_on:
      - db

  db:
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      SA_PASSWORD: "YourPassword!"
      ACCEPT_EULA: "Y"
    ports:
      - "1433:1433"
```

```bash
docker-compose up -d
```

---

## 🔗 Liên kết liên quan

- 🌐 Repository: [github.com/mquangnee/BookingCare_BE](https://github.com/mquangnee/BookingCare_BE)
- 📘 Swagger API Docs: có tại `/swagger` khi chạy ở môi trường Development

---

## 📄 Giấy phép

Dự án được phát triển cho mục đích học tập và nghiên cứu. Mọi đóng góp đều được chào đón!
