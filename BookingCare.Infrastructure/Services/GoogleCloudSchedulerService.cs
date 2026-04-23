using BookingCare.Application.Services;
using BookingCare.Shared.Setting;
using Google.Api.Gax.ResourceNames;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Scheduler.V1;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Linq.Expressions;
using System.Net;
using HttpMethod = Google.Cloud.Scheduler.V1.HttpMethod;

namespace BookingCare.Infrastructure.Services
{
    public class GoogleCloudSchedulerService : ISchedulerService
    {
        private readonly string _projectId;
        private readonly string _locationId;
        private readonly ILogger<GoogleCloudSchedulerService> _logger;

        public GoogleCloudSchedulerService(
            IOptions<CloudSchedulerSetting> schedulerSetting, 
            ILogger<GoogleCloudSchedulerService> logger)
        {
            var settings = schedulerSetting.Value;
            _projectId = settings.ProjectId!;
            _locationId = settings.LocationId!;
            _logger = logger;
        }

        public void AddOrUpdateRecurring(string jobId, Expression<Action> methodCall, string cronExpression)
        {
            throw new NotSupportedException(
                "Expression-based scheduling is only supported by HangFire. Use the apiUrl overload in production.");
        }

        public void AddOrUpdateRecurring(string jobId, string apiUrl, string cronExpression)
        {
            if (string.IsNullOrEmpty(apiUrl) || string.IsNullOrEmpty(cronExpression))
            {
                _logger.LogWarning("[GCP Scheduler] Skipped job registration: apiUrl or cronExpression is empty. JobId={JobId}", jobId);
                return;
            }

            // Automatically uses Cloud Run’s service account identity
            CloudSchedulerClient client = CloudSchedulerClient.Create();

            var parent = LocationName.FromProjectLocation(_projectId, _locationId);
            var job = new Job
            {
                Name = JobName.FromProjectLocationJob(_projectId, _locationId, jobId).ToString(),
                Schedule = cronExpression,
                TimeZone = "Asia/Ho_Chi_Minh",
                HttpTarget = new HttpTarget
                {
                    HttpMethod = HttpMethod.Post,
                    Uri = apiUrl
                }
            };

            try
            {
                client.CreateJob(parent, job);
                _logger.LogInformation("[GCP Scheduler] Job created successfully. JobId={JobId}", jobId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GCP Scheduler] Failed to create job. JobId={JobId}, Error={Error}", jobId, ex.Message);
                throw;
            }
        }
    }
}