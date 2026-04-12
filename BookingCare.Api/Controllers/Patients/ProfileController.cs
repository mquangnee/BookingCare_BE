using BookingCare.Application.Patients.Commands.ProfileCmd;
using BookingCare.Application.Patients.Queries.ProfileQuery;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers.Patients
{
    [Route("api/patient/profile")]
    [ApiController]
    [Authorize(Roles = "Patient")]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(MethodResult<PatientProfileModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetPatientProfile([FromQuery] Guid? profileId)
        {
            var queryResult = await _mediator.Send(new GetPatientProfileQuery { ProfileId = profileId });
            return queryResult.GetActionResult();
        }

        [HttpPost("update")]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdatePatientProfile([FromBody] UpdatePatientProfileCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return commandResult.GetActionResult();
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreatePatientProfile([FromBody] CreatePatientProfileCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return commandResult.GetActionResult();
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(MethodResult<List<PatientProfileModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetPatientProfiles()
        {
            var queryResult = await _mediator.Send(new GetFamilyProfilesQuery { });
            return queryResult.GetActionResult();
        }

        [HttpPost("share")]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> SharePatientProfile([FromBody] SharePatientProfileCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return commandResult.GetActionResult();
        }

        [HttpGet("get-shared")]
        [ProducesResponseType(typeof(MethodResult<List<ProfileShareModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetProfileShare()
        {
            var queryResult = await _mediator.Send(new GetSharedProfileQuery { });
            return queryResult.GetActionResult();
        }

        [HttpPost("cancel")]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CancelShareProfile([FromBody] CancelShareProfileCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return commandResult.GetActionResult();
        }

        [HttpGet("available")]
        [ProducesResponseType(typeof(MethodResult<List<PatientProfileModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetUserProfilesForBooking([FromQuery] GetPatientProfilesForBookingQuery query)
        {
            var queryResult = await _mediator.Send(query);
            return queryResult.GetActionResult();
        }
    }
}
