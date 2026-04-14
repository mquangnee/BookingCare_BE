using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecialtyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receptionists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceptionistCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receptionists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NotificationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsActioned = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_NotificationTypes_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProfileCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitizenId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientProfiles_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ProfileShares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SharedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SharedToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShareStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SharePermission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileShares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileShares_AspNetUsers_SharedByUserId",
                        column: x => x.SharedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileShares_AspNetUsers_SharedToUserId",
                        column: x => x.SharedToUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileShares_PatientProfiles_PatientProfileId",
                        column: x => x.PatientProfileId,
                        principalTable: "PatientProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicePrice = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_BookerId",
                        column: x => x.BookerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_PatientProfiles_PatientProfileId",
                        column: x => x.PatientProfileId,
                        principalTable: "PatientProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalOrderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GatewayResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FailureReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionDetails_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionDetails_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecialtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitizenId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceYears = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecialtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextAvailableAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSessions_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkSessions_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    { new Guid("aaaaaaaa-1111-1111-1111-111111111111"), 0, "admin-c1d2-e3f4-g5h6-78901234567", new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "admin.quang@bookingcare.vn", true, true, null, "ADMIN.QUANG@BOOKINGCARE.VN", "ADMIN.QUANG@BOOKINGCARE.VN", "AQAAAAIAAYagAAAAECAU7CUYk/UpTJd7hNEWSES8GqiNL5WIHG0BzyW15HYZQiF2Bb7hmkveVjC5dMBB4A==", "0988888888", true, null, "ADMIN_SEC_STAMP_001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 3, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "admin.quang@bookingcare.vn" },
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
                table: "Medicines",
                columns: new[] { "Id", "CreatedDate", "Function", "Name", "Status", "Unit", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("073e5869-14fa-2592-6390-72a1d495c689"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Thuốc kháng histamin, điều trị viêm mũi dị ứng, mề đay.", "Loratadine 10mg", "Active", "Tablet", null },
                    { new Guid("184f697a-250b-3603-74a1-83b2e506d79a"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Siro ho chiết xuất lá thường xuân, làm loãng đờm, giảm ho.", "Prospan 100ml", "Active", "Bottle", null },
                    { new Guid("29507a8b-361c-4714-85b2-94c3f617e8ab"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Thuốc chẹn kênh canxi, điều trị tăng huyết áp.", "Amlodipine 5mg", "Active", "Blister", null },
                    { new Guid("3a618b9c-472d-5825-96c3-05d40728f9bc"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Tăng cường sức đề kháng, bổ sung vitamin C.", "Vitamin C 500mg", "Active", "Vial", null },
                    { new Guid("4b729cad-583e-6936-07d4-16e518390acd"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Hỗ trợ điều trị thoái hóa khớp, tăng dịch nhờn sụn khớp.", "Glucosamine Sulfate 1500mg", "Active", "Box", null },
                    { new Guid("5c83adb1-694f-7a47-18e5-27f6294a1bde"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Thuốc gây tê tại chỗ dạng tiêm.", "Lidocaine 2%", "Active", "Ampule", null },
                    { new Guid("6d94bec2-7a50-8b58-29f6-38073a5b2cef"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Điều trị thiếu máu do thiếu vitamin B12, đau dây thần kinh.", "Vitamin B12 1000mcg", "Active", "Ampule", null },
                    { new Guid("a1d8f203-5e94-6f3c-0d3a-1c4b7e3f6023"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Gel bôi ngoài da giảm đau, chống viêm cơ xương khớp.", "Voltaren Emulgel 1% 20g", "Active", "Vial", null },
                    { new Guid("b2e90314-6fa5-704d-1e4b-2d5c8f407134"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Ức chế tiết axit dạ dày, điều trị viêm loét dạ dày - tá tràng.", "Omeprazole 20mg", "Active", "Tablet", null },
                    { new Guid("c3fa1425-70b6-815e-2f5c-3e6d90518245"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Thuốc kháng axit, điều trị cơn đau dạ dày cấp.", "Phosphalugel 20% 20g", "Active", "Bottle", null },
                    { new Guid("d40b2536-81c7-926f-306d-4f7ea1629356"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Điều trị tiêu chảy, nhiễm khuẩn đường ruột.", "Berberin 10mg", "Active", "Bottle", null },
                    { new Guid("e4b6d081-3c72-4d1a-8b1e-9a2f5c1d4e01"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Giảm đau, hạ sốt từ nhẹ đến vừa.", "Paracetamol 500mg", "Active", "Tablet", null },
                    { new Guid("e51c3647-92d8-0370-417e-508fb273a467"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Kháng sinh nhóm Penicillin, điều trị nhiễm khuẩn hô hấp, tai mũi họng.", "Amoxicillin 500mg", "Active", "Blister", null },
                    { new Guid("f5c7e192-4d83-5e2b-9c2f-0b3a6d2e5f12"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Kháng viêm không steroid (NSAID), giảm đau, hạ sốt.", "Ibuprofen 400mg", "Active", "Tablet", null },
                    { new Guid("f62d4758-03e9-1481-528f-6190c384b578"), new DateTime(2026, 4, 9, 17, 4, 5, 0, DateTimeKind.Utc), "Kháng sinh nhóm Macrolid, trị viêm phế quản, viêm phổi.", "Azithromycin 250mg", "Active", "Tablet", null }
                });

            migrationBuilder.InsertData(
                table: "NotificationTypes",
                columns: new[] { "Id", "Content", "CreatedDate", "TemplateMessage" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-1111-4fab-a615-8ad7e60d763a"), "ShareProfileInvite", new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "{0} muốn chia sẻ hồ sơ y tế '{1}' với bạn (Quyền: {2}). Bạn có muốn nhận không?" },
                    { new Guid("b2c3d4e5-2222-4fab-a615-8ad7e60d763a"), "ShareProfileAccepted", new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "{0} đã ĐỒNG Ý nhận quản lý hồ sơ '{1}' của bạn." },
                    { new Guid("c3d4e5f6-3333-4fab-a615-8ad7e60d763a"), "ShareProfileRejected", new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "{0} đã TỪ CHỐI nhận chia sẻ hồ sơ '{1}'." },
                    { new Guid("d4e5f6a7-4444-4fab-a615-8ad7e60d763a"), "ShareProfileRevoked", new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "{0} đã ngừng chia sẻ hồ sơ '{1}' với bạn. Bạn không còn quyền truy cập hồ sơ này." }
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
                table: "Admins",
                columns: new[] { "Id", "AdminCode", "FullName", "IsActive", "UserId" },
                values: new object[] { new Guid("bbbbbbbb-2222-2222-2222-222222222222"), "ADM-001", "Nguyễn Minh Quang", true, new Guid("aaaaaaaa-1111-1111-1111-111111111111") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("34994df5-6435-430c-8fd3-e578da6ed929"), new Guid("aaaaaaaa-1111-1111-1111-111111111111") },
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
                table: "Services",
                columns: new[] { "Id", "CreatedDate", "Description", "DoctorId", "DurationInMinutes", "IsActive", "Name", "Position", "Price", "ServiceCode", "SpecialtyId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("22222222-1111-1111-1111-111111111101"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám và chẩn đoán chuyên sâu các bệnh lý về xương khớp cùng Phó Giáo sư.", null, 15, true, "Khám Phó Giáo sư - Cơ Xương Khớp", "AssociateProfessor", 500000.0, "SRV-KHAM-CK01-PGS", new Guid("11111111-1111-1111-1111-111111111101"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111102"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Tư vấn và điều trị các vấn đề về dạ dày, đại tràng, men gan cao.", null, 15, true, "Khám Thạc sĩ - Tiêu hóa", "Master", 300000.0, "SRV-KHAM-CK02-THS", new Guid("11111111-1111-1111-1111-111111111102"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111103"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám tầm soát cao huyết áp, thiếu máu cơ tim, suy tim.", null, 15, true, "Khám Tiến sĩ - Tim mạch", "DoctorOfPhilosophy", 400000.0, "SRV-KHAM-CK03-TS", new Guid("11111111-1111-1111-1111-111111111103"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111104"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám thai định kỳ, viêm nhiễm phụ khoa thông thường.", null, 15, true, "Khám Bác sĩ chuyên khoa - Sản Phụ khoa", "Doctor", 200000.0, "SRV-KHAM-CK04-BS", new Guid("11111111-1111-1111-1111-111111111104"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111105"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám và chẩn đoán các ca bệnh lý hô hấp, tiêu hóa khó ở trẻ em.", null, 20, true, "Khám Giáo sư - Nhi khoa", "Professor", 800000.0, "SRV-KHAM-CK05-GS", new Guid("11111111-1111-1111-1111-111111111105"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111106"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám mụn, nám, tàn nhang và tư vấn phác đồ chăm sóc da chuẩn y khoa.", null, 15, true, "Khám Thạc sĩ - Da liễu", "Master", 350000.0, "SRV-KHAM-CK06-THS", new Guid("11111111-1111-1111-1111-111111111106"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111107"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám và nội soi Tai Mũi Họng, chỉ định phẫu thuật amidan/VA.", null, 15, true, "Khám Phó Giáo sư - Tai Mũi Họng", "AssociateProfessor", 500000.0, "SRV-KHAM-CK07-PGS", new Guid("11111111-1111-1111-1111-111111111107"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111108"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám chuyên sâu đáy mắt, giác mạc và tư vấn mổ cận Lasik/Phaco.", null, 15, true, "Khám Tiến sĩ - Mắt", "DoctorOfPhilosophy", 400000.0, "SRV-KHAM-CK08-TS", new Guid("11111111-1111-1111-1111-111111111108"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111109"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám rối loạn tiền đình, đau đầu mạn tính, mất ngủ kéo dài.", null, 20, true, "Khám Phó Giáo sư - Thần kinh", "AssociateProfessor", 600000.0, "SRV-KHAM-CK09-PGS", new Guid("11111111-1111-1111-1111-111111111109"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-111111111110"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám tổng quát sức khỏe răng miệng, lên phác đồ niềng răng/trồng Implant.", null, 20, true, "Khám Thạc sĩ - Răng Hàm Mặt", "Master", 300000.0, "SRV-KHAM-CK10-THS", new Guid("11111111-1111-1111-1111-111111111110"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-222222222201"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám các bệnh lý đau mỏi vai gáy, thoái hóa khớp cơ bản.", null, 15, true, "Khám Thạc sĩ/Bác sĩ CKI - Cơ Xương Khớp", "Master", 300000.0, "SRV-KHAM-CK01-THS", new Guid("11111111-1111-1111-1111-111111111101"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-1111-1111-1111-222222222202"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Khám chuyên sâu bệnh lý tiêu hóa phức tạp cùng chuyên gia đầu ngành.", null, 20, true, "Khám Giáo sư - Tiêu hóa", "Professor", 800000.0, "SRV-KHAM-CK02-GS", new Guid("11111111-1111-1111-1111-111111111102"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111101"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Bao gồm thuốc tiêm chính hãng và công thực hiện trực tiếp bởi PGS. Nguyễn Trọng Hưng, giúp bôi trơn và giảm đau khớp gối.", null, 30, true, "Tiêm chất nhờn khớp gối (Hyaluronic Acid)", null, 1500000.0, "SRV-DV-TIEMKHOP", new Guid("11111111-1111-1111-1111-111111111101"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111102"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Nội soi không đau, an toàn, có test vi khuẩn HP. Trực tiếp thực hiện bởi BS. Đỗ Thị Tường Vân.", null, 60, true, "Gói Nội soi kép Dạ dày - Đại tràng Gây mê", null, 2800000.0, "SRV-DV-NOISOIME", new Guid("11111111-1111-1111-1111-111111111102"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111103"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Đánh giá cấu trúc, chức năng tim và vận tốc dòng máu. Trực tiếp thực hiện và đọc kết quả bởi TS. Lê Ngọc Thành.", null, 30, true, "Siêu âm tim Doppler màu", null, 600000.0, "SRV-DV-SIEUAMTIM", new Guid("11111111-1111-1111-1111-111111111103"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111104"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Siêu âm hình thái học thai nhi công nghệ 5D mới nhất, cung cấp video sắc nét. Thực hiện bởi BS. Trần Thị Dung.", null, 30, true, "Siêu âm thai 5D tầm soát dị tật", null, 650000.0, "SRV-DV-SIEUAM5D", new Guid("11111111-1111-1111-1111-111111111104"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111105"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Tìm nguyên nhân gây hen suyễn, viêm da cơ địa cho trẻ. Đọc kết quả trực tiếp bởi GS. Phạm Nhật An.", null, 45, true, "Test lẩy da (Prick test) tìm dị nguyên 60 yếu tố", null, 1800000.0, "SRV-DV-TESTDIUNG", new Guid("11111111-1111-1111-1111-111111111105"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111106"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Bắn laser fractional tái tạo bề mặt da, thu nhỏ lỗ chân lông. Thực hiện trực tiếp bởi ThS. Vũ Nguyệt Minh.", null, 45, true, "Điều trị sẹo rỗ/mụn chuyên sâu bằng Laser CO2", null, 1500000.0, "SRV-DV-LASERCO2", new Guid("11111111-1111-1111-1111-111111111106"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111107"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Sử dụng ống soi siêu nhỏ mềm mại, phù hợp cho cả trẻ em. Trực tiếp thực hiện bởi PGS. Trần Hữu Thắng.", null, 20, true, "Nội soi Tai Mũi Họng Ống Mềm (Không gây buồn nôn)", null, 450000.0, "SRV-DV-NOISOITMH", new Guid("11111111-1111-1111-1111-111111111107"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111108"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Đánh giá các bệnh lý điểm vàng và thần kinh thị giác. TS. Hoàng Cương trực tiếp đọc kết quả.", null, 20, true, "Chụp cắt lớp võng mạc (OCT)", null, 500000.0, "SRV-DV-OCT", new Guid("11111111-1111-1111-1111-111111111108"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111109"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Ghi lại hoạt động điện của não để phát hiện sóng động kinh, u não. Phân tích kết quả bởi PGS. Nguyễn Văn Hướng.", null, 45, true, "Đo điện não đồ (EEG)", null, 650000.0, "SRV-DV-EEG", new Guid("11111111-1111-1111-1111-111111111109"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-111111111110"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Nhổ răng bằng sóng siêu âm không sưng, ít chảy máu. Trực tiếp phẫu thuật bởi ThS. Phạm Như Hải.", null, 60, true, "Tiểu phẫu nhổ răng khôn mọc ngầm bằng Piezotome", null, 2500000.0, "SRV-DV-NHORANGKHON", new Guid("11111111-1111-1111-1111-111111111110"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-222222222204"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Thủ thuật điều trị viêm lộ tuyến cổ tử cung. Thực hiện bởi BS. Trần Thị Dung.", null, 45, true, "Cầm máu và áp lạnh cổ tử cung", null, 1200000.0, "SRV-DV-CATTUYENTUYEN", new Guid("11111111-1111-1111-1111-111111111104"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-3333-3333-3333-222222222210"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Công nghệ tẩy trắng răng cắt lạnh an toàn, lên ngay 2-3 tone màu. Thực hiện bởi ThS. Phạm Như Hải.", null, 60, true, "Tẩy trắng răng Laser Whitening", null, 2200000.0, "SRV-DV-TAYTRANG", new Guid("11111111-1111-1111-1111-111111111110"), new DateTime(2026, 4, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "AvatarUrl", "CitizenId", "DateOfBirth", "Description", "DoctorCode", "ExperienceYears", "FullName", "Gender", "Position", "ServiceId", "SpecialtyId", "UserId", "WorkingHistory" },
                values: new object[,]
                {
                    { new Guid("33333333-0000-0000-0000-000000000000"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_1.jpg", "001083000555", new DateTime(1983, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ giỏi chuyên môn về chỉnh nha và tiểu phẫu răng khôn, luôn đặt tiêu chí thẩm mỹ và an toàn lên hàng đầu.", "BS-010", 17, "Phạm Như Hải", "Male", "Master", new Guid("22222222-3333-3333-3333-111111111110"), new Guid("11111111-1111-1111-1111-111111111110"), new Guid("dddddddd-0000-0000-0000-000000000000"), "Bệnh viện Răng Hàm Mặt Trung Ương (2008-Nay)" },
                    { new Guid("33333333-1111-1111-1111-111111111111"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_2.jpg", "001075000123", new DateTime(1975, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia hàng đầu về các bệnh lý Cơ xương khớp. Nguyên Trưởng khoa Cơ xương khớp Bệnh viện Bạch Mai.", "BS-001", 25, "Nguyễn Trọng Hưng", "Male", "AssociateProfessor", new Guid("22222222-3333-3333-3333-111111111101"), new Guid("11111111-1111-1111-1111-111111111101"), new Guid("dddddddd-1111-1111-1111-111111111111"), "Bệnh viện Bạch Mai (2000-2015); Bệnh viện Đại học Y Hà Nội (2015-Nay)" },
                    { new Guid("33333333-2222-2222-2222-222222222222"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_1.jpg", "001182000456", new DateTime(1982, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Có nhiều năm kinh nghiệm trong lĩnh vực nội soi tiêu hóa không đau. Đã tu nghiệp chuyên sâu tại Nhật Bản.", "BS-002", 18, "Đỗ Thị Tường Vân", "Female", "Master", new Guid("22222222-3333-3333-3333-111111111102"), new Guid("11111111-1111-1111-1111-111111111102"), new Guid("dddddddd-2222-2222-2222-222222222222"), "Bệnh viện Việt Đức (2006-Nay)" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_3.jpg", "001080000789", new DateTime(1980, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ chuyên khoa sâu về can thiệp tim mạch và điều trị các bệnh lý tăng huyết áp, suy tim.", "BS-003", 20, "Lê Ngọc Thành", "Male", "DoctorOfPhilosophy", new Guid("22222222-3333-3333-3333-111111111103"), new Guid("11111111-1111-1111-1111-111111111103"), new Guid("dddddddd-3333-3333-3333-333333333333"), "Bệnh viện Tim Hà Nội (2005-Nay)" },
                    { new Guid("33333333-4444-4444-4444-444444444444"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nu_BacSi_2.jpg", "001188000321", new DateTime(1988, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bác sĩ trẻ tận tâm, giỏi chuyên môn về siêu âm dị tật thai nhi 4D/5D và chăm sóc sức khỏe sinh sản.", "BS-004", 12, "Trần Thị Dung", "Female", "Doctor", new Guid("22222222-3333-3333-3333-111111111104"), new Guid("11111111-1111-1111-1111-111111111104"), new Guid("dddddddd-4444-4444-4444-444444444444"), "Bệnh viện Phụ Sản Trung Ương (2012-Nay)" },
                    { new Guid("33333333-5555-5555-5555-555555555555"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_4.jpg", "001065000654", new DateTime(1965, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia đầu ngành về Nhi khoa. Nguyên Phó Giám đốc Bệnh viện Nhi Trung Ương.", "BS-005", 35, "Phạm Nhật An", "Male", "Professor", new Guid("22222222-3333-3333-3333-111111111105"), new Guid("11111111-1111-1111-1111-111111111105"), new Guid("dddddddd-5555-5555-5555-555555555555"), "Bệnh viện Nhi Trung Ương (1990-Nay)" },
                    { new Guid("33333333-6666-6666-6666-666666666666"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_5.jpg", "001185000111", new DateTime(1985, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia da liễu thẩm mỹ, ứng dụng laser trong điều trị sẹo, nám và các bệnh lý viêm da cơ địa.", "BS-006", 15, "Vũ Nguyệt Minh", "Male", "Master", new Guid("22222222-3333-3333-3333-111111111106"), new Guid("11111111-1111-1111-1111-111111111106"), new Guid("dddddddd-6666-6666-6666-666666666666"), "Bệnh viện Da liễu Trung Ương (2010-Nay)" },
                    { new Guid("33333333-7777-7777-7777-777777777777"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_6.jpg", "001072000222", new DateTime(1972, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phó Giáo sư chuyên thực hiện các ca phẫu thuật Tai Mũi Họng phức tạp, đặc biệt là vi phẫu thanh quản.", "BS-007", 28, "Trần Hữu Thắng", "Male", "AssociateProfessor", new Guid("22222222-3333-3333-3333-111111111107"), new Guid("11111111-1111-1111-1111-111111111107"), new Guid("dddddddd-7777-7777-7777-777777777777"), "Bệnh viện Tai Mũi Họng Trung Ương (1998-Nay)" },
                    { new Guid("33333333-8888-8888-8888-888888888888"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_7.jpg", "001078000333", new DateTime(1978, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiến sĩ chuyên khoa Mắt với nhiều kinh nghiệm trong phẫu thuật Phaco và Lasik điều trị cận thị.", "BS-008", 22, "Hoàng Cương", "Male", "DoctorOfPhilosophy", new Guid("22222222-3333-3333-3333-111111111108"), new Guid("11111111-1111-1111-1111-111111111108"), new Guid("dddddddd-8888-8888-8888-888888888888"), "Bệnh viện Mắt Trung Ương (2002-Nay)" },
                    { new Guid("33333333-9999-9999-9999-999999999999"), "https://storage.googleapis.com/bookingcare-resources/static/doctor/Nam_BacSi_8.jpg", "001068000444", new DateTime(1968, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuyên gia về ngoại thần kinh và thần kinh học lâm sàng. Điều trị thành công hàng ngàn ca rối loạn vận động.", "BS-009", 30, "Nguyễn Văn Hướng", "Male", "AssociateProfessor", new Guid("22222222-3333-3333-3333-111111111109"), new Guid("11111111-1111-1111-1111-111111111109"), new Guid("dddddddd-9999-9999-9999-999999999999"), "Bệnh viện Hữu nghị Việt Đức (1995-Nay)" }
                });

            migrationBuilder.InsertData(
                table: "WorkSessions",
                columns: new[] { "Id", "CreatedDate", "DoctorId", "EndTime", "NextAvailableAt", "ServiceId", "StartTime", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("44444444-7777-7777-7777-000000000001"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1111-1111-1111-111111111111"), new DateTime(2026, 4, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111101"), new DateTime(2026, 4, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000002"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 4, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 14, 13, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111103"), new DateTime(2026, 4, 14, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000003"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-5555-5555-5555-555555555555"), new DateTime(2026, 4, 14, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111105"), new DateTime(2026, 4, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000004"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-2222-2222-2222-222222222222"), new DateTime(2026, 4, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111102"), new DateTime(2026, 4, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000005"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-4444-4444-4444-444444444444"), new DateTime(2026, 4, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 15, 13, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111104"), new DateTime(2026, 4, 15, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000006"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-6666-6666-6666-666666666666"), new DateTime(2026, 4, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111106"), new DateTime(2026, 4, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000007"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-7777-7777-7777-777777777777"), new DateTime(2026, 4, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111107"), new DateTime(2026, 4, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000008"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-8888-8888-8888-888888888888"), new DateTime(2026, 4, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 16, 13, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111108"), new DateTime(2026, 4, 16, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000009"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-9999-9999-9999-999999999999"), new DateTime(2026, 4, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111109"), new DateTime(2026, 4, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000010"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-0000-0000-0000-000000000000"), new DateTime(2026, 4, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111110"), new DateTime(2026, 4, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000011"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1111-1111-1111-111111111111"), new DateTime(2026, 4, 17, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 17, 13, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111101"), new DateTime(2026, 4, 17, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000012"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-4444-4444-4444-444444444444"), new DateTime(2026, 4, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 17, 9, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111104"), new DateTime(2026, 4, 17, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000013"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-5555-5555-5555-555555555555"), new DateTime(2026, 4, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111105"), new DateTime(2026, 4, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000014"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-6666-6666-6666-666666666666"), new DateTime(2026, 4, 18, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 18, 13, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111106"), new DateTime(2026, 4, 18, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000015"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-2222-2222-2222-222222222222"), new DateTime(2026, 4, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 18, 8, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111102"), new DateTime(2026, 4, 18, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000016"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 4, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111103"), new DateTime(2026, 4, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000017"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-7777-7777-7777-777777777777"), new DateTime(2026, 4, 19, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 19, 13, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111107"), new DateTime(2026, 4, 19, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000018"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-8888-8888-8888-888888888888"), new DateTime(2026, 4, 19, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111108"), new DateTime(2026, 4, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000019"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-9999-9999-9999-999999999999"), new DateTime(2026, 4, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111109"), new DateTime(2026, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000020"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-0000-0000-0000-000000000000"), new DateTime(2026, 4, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 13, 30, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-222222222210"), new DateTime(2026, 4, 20, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000021"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-1111-1111-1111-111111111111"), new DateTime(2026, 4, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111101"), new DateTime(2026, 4, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000022"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 4, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-1111-1111-1111-111111111103"), new DateTime(2026, 4, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000023"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-6666-6666-6666-666666666666"), new DateTime(2026, 4, 16, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111106"), new DateTime(2026, 4, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-7777-7777-7777-000000000024"), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-4444-4444-4444-444444444444"), new DateTime(2026, 4, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-3333-3333-3333-111111111104"), new DateTime(2026, 4, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BookerId",
                table: "Appointments",
                column: "BookerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientProfileId",
                table: "Appointments",
                column: "PatientProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_WorkSessionId",
                table: "Appointments",
                column: "WorkSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ServiceId",
                table: "Doctors",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_NotificationTypeId",
                table: "Notifications",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReceiverId",
                table: "Notifications",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SenderId",
                table: "Notifications",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProfiles_PatientId",
                table: "PatientProfiles",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AppointmentId",
                table: "Payments",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_PaymentId",
                table: "PaymentTransactions",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDetails_MedicineId",
                table: "PrescriptionDetails",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDetails_PrescriptionId",
                table: "PrescriptionDetails",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_AppointmentId",
                table: "Prescriptions",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileShares_PatientProfileId",
                table: "ProfileShares",
                column: "PatientProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileShares_SharedByUserId",
                table: "ProfileShares",
                column: "SharedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileShares_SharedToUserId",
                table: "ProfileShares",
                column: "SharedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptionists_UserId",
                table: "Receptionists",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_DoctorId",
                table: "Services",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_SpecialtyId",
                table: "Services",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSessions_DoctorId",
                table: "WorkSessions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSessions_ServiceId",
                table: "WorkSessions",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_WorkSessions_WorkSessionId",
                table: "Appointments",
                column: "WorkSessionId",
                principalTable: "WorkSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Services_ServiceId",
                table: "Doctors",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Services_ServiceId",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PaymentTransactions");

            migrationBuilder.DropTable(
                name: "PrescriptionDetails");

            migrationBuilder.DropTable(
                name: "ProfileShares");

            migrationBuilder.DropTable(
                name: "Receptionists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "NotificationTypes");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "PatientProfiles");

            migrationBuilder.DropTable(
                name: "WorkSessions");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Specialties");
        }
    }
}
