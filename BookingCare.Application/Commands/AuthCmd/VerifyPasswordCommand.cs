using BookingCare.Application.Services;
using BookingCare.Domain.Entities;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Infrastructure.Enums.ErrorCode;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BookingCare.Application.Commands.AuthCmd
{
    public class VerifyPasswordCommand : VerifyPasswordCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class VerifyPasswordCommandHandler : IRequestHandler<VerifyPasswordCommand, MethodResult<bool>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IOtpService _otpService;

        public VerifyPasswordCommandHandler(IOtpService otpService, UserManager<User> userManager)
        {
            _userManager = userManager;
            _otpService = otpService;
        }

        public async Task<MethodResult<bool>> Handle(VerifyPasswordCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Required), nameof(request.Email), request.Email);
                return methodResult;
            }
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.EmailNotExistOrInvalid), nameof(request.Email), request.Email);
                return methodResult;
            }
            var cachedOtp = _otpService.GetOtp(request.Email!);
            if (request.Otp != cachedOtp)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.OtpInvalid), nameof(request.Otp), request.Otp);
                return methodResult;
            }
            if (request.NewPassword != request.ConfirmNewPassword)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.ConfirmPasswordNotMatch), nameof(request.ConfirmNewPassword), request.ConfirmNewPassword);
                return methodResult;
            }

            var removeResult = await _userManager.RemovePasswordAsync(user);
            if (!removeResult.Succeeded)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.VerifyPasswordFailed), nameof(request.Email), request.Email);
                return methodResult;
            }
            var addResult = await _userManager.AddPasswordAsync(user, request.NewPassword!);
            if (!addResult.Succeeded)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.VerifyPasswordFailed), nameof(request.Email), request.Email);
                return methodResult;
            }

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
