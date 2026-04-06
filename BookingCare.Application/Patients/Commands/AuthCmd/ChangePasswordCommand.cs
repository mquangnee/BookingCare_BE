using BookingCare.Application.Services;
using BookingCare.Domain.Entities;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Patients.Commands.AuthCmd
{
    public class ChangePasswordCommand : ChangePasswordCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, MethodResult<bool>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOtpService _otpService;

        public ChangePasswordCommandHandler(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, IOtpService otpService)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _otpService = otpService;
        }

        public async Task<MethodResult<bool>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            if (request.NewPassword != request.ConfirmPassword)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.ConfirmPasswordNotMatch), nameof(request.ConfirmPassword), request.ConfirmPassword);
                return methodResult;
            }

            var userClaims = _httpContextAccessor.HttpContext?.User;
            var email = userClaims?.FindFirst(ClaimTypes.Email)?.Value;
            var otpCached = string.IsNullOrEmpty(email) ? null : _otpService.GetOtp(email);
            if (otpCached == null || otpCached != request.Otp)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.OtpInvalid), nameof(request.Otp), request.Otp);
                return methodResult;
            }
            var userIdString = userClaims?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? userClaims?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (!Guid.TryParse(userIdString, out var userId))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized), nameof(userId), userId);
                return methodResult;
            }

            var checkOldPassword = await _userManager.CheckPasswordAsync(user, request.OldPassword!);
            if (!checkOldPassword)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.OldPasswordNotMatch), nameof(request.OldPassword), request.OldPassword);
                return methodResult;
            }
            var result = await _userManager.ChangePasswordAsync(user, request.OldPassword!, request.NewPassword!);
            if (!result.Succeeded)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.ChangePasswordFailed));
                return methodResult;
            }

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
