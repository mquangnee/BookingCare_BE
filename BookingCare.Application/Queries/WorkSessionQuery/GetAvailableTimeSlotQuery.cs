using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Queries.AppointmentQuery
{
    public class GetAvailableTimeSlotsQuery : IRequest<MethodResult<List<AvailableDayModel>>>
    {
        public Guid DoctorId { get; set; }
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; } = 30;
        public int DaysToFetch { get; set; } = 7;
    }

    public class GetAvailableTimeSlotsQueryHandler : IRequestHandler<GetAvailableTimeSlotsQuery, MethodResult<List<AvailableDayModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAvailableTimeSlotsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<List<AvailableDayModel>>> Handle(GetAvailableTimeSlotsQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<AvailableDayModel>>();
            var resultDays = new List<AvailableDayModel>();

            DateTime startDate = request.Date.Date;
            DateTime endDate = startDate.AddDays(request.DaysToFetch - 1);

            var workSessions = await _unitOfWork.WorkSessions.QueryableAsync()
                .Where(ws => ws.DoctorId == request.DoctorId
                          && ws.StartTime.Date >= startDate
                          && ws.StartTime.Date <= endDate)
                .ToListAsync(cancellationToken);
            var workSessionIds = workSessions.Select(ws => ws.Id).ToList();
            var bookedAppointments = await _unitOfWork.Appointments.QueryableAsync()
                .Where(a => workSessionIds.Contains(a.WorkSessionId) && a.Status != EnumAppointmentStatus.Canceled)
                .Select(a => new { a.WorkSessionId, a.StartTime })
                .ToListAsync(cancellationToken);
            for (int i = 0; i < request.DaysToFetch; i++)
            {
                DateTime currentDate = startDate.AddDays(i);
                var dayModel = new AvailableDayModel
                {
                    Date = currentDate,
                    AvailableTimeSlots = new List<AvailableTimeSlotModel>()
                };

                var sessionsToday = workSessions.Where(ws => ws.StartTime.Date == currentDate).ToList();
                foreach (var session in sessionsToday)
                {
                    var sessionBookedTimes = bookedAppointments
                        .Where(a => a.WorkSessionId == session.Id && a.StartTime.HasValue)
                        .Select(a => a.StartTime.Value)
                        .ToList();
                    TimeSpan currentSlotStart = session.StartTime.TimeOfDay;
                    TimeSpan sessionEnd = session.EndTime.TimeOfDay;
                    TimeSpan step = TimeSpan.FromMinutes(request.DurationInMinutes);
                    while (currentSlotStart.Add(step) <= sessionEnd)
                    {
                        bool isPastSlot = currentDate == DateTime.Now.Date && currentSlotStart < DateTime.Now.TimeOfDay;
                        if (!isPastSlot)
                        {
                            bool isBooked = sessionBookedTimes.Any(booked => booked == currentSlotStart);
                            dayModel.AvailableTimeSlots.Add(new AvailableTimeSlotModel
                            {
                                StartTime = currentSlotStart,
                                EndTime = currentSlotStart.Add(step),
                                IsFull = isBooked
                            });
                        }
                        currentSlotStart = currentSlotStart.Add(step);
                    }
                }
                dayModel.AvailableTimeSlots = dayModel.AvailableTimeSlots.OrderBy(s => s.StartTime).ToList();
                resultDays.Add(dayModel);
            }

            methodResult.Result = resultDays;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}