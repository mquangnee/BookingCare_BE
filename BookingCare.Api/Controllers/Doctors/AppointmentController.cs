using BookingCare.Application.Doctors.Command;
using BookingCare.Application.Doctors.Query;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers.Doctors
{
    [Route("api/doctor/appointment")]
    [ApiController]
    [Authorize(Roles = "Doctor")]
    public class AppointmentController : Controller
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("today")]
        [ProducesResponseType(typeof(MethodResult<List<AppointmentModel>>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAppointmentsToday()
        {
            var queryResult = await _mediator.Send(new GetAppointmentsTodayQuery { });
            return queryResult.GetActionResult();
        }

        [HttpPost("complete")]
        [ProducesResponseType(typeof(MethodResult<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CompleteAppointment([FromBody] SendMedicalReportCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return commandResult.GetActionResult();
        }

        [HttpGet("history")]
        [ProducesResponseType(typeof(MethodResult<List<MedicalHistoryModel>>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetMedicalHistory([FromQuery] string? keyword, [FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var queryResult = await _mediator.Send(new GetMedicalHistoryQuery { Keyword = keyword, FromDate = fromDate, ToDate = toDate });
            return queryResult.GetActionResult();
        }

        [HttpGet("report/{appointmentId}")]
        [ProducesResponseType(typeof(MethodResult<PrescriptionModel>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetMedicalReport([FromRoute] Guid appointmentId)
        {
            var queryResult = await _mediator.Send(new GetMedicalReportQuery { AppointmentId = appointmentId });
            return queryResult.GetActionResult();
        }

        [HttpGet("export/{appointmentId}")]
        [ProducesResponseType(typeof(FileContentResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ExportPrescriptionPdf([FromRoute] Guid appointmentId)
        {
            var queryResult = await _mediator.Send(new GetPrescriptionPdfQuery { AppointmentId = appointmentId });
            
            if (queryResult.StatusCode != StatusCodes.Status200OK || queryResult.Result == null)
            {
                return queryResult.GetActionResult();
            }

            return File(queryResult.Result, "application/pdf", $"Prescription_{appointmentId}.pdf");
        }
    }
}
