using BookingCare.Application.Admins.Query;
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

        [HttpGet("specialty/{specialtyId}")]
        [ProducesResponseType(typeof(MethodResult<List<ServiceModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetServicesBySpecialty(Guid specialtyId)
        {
            var queryResult = await _mediator.Send(new GetServicesBySpecialtyQuery { SpecialtyId = specialtyId });
            return queryResult.GetActionResult();
        }
    }
}
