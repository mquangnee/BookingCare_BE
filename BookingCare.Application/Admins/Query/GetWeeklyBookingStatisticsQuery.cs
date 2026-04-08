using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Setting;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Admins.Query
{
    public class GetWeeklyBookingStatisticsQuery : IRequest<MethodResult<List<ChartDataModel>>>
    {
    }

    public class GetWeeklyBookingStatisticsQueryHandler : IRequestHandler<GetWeeklyBookingStatisticsQuery, MethodResult<List<ChartDataModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetWeeklyBookingStatisticsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<List<ChartDataModel>>> Handle(GetWeeklyBookingStatisticsQuery request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<List<ChartDataModel>>();

            var today = DateTime.Today;
            int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
            var startOfWeek = today.AddDays(-1 * diff);
            var endOfWeek = startOfWeek.AddDays(7);

            var appointmentData = await _unitOfWork.Appointments
                .QueryableAsync()
                .Where(a => a.Date >= startOfWeek && a.Date < endOfWeek)
                .GroupBy(a => a.Date.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    Count = g.Count()
                })
                .ToListAsync(cancellationToken);

            var finalChartData = new List<ChartDataModel>();
            for (int i = 0; i < 7; i++)
            {
                var date = startOfWeek.AddDays(i);
                var dayData = appointmentData.FirstOrDefault(x => x.Date == date);

                finalChartData.Add(new ChartDataModel
                {
                    Date = date,
                    Label = GetVietnameseDayName(date),
                    Value = dayData?.Count ?? 0
                });
            }

            methodResult.Result = finalChartData;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }

        private string GetVietnameseDayName(DateTime date)
        {
            return date.DayOfWeek switch
            {
                DayOfWeek.Monday => ChartSetting.VietnameseDayName.Monday,
                DayOfWeek.Tuesday => ChartSetting.VietnameseDayName.Tuesday,
                DayOfWeek.Wednesday => ChartSetting.VietnameseDayName.Wednesday,
                DayOfWeek.Thursday => ChartSetting.VietnameseDayName.Thursday,
                DayOfWeek.Friday => ChartSetting.VietnameseDayName.Friday,
                DayOfWeek.Saturday => ChartSetting.VietnameseDayName.Saturday,
                DayOfWeek.Sunday => ChartSetting.VietnameseDayName.Sunday,
                _ => date.ToString("dd/MM")
            };
        }
    }
}