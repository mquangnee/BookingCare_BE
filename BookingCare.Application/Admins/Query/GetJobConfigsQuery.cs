using BookingCare.Application.Services;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Setting;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BookingCare.Application.Admins.Query
{
    public class GetJobConfigsQuery : IRequest<MethodResult<List<JobConfigModel>>>
    {
    }

    public class GetJobConfigsQueryHandler : IRequestHandler<GetJobConfigsQuery, MethodResult<List<JobConfigModel>>>
    {
        private readonly IConfiguration _configuration;

        public GetJobConfigsQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<MethodResult<List<JobConfigModel>>> Handle(GetJobConfigsQuery request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<List<JobConfigModel>>();

            var jobs = new List<JobConfigModel>
            {
                new JobConfigModel
                {
                    Id = Guid.Empty.ToString(),
                    JobName = WorkerSetting.JobName.SendEmailDailyAppointmentRemindersName,
                    Description = "Gửi email nhắc lịch hẹn khám bệnh hàng ngày cho bệnh nhân",
                    CronExpression = _configuration["Jobs:SendAppointmentSummary:CronExpression"] ?? "0 7 * * *",
                    IsEnabled = true,
                    Endpoint = _configuration["Jobs:SendAppointmentSummary:Endpoint"] ?? "",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null
                }
            };

            methodResult.Result = jobs;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return Task.FromResult(methodResult);
        }
    }
}