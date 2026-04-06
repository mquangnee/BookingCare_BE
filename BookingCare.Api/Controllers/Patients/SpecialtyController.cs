using BookingCare.Application.Patients.Queries.SpecialtyQuery;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers.Patients
{
    [Route("api/patient/specialty")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SpecialtyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(MethodResult<List<SpecialtyModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetSpecialties()
        {
            var queryResult = await _mediator.Send(new GetSpecialtiesQuery { });
            return queryResult.GetActionResult();
        }
    }
}
