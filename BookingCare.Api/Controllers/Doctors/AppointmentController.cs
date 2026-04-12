using BookingCare.Application.Doctors.Command;
using BookingCare.Application.Doctors.Query;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers.Doctors
{
    [Route("api/doctor/appointment")]
    [ApiController]
    [Authorize(Roles = "Doctor")]
    public class AppointmentController : Controller
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("today")]
        [ProducesResponseType(typeof(MethodResult<List<AppointmentModel>>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAppointmentsToday()
        {
            var queryResult = await _mediator.Send(new GetAppointmentsTodayQuery { });
            return queryResult.GetActionResult();
        }

        [HttpPost("complete")]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CompleteAppointment([FromBody] SendMedicalReportCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return commandResult.GetActionResult();
        }
    }
}
