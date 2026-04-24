using BookingCare.Application.Doctors.Command;
using BookingCare.Application.Doctors.Query;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers.Doctors
{
    [Route("api/doctor/schedule")]
    [ApiController]
    //[Authorize(Roles = "Doctor")]
    public class ScheduleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ScheduleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{startDate}")]
        [ProducesResponseType(typeof(MethodResult<List<WorkSessionModel>>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetSchedules([FromRoute] DateTime startDate)
        {
            var queryResult = await _mediator.Send(new GetSchedulesQuery { StartDate = startDate });
            return queryResult.GetActionResult();
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(MethodResult<WorkSessionModel>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> RegisterWorkSession([FromBody] RegisterWorkSessionCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return commandResult.GetActionResult();
        }
    }
}
