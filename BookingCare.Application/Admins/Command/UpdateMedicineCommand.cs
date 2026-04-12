using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookingCare.Application.Admins.Command
{
    public class UpdateMedicineCommand : UpdateMedicineCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class UpdateMedicineCommandHandler : IRequestHandler<UpdateMedicineCommand, MethodResult<bool>>
    {
        public UpdateMedicineCommandHandler()
        {
        }
        public async Task<MethodResult<bool>> Handle(UpdateMedicineCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
