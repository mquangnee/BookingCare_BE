using BookingCare.Application.Services;
using BookingCare.Shared.Setting;
using Google.Api.Gax.ResourceNames;
using Google.Cloud.Scheduler.V1;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using HttpMethod = Google.Cloud.Scheduler.V1.HttpMethod;

namespace BookingCare.Infrastructure.Services
{
    public class GoogleCloudSchedulerService : ISchedulerService
    {
        private readonly string _projectId;
        private readonly string _locationId;
        private readonly ILogger<GoogleCloudSchedulerService> _logger;
        private CloudSchedulerClient _client;

        public GoogleCloudSchedulerService(
            IOptions<CloudSchedulerSetting> schedulerSetting,
            ILogger<GoogleCloudSchedulerService> logger)
        {
            var settings = schedulerSetting.Value;
            _projectId = settings.ProjectId!;
            _locationId = settings.LocationId!;
            _logger = logger;
            _client = CloudSchedulerClient.Create();
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

            var jobName = JobName.FromProjectLocationJob(_projectId, _locationId, jobId);
            var parent = LocationName.FromProjectLocation(_projectId, _locationId);

            var job = new Job
            {
                Name = jobName.ToString(),
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
                var existingJob = _client.GetJob(jobName);
                job.Name = existingJob.Name;
                _client.UpdateJob(new UpdateJobRequest { Job = job });
                _logger.LogInformation("[GCP Scheduler] Job updated successfully. JobId={JobId}", jobId);
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
            {
                _client.CreateJob(parent, job);
                _logger.LogInformation("[GCP Scheduler] Job created successfully. JobId={JobId}", jobId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GCP Scheduler] Failed to upsert job. JobId={JobId}, Error={Error}", jobId, ex.Message);
                throw;
            }
        }

        public void TriggerJob(string jobId)
        {
            var jobName = JobName.FromProjectLocationJob(_projectId, _locationId, jobId);
            try
            {
                _client.RunJob(jobName);
                _logger.LogInformation("[GCP Scheduler] Job triggered successfully. JobId={JobId}", jobId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GCP Scheduler] Failed to trigger job. JobId={JobId}, Error={Error}", jobId, ex.Message);
                throw;
            }
        }

        public void DisableJob(string jobId)
        {
            var jobName = JobName.FromProjectLocationJob(_projectId, _locationId, jobId);
            try
            {
                var job = _client.GetJob(jobName);
                var updatedJob = new Job
                {
                    Name = job.Name,
                    Schedule = job.Schedule,
                    TimeZone = job.TimeZone,
                    HttpTarget = job.HttpTarget,
                    State = Job.Types.State.Disabled
                };
                _client.UpdateJob(new UpdateJobRequest { Job = updatedJob });
                _logger.LogInformation("[GCP Scheduler] Job disabled successfully. JobId={JobId}", jobId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GCP Scheduler] Failed to disable job. JobId={JobId}, Error={Error}", jobId, ex.Message);
                throw;
            }
        }

        public void EnableJob(string jobId, string cronExpression)
        {
            var jobName = JobName.FromProjectLocationJob(_projectId, _locationId, jobId);
            try
            {
                var job = _client.GetJob(jobName);
                var updatedJob = new Job
                {
                    Name = job.Name,
                    Schedule = cronExpression,
                    TimeZone = job.TimeZone,
                    HttpTarget = job.HttpTarget,
                    State = Job.Types.State.Enabled
                };
                _client.UpdateJob(new UpdateJobRequest { Job = updatedJob });
                _logger.LogInformation("[GCP Scheduler] Job enabled successfully. JobId={JobId}", jobId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GCP Scheduler] Failed to enable job. JobId={JobId}, Error={Error}", jobId, ex.Message);
                throw;
            }
        }

        public (bool isEnabled, string? cronExpression, DateTime? nextRun) GetJobStatus(string jobId)
        {
            var jobName = JobName.FromProjectLocationJob(_projectId, _locationId, jobId);
            try
            {
                var job = _client.GetJob(jobName);
                return (job.State == Job.Types.State.Enabled, job.Schedule, null);
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
            {
                return (false, null, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GCP Scheduler] Failed to get job status. JobId={JobId}, Error={Error}", jobId, ex.Message);
                throw;
            }
        }
    }
}