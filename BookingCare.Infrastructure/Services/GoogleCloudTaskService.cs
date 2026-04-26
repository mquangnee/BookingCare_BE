using BookingCare.Application.Services;
using Google.Cloud.Tasks.V2;
using BookingCare.Shared.Setting;
using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace BookingCare.Infrastructure.Services
{
    public class GoogleCloudTaskService : IBackgroundJobService
    {
        private readonly string _projectId;
        private readonly string _locationId;
        private readonly string _queueId;
        private CloudTasksClient _client;

        public GoogleCloudTaskService(
            IOptions<CloudTaskSetting> taskSetting, 
            ILogger<GoogleCloudSchedulerService> logger)
        {
            var settings = taskSetting.Value;
            _projectId = settings.ProjectId!;
            _locationId = settings.LocationId!;
            _queueId = settings.QueueId!;
            // Create service client
            _client = CloudTasksClient.Create();
        }

        public string Enqueue(Expression<Action> methodCall)
        {
            throw new NotSupportedException(
                "Expression-based enqueueing is only supported by HangFire.");
        }

        public string Schedule(Expression<Action> methodCall, TimeSpan delay)
        {
            throw new NotSupportedException(
                "Expression-based scheduling is only supported by HangFire.");
        }
    }
}