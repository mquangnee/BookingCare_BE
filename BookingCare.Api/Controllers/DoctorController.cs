using BookingCare.Application.Queries.DoctorQuery;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{specialtyId}")]
        [ProducesResponseType(typeof(MethodResult<List<DoctorModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetDoctors([FromRoute] Guid specialtyId)
        {
            var queryResult = await _mediator.Send(new GetDoctorsBySpecialtyQuery { SpecialtyId = specialtyId});
            return queryResult.GetActionResult();
        }
    }
}
