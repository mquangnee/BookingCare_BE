using BookingCare.Domain.Entities;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BookingCare.Application.Admins.Command
{
    public class ChangeStatusAccountCommand : ChangeStatusAccountCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class ChangeStatusAccountCommandHandler : IRequestHandler<ChangeStatusAccountCommand, MethodResult<bool>>
    {
        private readonly UserManager<User> _userManager;

        public ChangeStatusAccountCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<MethodResult<bool>> Handle(ChangeStatusAccountCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.UserId), request.UserId);
                return methodResult;
            }
            user.LockoutEnd = request.NewStatus == Shared.Enum.EnumAccountStatus.Active ? null : DateTimeOffset.MaxValue;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                methodResult.AddError(nameof(EnumDashboardErrorCode.LockUnlockAccountFailed));
                return methodResult;
            }

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
