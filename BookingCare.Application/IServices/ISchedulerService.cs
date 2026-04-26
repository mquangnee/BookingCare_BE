using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BookingCare.Application.Services
{
    public interface ISchedulerService
    {
        void AddOrUpdateRecurring(string jobId, Expression<Action> methodCall, string cronExpression);

        void AddOrUpdateRecurring(string jobId, string apiUrl, string cronExpression);

        void TriggerJob(string jobId);

        void DisableJob(string jobId);

        void EnableJob(string jobId, string cronExpression);

        (bool isEnabled, string? cronExpression, DateTime? nextRun) GetJobStatus(string jobId);
    }
}