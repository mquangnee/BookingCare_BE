using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BookingCare.Shared.SignalR
{
    [Authorize]
    public class AppointmentHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            Console.WriteLine($"User {userId} vừa kết nối SignalR!");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var userId = Context.UserIdentifier;
            Console.WriteLine($"User {userId} vừa ngắt kết nối!");
            return base.OnDisconnectedAsync(exception);
        }
    }
}
