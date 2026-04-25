using BookingCare.Application.Admins.Command;
using BookingCare.Application.Admins.Query;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers.Admins
{
    [Route("api/admin/receptionist")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ReceptionistDashboardController : Controller
    {
        private readonly IMediator _mediator;

        public ReceptionistDashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(MethodResult<DashboardMetricModel<ReceptionistModel>>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetTotalReceptionists()
        {
            var queryResult = await _mediator.Send(new GetTotalReceptionistsQuery { });
            return queryResult.GetActionResult();
        }

        [HttpPost("update")]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateReceptionistProfile([FromForm] UpdateReceptionistProfileCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return commandResult.GetActionResult();
        }

        [HttpPost("lock-unlock")]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ChangeStatusAccount([FromBody] ChangeStatusAccountCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return commandResult.GetActionResult();
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateReceptionistAccount([FromForm] CreateReceptionistAccountCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return commandResult.GetActionResult();
        }
    }
}