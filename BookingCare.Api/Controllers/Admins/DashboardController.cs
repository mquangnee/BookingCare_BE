using BookingCare.Application.Admins.Query;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingCare.Api.Controllers.Admins
{
    [Route("api/admin/dashboard")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("summary")]
        [ProducesResponseType(typeof(MethodResult<DashboardSummaryModel>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetDashboardSummary()
        {
            var queryResult = await _mediator.Send(new GetDashboardSummaryQuery { });
            return queryResult.GetActionResult();
        }

        [HttpGet("booking-chart")]
        [ProducesResponseType(typeof(MethodResult<List<ChartDataModel>>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetWeeklyBookingStatistics()
        {
            var queryResult = await _mediator.Send(new GetWeeklyBookingStatisticsQuery { });
            return queryResult.GetActionResult();
        }

        [HttpGet("specialty-chart")]
        [ProducesResponseType(typeof(MethodResult<List<SpecialtyDistributionModel>>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetWeeklySpecialtyDistribution()
        {
            var queryResult = await _mediator.Send(new GetWeeklySpecialtyDistributionQuery { });
            return queryResult.GetActionResult();
        }
    }
}
