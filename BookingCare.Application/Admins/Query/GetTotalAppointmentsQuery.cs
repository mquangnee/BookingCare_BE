using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Admins.Query
{
    public class GetTotalAppointmentsQuery : IRequest<MethodResult<DashboardMetricModel<AppointmentModel>>>
    {
    }

    public class GetTotalAppointmentsQueryHandler : IRequestHandler<GetTotalAppointmentsQuery, MethodResult<DashboardMetricModel<AppointmentModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTotalAppointmentsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<DashboardMetricModel<AppointmentModel>>> Handle(GetTotalAppointmentsQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<DashboardMetricModel<AppointmentModel>>();

            var today = DateTime.Now;
            var yesterday = today.AddDays(-1);

            var totalAppointmentsToday = await _unitOfWork.Appointments
                .QueryableAsync()
                .Where(a => a.CreatedDate == today)
                .Select(a => new AppointmentModel
                {
                    Id = a.Id,
                    AppointmentCode = a.AppointmentCode,
                    BookerId = a.BookerId,
                    WorkSessionId = a.WorkSessionId,
                    PatientProfileId = a.PatientProfileId,
                    Date = a.Date,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime
                })
                .ToListAsync(cancellationToken);
            var totalAppointmentsYesterday = await _unitOfWork.Appointments
                .QueryableAsync()
                .Where(a => a.CreatedDate == yesterday)
                .Select(a => new AppointmentModel
                {
                    Id = a.Id,
                    AppointmentCode = a.AppointmentCode,
                    BookerId = a.BookerId,
                    WorkSessionId = a.WorkSessionId,
                    PatientProfileId = a.PatientProfileId,
                    Date = a.Date,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime
                })
                .ToListAsync(cancellationToken);

            double balance = totalAppointmentsYesterday.Count > 0 ? (double)(totalAppointmentsToday.Count - totalAppointmentsYesterday.Count) / totalAppointmentsYesterday.Count * 100 : 0.0;
            var dashboardModel = new DashboardMetricModel<AppointmentModel>
            {
                Data = totalAppointmentsToday,
                Total = totalAppointmentsToday.Count,
                Balance = balance
            };
            methodResult.Result = dashboardModel;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
