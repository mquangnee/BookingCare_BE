using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Patients.Queries.WorkSessionQuery
{
    public class GetAvailableTimeSlotsQuery : IRequest<MethodResult<List<AvailableDayModel>>>
    {
        public Guid? DoctorId { get; set; }
        public Guid? ServiceId { get; set; }
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

            if (!request.DoctorId.HasValue && !request.ServiceId.HasValue)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Required));
                return methodResult;
            }

            DateTime startDate = request.Date.Date;
            DateTime endDate = startDate.AddDays(request.DaysToFetch - 1);
            var workSessionQuery = _unitOfWork.WorkSessions.QueryableAsync()
                .Include(ws => ws.Doctor)
                .Where(ws => ws.StartTime.Date >= startDate && ws.StartTime.Date <= endDate);
            if (request.DoctorId.HasValue)
            {
                workSessionQuery = workSessionQuery.Where(ws => ws.DoctorId == request.DoctorId.Value);
            }
            else if (request.ServiceId.HasValue)
            {
                var service = await _unitOfWork.Services.QueryableAsync()
                    .FirstOrDefaultAsync(s => s.Id == request.ServiceId.Value, cancellationToken);
                if (service == null)
                {
                    methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(service));
                    return methodResult;
                }
                var validDoctorsQuery = _unitOfWork.Doctors.QueryableAsync()
                    .Where(d => d.SpecialtyId == service.SpecialtyId);
                if (service.Position.HasValue)
                {
                    validDoctorsQuery = validDoctorsQuery.Where(d => d.Position == service.Position.Value);
                }
                var validDoctorIds = await validDoctorsQuery.Select(d => d.Id).ToListAsync(cancellationToken);
                workSessionQuery = workSessionQuery.Where(ws => validDoctorIds.Contains(ws.DoctorId));
            }
            var workSessions = await workSessionQuery.ToListAsync(cancellationToken);
            var workSessionIds = workSessions.Select(ws => ws.Id).ToList();
            var bookedAppointments = await _unitOfWork.Appointments.QueryableAsync()
                .Where(a => workSessionIds.Contains(a.WorkSessionId) && a.Status != EnumAppointmentStatus.Cancelled)
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
                                IsFull = isBooked,
                                DoctorId = session.DoctorId,
                                DoctorName = session.Doctor?.FullName,
                                DoctorPosition = session.Doctor?.Position
                            });
                        }
                        currentSlotStart = currentSlotStart.Add(step);
                    }
                }

                dayModel.AvailableTimeSlots = dayModel.AvailableTimeSlots
                    .OrderBy(s => s.StartTime)
                    .ThenBy(s => s.DoctorName)
                    .ToList();
                resultDays.Add(dayModel);
            }

            methodResult.Result = resultDays;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}