using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookingCare.Application.Admins.Command
{
    public class ChangeStatusMedicineCommand : ChangeStatusMedicineCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class ChangeStatusMedicineCommandHandler : IRequestHandler<ChangeStatusMedicineCommand, MethodResult<bool>>
    {
        public async Task<MethodResult<bool>> Handle(ChangeStatusMedicineCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
