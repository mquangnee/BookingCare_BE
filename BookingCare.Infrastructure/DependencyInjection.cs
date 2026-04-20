using BookingCare.Application.Appointments.Command;
using BookingCare.Application.IServices;
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
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IPaymentTransactionRepository, PaymentTransactionRepository>();
        services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
        services.AddScoped<IChatSessionRepository, ChatSessionRepository>();

        // Đăng ký Service
        services.AddHttpContextAccessor();
        services.AddScoped<ISenderService, SenderService>();
        services.AddScoped<IOtpService, OtpService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IGeneratorCodeService, GeneratorCodeService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddHttpClient<ISepayService, SepayService>();
        services.AddHttpClient<IAiAssistantService, AiAssistantService>();

        services.AddAutoMapper(cfg => { }, typeof(ProfileMap));

        // Backgroung Job configuration
        if (environment.IsDevelopment())
        {
            // Hangfire setup
            services.AddHangfire(x => x.UseSqlServerStorage(configuration.GetConnectionString("HangfireDb")));
            services.AddHangfireServer();

            // Register Hangfire implementation
            services.AddScoped<IBackgroundJobService, HangFireBackgroundJobService>();
            services.AddScoped<ISchedulerService, HangFireBackgroundJobService>();
        }
        else
        {
            services.Configure<CloudSchedulerSetting>(configuration.GetSection("GoogleCloud:CloudScheduler"));
            services.AddScoped<GoogleCloudTaskService>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<CloudSchedulerSetting>>().Value;
                return new GoogleCloudTaskService(options.ProjectId!, options.LocationId!, options.QueueId!);
            });
            services.AddScoped<ILogger<GoogleCloudSchedulerService>, Logger<GoogleCloudSchedulerService>>();
            services.AddScoped<ISchedulerService, GoogleCloudSchedulerService>();
        }
        
        services.Configure<CloudStorageSetting>(configuration.GetSection("GoogleCloud:CloudStorage"));
        services.AddScoped<ICloudStorageService, CloudStorageService>();

        return services;
    }

    public static void ConfigureJobScheduler(this IApplicationBuilder app, IConfiguration configuration, IHostEnvironment environment)
    {
        var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>()
            .CreateLogger("JobSchedulerBootstrapper");

        logger.LogInformation("[JobScheduler] Starting configuration. Environment={Env}", environment.EnvironmentName);

        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;

            var mediator = services.GetRequiredService<IMediator>();
            var schedulerService = services.GetRequiredService<ISchedulerService>();

            var sendAppointmentSummaryUrl = configuration["Jobs:SendAppointmentSummary:Endpoint"] ?? "";
            var sendAppointmentSummaryCronExpression = configuration["Jobs:SendAppointmentSummary:CronExpression"] ?? "0 7 * * *";

            logger.LogInformation("[JobScheduler] Job config loaded. URL={Url}, Cron={Cron}", sendAppointmentSummaryUrl, sendAppointmentSummaryCronExpression);

            if (environment.IsDevelopment())
            {
                logger.LogInformation("[JobScheduler] Development mode detected — using HangFire inline handler");
                app.UseHangfireDashboard();

                schedulerService.AddOrUpdateRecurring(
                    WorkerSetting.JobName.SendEmailDailyAppointmentRemindersName,
                    () => mediator.Send(new SendAppointmentSummaryCommand()),
                    sendAppointmentSummaryCronExpression);

                logger.LogInformation("[JobScheduler] HangFire recurring job registered. JobId={JobId}", WorkerSetting.JobName.SendEmailDailyAppointmentRemindersName);
            }
            else
            {
                logger.LogInformation("[JobScheduler] Production mode detected — using GCP Cloud Scheduler with URL endpoint");

                schedulerService.AddOrUpdateRecurring(
                    WorkerSetting.JobName.SendEmailDailyAppointmentRemindersName,
                    sendAppointmentSummaryUrl,
                    sendAppointmentSummaryCronExpression);

                logger.LogInformation("[JobScheduler] GCP Cloud Scheduler job registered. JobId={JobId}, Uri={Uri}", WorkerSetting.JobName.SendEmailDailyAppointmentRemindersName, sendAppointmentSummaryUrl);
            }
        }

        logger.LogInformation("[JobScheduler] Configuration complete");
    }
}
