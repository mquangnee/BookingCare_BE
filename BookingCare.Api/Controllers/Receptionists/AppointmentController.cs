using BookingCare.Application.Receptionists.Command;
using BookingCare.Application.Receptionists.Query;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers.Receptionists
{
    [Route("api/receptionist/appointment")]
    [ApiController]
    [Authorize(Roles = "Receptionist")]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{worksessionId}")]
        [ProducesResponseType(typeof(MethodResult<List<AppointmentModel>>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAppointments([FromRoute] Guid worksessionId)
        {
            var queryResult = await _mediator.Send(new GetAppointmentsByWorkSessionIdQuery { WorkSessionId = worksessionId });
            return queryResult.GetActionResult();
        }

        [HttpPost("status")]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ChangeAppointmentStatus([FromBody] ChangeAppointmentStatusCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return commandResult.GetActionResult();
        }
    }
}