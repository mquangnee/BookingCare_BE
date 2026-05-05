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
    [Route("api/admin/service")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(MethodResult<List<ServiceModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetServices()
        {
            var queryResult = await _mediator.Send(new GetServicesQuery());
            return queryResult.GetActionResult();
        }

        [HttpGet("specialty/{specialtyId}")]
        [ProducesResponseType(typeof(MethodResult<List<ServiceModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetServicesBySpecialty(Guid specialtyId)
        {
            var queryResult = await _mediator.Send(new GetServicesBySpecialtyQuery { SpecialtyId = specialtyId });
            return queryResult.GetActionResult();
        }

        [HttpPut()]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateService([FromBody] UpdateServiceCommand command)
        {
            var result = await _mediator.Send(command);
            return result.GetActionResult();
        }

        [HttpPost()]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceCommand command)
        {
            var result = await _mediator.Send(command);
            return result.GetActionResult();
        }

        [HttpPut("{serviceId}/status")]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ChangeServiceStatus([FromRoute] Guid serviceId)
        {
            var result = await _mediator.Send(new ChangeStatusServiceCommand { ServiceId = serviceId });
            return result.GetActionResult();
        }
    }
}
