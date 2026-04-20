using BookingCare.Application.Services;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BookingCare.Infrastructure.Services
{
    public class HangFireBackgroundJobService : IBackgroundJobService, ISchedulerService
    {
        public string Enqueue(Expression<Action> methodCall)
            => BackgroundJob.Enqueue(methodCall);
        public string Schedule(Expression<Action> methodCall, TimeSpan delay)
            => BackgroundJob.Schedule(methodCall, delay);
        public void AddOrUpdateRecurring(string jobId, Expression<Action> methodCall, string cronExpression)
            => RecurringJob.AddOrUpdate(jobId, methodCall, cronExpression);
        public void AddOrUpdateRecurring(string jobId, string apiUrl, string cronExpression)
            =>  throw new NotSupportedException(
                    "Expression-based scheduling is only supported by GoogleCloudScheduler.");
    }
}