using BookingCare.Application.Services;
using Hangfire;
using System.Linq.Expressions;

namespace BookingCare.Infrastructure.Services
{
    public class HangFireBackgroundJobService : IBackgroundJobService, ISchedulerService
    {
        public string Enqueue(Expression<Action> methodCall)
            => BackgroundJob.Enqueue(methodCall);
        public string Schedule(Expression<Action> methodCall, TimeSpan delay)
            => BackgroundJob.Schedule(methodCall, delay);
        public void AddOrUpdateRecurring(string jobId, Expression<Action> methodCall, string cronExpression)
        {
            TimeZoneInfo timeZone;
            try
            {
                timeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");
            }
            catch (TimeZoneNotFoundException)
            {
                timeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            }

            RecurringJobOptions recurringJobOptions = new RecurringJobOptions
            {
                TimeZone = timeZone
            };

            RecurringJob.AddOrUpdate(jobId, methodCall, cronExpression, recurringJobOptions);
        }
        public void AddOrUpdateRecurring(string jobId, string apiUrl, string cronExpression)
            => throw new NotSupportedException(
                    "Expression-based scheduling is only supported by GoogleCloudScheduler.");

        public void TriggerJob(string jobId)
        {
            RecurringJob.Trigger(jobId);
        }

        public void DisableJob(string jobId)
        {
            RecurringJob.RemoveIfExists(jobId);
        }

        public void EnableJob(string jobId, string cronExpression)
        {
            throw new NotSupportedException(
                "EnableJob requires the original method reference. Use AddOrUpdateRecurring with method call instead.");
        }

        public (bool isEnabled, string? cronExpression, DateTime? nextRun) GetJobStatus(string jobId)
        {
            // Note: Hangfire doesn't expose job status lookup directly via API
            // The JobConfig database table is the source of truth for job status
            // This method returns a default tuple - actual status comes from database
            return (true, null, null);
        }
    }
}