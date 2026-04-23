using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BookingCare.Application.Services
{
    public interface IBackgroundJobService
    {
        string Enqueue(Expression<Action> methodCall);
        string Schedule(Expression<Action> methodCall, TimeSpan delay); 
    }
}
