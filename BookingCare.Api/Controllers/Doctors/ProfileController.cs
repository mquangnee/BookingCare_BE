using BookingCare.Application.Doctors.Query;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers.Doctors
{
    [Route("api/doctor/profile")]
    [ApiController]
    //[Authorize(Roles = "Doctor")]
    public class ProfileController : Controller
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(MethodResult<DoctorModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetDoctorProfile()
        {
            var queryResult = await _mediator.Send(new GetDoctorProfileQuery { });
            return queryResult.GetActionResult();
        }
    }
}
