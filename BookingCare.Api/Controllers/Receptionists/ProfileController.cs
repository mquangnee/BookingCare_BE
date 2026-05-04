using BookingCare.Application.Receptionists.Query;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers.Receptionists
{
    [Route("api/receptionist/profile")]
    [ApiController]
    [Authorize(Roles = "Receptionist")]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<ReceptionistModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetReceptionistProfile()
        {
            var queryResult = await _mediator.Send(new GetReceptionistProfileQuery());
            return queryResult.GetActionResult();
        }
    }
}
