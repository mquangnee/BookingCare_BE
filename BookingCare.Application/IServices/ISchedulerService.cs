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
    }
}
