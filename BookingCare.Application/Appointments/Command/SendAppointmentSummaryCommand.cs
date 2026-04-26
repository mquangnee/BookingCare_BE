using BookingCare.Application.Services;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Appointments.Command
{
    public class SendAppointmentSummaryCommand : IRequest
    {
    }

    public class SendAppointmentSummaryCommandHandler : IRequestHandler<SendAppointmentSummaryCommand>
    {
        private readonly ISenderService _senderService;
        private readonly IUnitOfWork _unitOfWork;

        public SendAppointmentSummaryCommandHandler(IUnitOfWork unitOfWork, ISenderService senderService)
        {
            _unitOfWork = unitOfWork;
            _senderService = senderService;
        }

        public async Task Handle(SendAppointmentSummaryCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var today = DateTime.Today;

            var appointments = await _unitOfWork.Appointments.QueryableAsync()
                .Where(a => a.Date.Date == today
                         && a.Status != EnumAppointmentStatus.Cancelled)
                .Include(a => a.Booker)
                .Include(a => a.PatientProfile)
                .Include(a => a.WorkSession)
                    .ThenInclude(ws => ws!.Doctor)
                .ToListAsync();

            if (appointments.Count == 0)
            {
                return;
            }

            var grouped = appointments.GroupBy(a => a.BookerId);

            foreach (var group in grouped)
            {
                var booker = group.First().Booker;

                var selfProfile = group
                    .Select(a => a.PatientProfile)
                    .FirstOrDefault(pp => pp != null && pp.Relationship == EnumRelationship.MySelf);

                var displayName = selfProfile?.FullName ?? booker?.UserName;

                var appointmentList = group
                    .OrderBy(a => a.StartTime)
                    .Select(a => new AppointmentSummaryModel
                    {
                        PatientName = a.PatientProfile?.FullName,
                        DoctorName = a.WorkSession?.Doctor?.FullName,
                        Date = a.Date.ToString("dd/MM/yyyy"),
                        StartTime = a.StartTime,
                        EndTime = a.EndTime
                    })
                    .ToList();

                await _senderService.SendDailySummaryAsync(new DailySummaryEmailModel
                {
                    ToEmail = booker?.Email,
                    BookerName = displayName,
                    Date = today,
                    Appointments = appointmentList
                });
            }
        }
    }
}
