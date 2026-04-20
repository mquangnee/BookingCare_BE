using BookingCare.Application.Services;
using Google.Cloud.Tasks.V2;
using Google.Protobuf.WellKnownTypes;
using System.Linq.Expressions;
using HttpMethod = Google.Cloud.Tasks.V2.HttpMethod;
using Task = Google.Cloud.Tasks.V2.Task;

namespace BookingCare.Infrastructure.Services
{
    public class GoogleCloudTaskService : IBackgroundJobService
    {
        private readonly string _projectId;
        private readonly string _locationId;
        private readonly string _queueId;
        private CloudTasksClient? _client;

        public GoogleCloudTaskService(string projectId, string locationId, string queueId)
        {
            _projectId = projectId;
            _locationId = locationId;
            _queueId = queueId;
        }

        private CloudTasksClient Client
        {
            get
            {
                _client ??= CloudTasksClient.Create();
                return _client;
            }
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