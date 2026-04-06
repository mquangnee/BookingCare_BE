using BookingCare.Application.Services;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Infrastructure;
using BookingCare.Shared.Enum;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Api.Workers
{
    public class AppointmentReminderWorker
    {
        private readonly DataContext _dbContext;
        private readonly ISenderService _senderService;

        public AppointmentReminderWorker(DataContext dbContext, ISenderService senderService)
        {
            _dbContext = dbContext;
            _senderService = senderService;
        }

        public async Task SendAppointmentSummaryAsync()
        {
            var today = DateTime.Today;

            var appointments = await _dbContext.Appointments
                .Where(a => a.Date.Date == today
                         && a.Status != EnumAppointmentStatus.Cancelled)
                .Include(a => a.Booker)
                .Include(a => a.PatientProfile)
                .Include(a => a.WorkSession)
                    .ThenInclude(ws => ws.Doctor)
                .ToListAsync();
            var grouped = appointments.GroupBy(a => a.BookerId);

            if (!grouped.Any())
            {
                return;
            }

            var user = grouped.FirstOrDefault().Where(a => a.PatientProfile.Relationship == EnumRelationship.MySelf);
            foreach (var group in grouped)
            {
                var booker = group.First().Booker;

                var selfProfile = group
                    .Select(a => a.PatientProfile)
                    .FirstOrDefault(pp => pp.Relationship == EnumRelationship.MySelf);

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
                    Date = today.Date,
                    Appointments = appointmentList
                });
            }
        }
    }
}
