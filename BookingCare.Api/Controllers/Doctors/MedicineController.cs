using BookingCare.Application.Doctors.Query;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers.Doctors
{
    [Route("api/doctor/medicine")]
    [ApiController]
    //[Authorize(Roles = "Doctor")]
    public class MedicineController : Controller
    {
        private readonly IMediator _mediator;

        public MedicineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(MethodResult<List<MedicineModel>>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetMedicines()
        {
            var queryResult = await _mediator.Send(new GetMedicinesQuery { });
            return queryResult.GetActionResult();
        }
    }
}
