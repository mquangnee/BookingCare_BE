using BookingCare.Application.Patients.Commands.AppointmentCmd;
using BookingCare.Application.Patients.Queries.AppointmentQuery;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers.Patients
{
    [Route("api/patient/appointment")]
    [ApiController]
    [Authorize(Roles = "Patient")]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(MethodResult<PaymentResponseModel>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return commandResult.GetActionResult();
        }

        [HttpGet("booking-history")]
        [ProducesResponseType(typeof(MethodResult<PagedResult<BookingHistoryModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetBookingHistory([FromQuery] GetBookingHistoryQuery query)
        {
            var queryResult = await _mediator.Send(query);
            return queryResult.GetActionResult();
        }

        [HttpPost("cancel/{appointmentId}")]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CancelAppointment([FromRoute] Guid appointmentId)
        {
            var commandResult = await _mediator.Send(new CancelAppointmentCommand { AppointmentId = appointmentId});
            return commandResult.GetActionResult();
        }
    }
}
