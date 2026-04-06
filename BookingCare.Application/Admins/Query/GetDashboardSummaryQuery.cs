using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookingCare.Application.Admins.Query
{
    public class GetDashboardSummaryQuery : IRequest<MethodResult<DashboardSummaryModel>>
    {
    }

    public class GetDashboardSummaryQueryHandler : IRequestHandler<GetDashboardSummaryQuery, MethodResult<DashboardSummaryModel>>
    {
        private readonly IMediator _mediator;

        public GetDashboardSummaryQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<MethodResult<DashboardSummaryModel>> Handle(GetDashboardSummaryQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<DashboardSummaryModel>();

            var appointments = await _mediator.Send(new GetTotalAppointmentsQuery { });
            var doctors = await _mediator.Send(new GetTotalDoctorsQuery { });
            var patients = await _mediator.Send(new GetTotalPatientAccountsQuery { });
            var services = await _mediator.Send(new GetTotalServicesQuery { });
            if (appointments.StatusCode != StatusCodes.Status200OK || doctors.StatusCode != StatusCodes.Status200OK || patients.StatusCode != StatusCodes.Status200OK || services.StatusCode != StatusCodes.Status200OK)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.ServerError));
                return methodResult;
            }

            methodResult.Result = new DashboardSummaryModel
            {
                Appointments = appointments.Result,
                Doctors = doctors.Result,
                Patients = patients.Result,
                Services = services.Result
            };
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
