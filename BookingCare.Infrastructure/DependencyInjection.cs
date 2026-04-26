using BookingCare.Application.Appointments.Command;
using BookingCare.Application.Services;
using BookingCare.Domain.IRepository;
using BookingCare.Infrastructure.Maps;
using BookingCare.Infrastructure.Repository;
using BookingCare.Infrastructure.Services;
using BookingCare.Shared.Setting;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BookingCare.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration, 
        IHostEnvironment environment)
    {
        var env = environment.EnvironmentName;

        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(configuration["ConnectionStrings:ConnectedDb"]);
        });
        services.AddScoped<DbContext>(provider => provider.GetRequiredService<DataContext>());

        // Đăng ký Repository
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IPatientProfileRepository, PatientProfileRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
        services.AddScoped<IReceptionistRepository, ReceptionistRepository>();
        services.AddScoped<IProfileShareRepository, ProfileShareRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<INotificationTypeRepository, NotificationTypeRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IWorkSessionRepository, WorkSessionRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
        services.AddScoped<IPrescriptionDetailRepository, PrescriptionDetailRepository>();
        services.AddScoped<IMedicineRepository, MedicineRepository>();

        // Đăng ký Service
        services.AddHttpContextAccessor();
        services.AddScoped<ISenderService, SenderService>();
        services.AddScoped<IOtpService, OtpService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IGeneratorCodeService, GeneratorCodeService>();
        services.AddScoped<INotificationService, NotificationService>();

        services.AddAutoMapper(cfg => { }, typeof(ProfileMap));

        // Backgroung Job configuration
        if (environment.IsDevelopment())
        {

            // Hangfire setup 
            var hangfireConnectionString = configuration.GetConnectionString("HangfireDb");

            // Auto-create Hangfire schema if not exists
            EnsureHangfireSchema(hangfireConnectionString);

            services.AddHangfire(x => x.UseSqlServerStorage(hangfireConnectionString));
            services.AddHangfireServer();

            // Register Hangfire implementation
            services.AddScoped<IBackgroundJobService, HangFireBackgroundJobService>();
            services.AddScoped<ISchedulerService, HangFireBackgroundJobService>();
        }
        else
        {
            services.AddScoped<ILogger<GoogleCloudSchedulerService>, Logger<GoogleCloudSchedulerService>>();
            // Scheduler service
            services.Configure<CloudSchedulerSetting>(configuration.GetSection("GoogleCloud:CloudScheduler"));
            services.AddScoped<ISchedulerService, GoogleCloudSchedulerService>();
            // Task service
            services.Configure<CloudTaskSetting>(configuration.GetSection("GoogleCloud:CloudTask"));
            services.AddScoped<IBackgroundJobService, GoogleCloudTaskService>();
        }
        
        services.Configure<CloudStorageSetting>(configuration.GetSection("GoogleCloud:CloudStorage"));
        services.AddScoped<ICloudStorageService, CloudStorageService>();

        return services;
    }

    public static void ConfigureJobScheduler(this IApplicationBuilder app, IConfiguration configuration, IHostEnvironment environment)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
            var mediator = services.GetRequiredService<IMediator>();
            var schedulerService = services.GetRequiredService<ISchedulerService>();

            var sendAppointmentSummaryUrl = configuration["Jobs:SendAppointmentSummary:Endpoint"] ?? "";
            var sendAppointmentSummaryCronExpression = configuration["Jobs:SendAppointmentSummary:CronExpression"] ?? "0 7 * * *";

            // DEV -> use Hangfire
            if (environment.IsDevelopment())
            {
                app.UseHangfireDashboard();
                schedulerService.AddOrUpdateRecurring(
                    WorkerSetting.JobName.SendEmailDailyAppointmentRemindersName,
                    () => mediator.Send(new SendAppointmentSummaryCommand()),
                    sendAppointmentSummaryCronExpression);
            }
            else
            {
                schedulerService.AddOrUpdateRecurring(
                    WorkerSetting.JobName.SendEmailDailyAppointmentRemindersName,
                    sendAppointmentSummaryUrl,
                    sendAppointmentSummaryCronExpression);
            }
        }
    }

    public static void EnsureHangfireSchema(string connectionString)
    {
        // Hangfire.SqlServer automatically creates its tables when the database exists
        // We just need to ensure the database itself exists
        var builder = new Microsoft.Data.SqlClient.SqlConnectionStringBuilder(connectionString);
        var databaseName = builder.InitialCatalog;
        builder.InitialCatalog = "master"; // Connect to master to create database if needed

        using var masterConnection = new Microsoft.Data.SqlClient.SqlConnection(builder.ConnectionString);
        masterConnection.Open();

        var createDatabaseSql = $"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '{databaseName}') CREATE DATABASE [{databaseName}]";
        using var cmd = new Microsoft.Data.SqlClient.SqlCommand(createDatabaseSql, masterConnection);
        cmd.ExecuteNonQuery();
    }
}
