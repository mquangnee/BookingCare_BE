using BookingCare.Application.Admins.Command;
using BookingCare.Application.Admins.Query;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers.Admins
{
    [Route("api/admin/jobs")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class JobManagementController : Controller
    {
        private readonly IMediator _mediator;

        public JobManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<List<JobConfigModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetJobConfigs()
        {
            var queryResult = await _mediator.Send(new GetJobConfigsQuery { });
            return queryResult.GetActionResult();
        }

        [HttpPut]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateJobConfig([FromBody] UpdateJobConfigCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return commandResult.GetActionResult();
        }

        [HttpPost("trigger")]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> TriggerJob([FromBody] TriggerJobCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return commandResult.GetActionResult();
        }
    }
}