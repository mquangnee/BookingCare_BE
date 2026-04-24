using BookingCare.Application.Patients.Commands.AuthCmd;
using BookingCare.Domain.Entities;
using BookingCare.Infrastructure;
using BookingCare.Shared.Setting;
using BookingCare.Shared.SignalR;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownIPNetworks.Clear();
    options.KnownProxies.Clear();
});

// Call Infra's configuration
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);

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
builder.Services.Configure<GroqSetting>(builder.Configuration.GetSection(GroqSetting.SECTION_NAME));

builder.Services.AddHttpContextAccessor();
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

// SignalR
builder.Services.AddSignalR();
// Controller
builder.Services.AddControllers();
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.FullName);
});
builder.Services.AddSingleton<DinkToPdf.Contracts.IConverter, DinkToPdf.SynchronizedConverter>(provider =>
    new DinkToPdf.SynchronizedConverter(new DinkToPdf.PdfTools()));
builder.Services.AddScoped<BookingCare.Domain.IRepository.IPdfService, BookingCare.Infrastructure.Services.PdfService>();

var app = builder.Build();

app.UseForwardedHeaders();

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

// Config Job Scheduler
app.ConfigureJobScheduler(builder.Configuration, builder.Environment);

app.Run();
