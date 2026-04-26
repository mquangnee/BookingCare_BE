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
            DateTime endDateLimit = startDate.AddDays(request.DaysToFetch);
            int durationInMinutes = request.DurationInMinutes;

            var workSessionQuery = _unitOfWork.WorkSessions.QueryableAsync()
                .Include(ws => ws.Doctor)
                .Where(ws => ws.Date >= startDate && ws.Date < endDateLimit);

            if (request.DoctorId.HasValue)
            {
                var doctor = await _unitOfWork.Doctors.QueryableAsync()
                    .AsNoTracking()
                    .Select(d => new { d.Id, d.SpecialtyId, d.Position })
                    .FirstOrDefaultAsync(d => d.Id == request.DoctorId.Value, cancellationToken);

                if (doctor != null)
                {
                    var serviceQuery = _unitOfWork.Services.QueryableAsync().AsNoTracking()
                        .Where(s => s.SpecialtyId == doctor.SpecialtyId);

                    if (doctor.Position != null)
                    {
                        serviceQuery = serviceQuery.Where(s => s.Position == doctor.Position);
                    }

                    var service = await serviceQuery.Select(s => new { s.DurationInMinutes }).FirstOrDefaultAsync(cancellationToken);
                    if (service != null && service.DurationInMinutes > 0)
                    {
                        durationInMinutes = service.DurationInMinutes;
                    }
                }

                workSessionQuery = workSessionQuery.Where(ws => ws.DoctorId == request.DoctorId.Value);
            }
            else if (request.ServiceId.HasValue)
            {
                var service = await _unitOfWork.Services.QueryableAsync()
                    .AsNoTracking()
                    .Select(s => new { s.Id, s.SpecialtyId, s.Position, s.DurationInMinutes })
                    .FirstOrDefaultAsync(s => s.Id == request.ServiceId.Value, cancellationToken);

                if (service == null)
                {
                    methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(service));
                    return methodResult;
                }

                if (service.DurationInMinutes > 0)
                {
                    durationInMinutes = service.DurationInMinutes;
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
                .Where(a => workSessionIds.Contains(a.WorkSessionId) && a.Status != EnumAppointmentStatus.Cancelled && a.StartTime.HasValue && a.EndTime.HasValue)
                .Select(a => new { a.WorkSessionId, a.StartTime, a.EndTime })
                .ToListAsync(cancellationToken);

            var now = DateTime.Now;
            var nowDate = now.Date;
            var nowTime = now.TimeOfDay;
            var step = TimeSpan.FromMinutes(durationInMinutes);

            for (int i = 0; i < request.DaysToFetch; i++)
            {
                DateTime currentDate = startDate.AddDays(i);
                var dayModel = new AvailableDayModel
                {
                    Date = currentDate,
                    AvailableTimeSlots = new List<AvailableTimeSlotModel>()
                };

                var sessionsToday = workSessions.Where(ws => ws.Date.Date == currentDate).ToList();

                foreach (var session in sessionsToday)
                {
                    var sessionBookedAppointments = bookedAppointments
                        .Where(a => a.WorkSessionId == session.Id)
                        .ToList();

                    TimeSpan currentSlotStart = session.StartTime;
                    TimeSpan sessionEnd = session.EndTime;

                    while (currentSlotStart.Add(step) <= sessionEnd)
                    {
                        TimeSpan currentSlotEnd = currentSlotStart.Add(step);
                        bool isPastSlot = currentDate == nowDate && currentSlotStart < nowTime;

                        bool isBooked = sessionBookedAppointments.Any(a =>
                            (currentSlotStart >= a.StartTime!.Value && currentSlotStart < a.EndTime!.Value) ||
                            (currentSlotEnd > a.StartTime!.Value && currentSlotEnd <= a.EndTime!.Value) ||
                            (currentSlotStart <= a.StartTime!.Value && currentSlotEnd >= a.EndTime!.Value)
                        );

                        dayModel.AvailableTimeSlots.Add(new AvailableTimeSlotModel
                        {
                            WorkSessionId = session.Id,
                            StartTime = currentSlotStart,
                            EndTime = currentSlotEnd,
                            IsFull = isBooked || isPastSlot,
                            DoctorId = session.DoctorId,
                            DoctorName = session.Doctor?.FullName,
                            DoctorPosition = session.Doctor?.Position
                        });

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