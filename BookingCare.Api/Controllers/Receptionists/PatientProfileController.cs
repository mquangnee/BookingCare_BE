using BookingCare.Application.Receptionists.Command;
using BookingCare.Application.Receptionists.Query;
using BookingCare.Domain.Entities;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers.Receptionists
{
    [Route("api/receptionist/profile")]
    [ApiController]
    //[Authorize(Roles = "Receptionist")]
    public class PatientProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search")]
        [ProducesResponseType(typeof(MethodResult<List<PatientProfileModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> SearchPatientProfiles([FromQuery] string? keyword)
        {
            var queryResult = await _mediator.Send(new SearchPatientProfileQuery { Keyword = keyword });
            return queryResult.GetActionResult();
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(MethodResult<PatientProfile>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreatePatientProfile([FromBody] CreatePatientProfileCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return commandResult.GetActionResult();
        }
    }
}
