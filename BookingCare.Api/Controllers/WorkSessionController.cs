using BookingCare.Application.Queries.AppointmentQuery;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers
{
    [Route("api/worksession")]
    [ApiController]
    public class WorkSessionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkSessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("available")]
        [ProducesResponseType(typeof(MethodResult<List<AvailableDayModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAvailableTimeSlots([FromQuery] GetAvailableTimeSlotsQuery query)
        {
            var queryResult = await _mediator.Send(query);
            return queryResult.GetActionResult();
        }
    }
}
