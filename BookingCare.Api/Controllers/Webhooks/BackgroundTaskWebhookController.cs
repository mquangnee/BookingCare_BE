using BookingCare.Application.Appointments.Command;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingCare.Api.Controllers.Webhooks
{
    [ApiController]
    [Route("api/tasks")]
    public class BackgroundTaskWebhookController
    {
        private readonly IMediator _mediator;

        public BackgroundTaskWebhookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("send-appointment-summary")]
        public async Task<IActionResult> SendAppointmentSummary()
        {
            await _mediator.Send(new SendAppointmentSummaryCommand());
            return new VoidMethodResult().GetActionResult();
        }
    }
}