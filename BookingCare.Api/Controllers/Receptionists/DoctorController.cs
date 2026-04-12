using BookingCare.Application.Receptionists.Query;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers.Receptionists
{
    [Route("api/receptionist/doctor")]
    [ApiController]
    //[Authorize(Roles = "Receptionist")]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
