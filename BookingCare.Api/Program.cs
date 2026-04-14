using BookingCare.Api.Workers;
using BookingCare.Application.Patients.Commands.AuthCmd;
using BookingCare.Application.Services;
using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Infrastructure;
using BookingCare.Infrastructure.Maps;
using BookingCare.Infrastructure.Repository;
using BookingCare.Infrastructure.Services;
using BookingCare.Shared.Setting;
using BookingCare.Shared.SignalR;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownIPNetworks.Clear();
    options.KnownProxies.Clear();
});

// Kết nối SQL Server
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectedDb"]);
}); 
builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DataContext>());

// Cấu hình Identity
builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

// Cấu hình JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]!)),
        ClockSkew = TimeSpan.Zero
    };
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) &&
                (path.StartsWithSegments(HubSetting.Pattern.NotificationHub) ||
                 path.StartsWithSegments(HubSetting.Pattern.AppointmentHub)))
            {
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        }
    };
});

// Yêu cầu về mật khẩu
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

// Cấu hình Bind JSON vào Class
builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection(JwtSetting.SECTION_NAME));
builder.Services.Configure<SmtpSetting>(builder.Configuration.GetSection(SmtpSetting.SECTION_NAME));
builder.Services.Configure<SepaySetting>(builder.Configuration.GetSection("Sepay"));

// Đăng ký Repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientProfileRepository, PatientProfileRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
builder.Services.AddScoped<IReceptionistRepository, ReceptionistRepository>();
builder.Services.AddScoped<IProfileShareRepository, ProfileShareRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationTypeRepository, NotificationTypeRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IWorkSessionRepository, WorkSessionRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
builder.Services.AddScoped<IPrescriptionDetailRepository, PrescriptionDetailRepository>();
builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentTransactionRepository, PaymentTransactionRepository>();

// Đăng ký Service
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISenderService, SenderService>();
builder.Services.AddScoped<IOtpService, OtpService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IGeneratorCodeService, GeneratorCodeService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddHttpClient<ISepayService, SepayService>();
builder.Services.AddMemoryCache();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(SendRegisterOtpCommand).Assembly);
});
builder.Services.AddCors(options =>
{
    var configuredOrigins = builder.Configuration
        .GetSection("Cors:AllowedOrigins")
        .Get<string[]>() ?? Array.Empty<string>();

    var allowedOrigins = configuredOrigins
        .Where(origin => !string.IsNullOrWhiteSpace(origin))
        .Select(origin => origin.Trim().TrimEnd('/'))
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .ToArray();

    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
builder.Services.AddAutoMapper(cfg => { }, typeof(ProfileMap));
builder.Services.AddSignalR();
builder.Services.AddHangfire(config =>
{
    if (builder.Environment.IsDevelopment())
        config.UseInMemoryStorage();
    else
        config.UseSqlServerStorage(
            builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddHangfireServer();

// Đăng ký Cloud Storage Service
builder.Services.Configure<CloudStorageSetting>(builder.Configuration.GetSection("GoogleCloudStorage"));
builder.Services.AddScoped<ICloudStorageService, CloudStorageService>();

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseForwardedHeaders();

app.UseHangfireDashboard("/hangfire");

var recurringJobManager = app.Services.GetRequiredService<IRecurringJobManager>();

RecurringJob.AddOrUpdate<AppointmentReminderWorker>(
    WorkerSetting.JobName.SendEmailDailyAppointmentReminders,
    job => job.SendAppointmentSummaryAsync(),
     "0 7 * * *");

app.MapHub<NotificationHub>(HubSetting.Pattern.NotificationHub);
app.MapHub<AppointmentHub>(HubSetting.Pattern.AppointmentHub);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
