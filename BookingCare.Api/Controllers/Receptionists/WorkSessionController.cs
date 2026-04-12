using BookingCare.Application.Receptionists.Query;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers.Receptionists
{
    [Route("api/receptionist/worksession")]
    [ApiController]
    //[Authorize(Roles = "Receptionist")]
    public class WorkSessionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkSessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{date}")]
        [ProducesResponseType(typeof(MethodResult<List<WorkSessionModel>>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAppointments([FromRoute] DateTime date)
        {
            var queryResult = await _mediator.Send(new GetWorkSessionByDateQuery { Date = date });
            return queryResult.GetActionResult();
        }
    }
}
