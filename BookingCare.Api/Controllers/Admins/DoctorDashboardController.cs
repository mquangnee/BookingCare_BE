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
    [Route("api/admin/doctor")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DoctorDashboardController : Controller
    {
        private readonly IMediator _mediator;

        public DoctorDashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(MethodResult<DashboardMetricModel<DoctorModel>>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetTotalDoctors()
        {
            var queryResult = await _mediator.Send(new GetTotalDoctorsQuery { });
            return queryResult.GetActionResult();
        }

        [HttpPost("update")]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateDoctorProfile([FromForm] UpdateDoctorProfileCommand command)
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
        public async Task<IActionResult> CreateDoctorAccount([FromForm] CreateDoctorAccountCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return commandResult.GetActionResult();
        }

        [HttpGet("service/{serviceId}")]
        [ProducesResponseType(typeof(MethodResult<ServiceModel>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetDoctorsByService([FromRoute] Guid serviceId)
        {
            var queryResult = await _mediator.Send(new GetDoctorsByServiceQuery { ServiceId = serviceId });
            return queryResult.GetActionResult();
        }
    }
}
