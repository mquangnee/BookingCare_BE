using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BookingCare.Shared.SignalR
{
    [Authorize]
    public class AppointmentHub : Hub
    {
        public async Task JoinDoctorGroup(Guid userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"doctor_{userId}");
        }

        public async Task LeaveDoctorGroup(Guid doctorId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"doctor_{doctorId}");
        }
    }
}
