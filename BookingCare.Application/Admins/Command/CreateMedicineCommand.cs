using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookingCare.Application.Admins.Command
{
    public class CreateMedicineCommand : CreateMedicineCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class CreateMedicineCommandHandler : IRequestHandler<CreateMedicineCommand, MethodResult<bool>>
    {
        public CreateMedicineCommandHandler()
        {
        }
        public async Task<MethodResult<bool>> Handle(CreateMedicineCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
