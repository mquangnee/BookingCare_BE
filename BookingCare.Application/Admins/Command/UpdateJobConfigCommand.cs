using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookingCare.Application.Admins.Command
{
    public class UpdateJobConfigCommand : UpdateJobConfigCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class UpdateJobConfigCommandHandler : IRequestHandler<UpdateJobConfigCommand, MethodResult<bool>>
    {
        public Task<MethodResult<bool>> Handle(UpdateJobConfigCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<bool>();

            methodResult.AddErrorBadRequest("ReadOnly", "Configuration", "Job configuration cannot be modified via API. Use appsettings.json to change job settings.");
            return Task.FromResult(methodResult);
        }
    }
}