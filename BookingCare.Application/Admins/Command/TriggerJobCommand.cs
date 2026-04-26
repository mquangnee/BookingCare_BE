using BookingCare.Application.Appointments.Command;
using BookingCare.Domain.IRepository;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using BookingCare.Shared.Setting;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookingCare.Application.Admins.Command
{
    public class TriggerJobCommand : IRequest<MethodResult<bool>>
    {
        public string JobName { get; set; } = string.Empty;
    }

    public class TriggerJobCommandHandler : IRequestHandler<TriggerJobCommand, MethodResult<bool>>
    {
        private readonly IMediator _mediator;

        public TriggerJobCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<MethodResult<bool>> Handle(TriggerJobCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            if (request.JobName == WorkerSetting.JobName.SendEmailDailyAppointmentRemindersName)
            {
                try
                {
                    await _mediator.Send(new SendAppointmentSummaryCommand(), cancellationToken);
                }
                catch (Exception ex)
                {
                    methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.ServerError), "Job execution failed", ex.Message);
                    return methodResult;
                }
            }
            else
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), "JobName", request.JobName);
                return methodResult;
            }

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}