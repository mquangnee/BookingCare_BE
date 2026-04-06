using BookingCare.Application.Services;
using BookingCare.Domain.Entities;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Enum.ErrorCode;
using BookingCare.Shared.Setting;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Patients.Commands.AuthCmd
{
    public class SendChangePasswordOtpCommand : ChangePasswordCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class SendChangePasswordOtpCommandHandler : IRequestHandler<SendChangePasswordOtpCommand, MethodResult<bool>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOtpService _otpService;
        private readonly ISenderService _senderService;

        public SendChangePasswordOtpCommandHandler(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, IOtpService otpService, ISenderService senderService)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _otpService = otpService;
            _senderService = senderService;
        }

        public async Task<MethodResult<bool>> Handle(SendChangePasswordOtpCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();
            
            if (request.NewPassword != request.ConfirmPassword)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.ConfirmPasswordNotMatch), nameof(request.ConfirmPassword), request.ConfirmPassword);
                return methodResult;
            }
            var userClaims = _httpContextAccessor.HttpContext?.User;
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
            var email = userClaims?.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }
            _otpService.SetOtp(email);
            var templateData = new Dictionary<string, string>
            {
                { EmailConstants.Keys.Email, email },
                { EmailConstants.Keys.Otp, _otpService.GetOtp(email) }
            };

            await _senderService.SendEmailAsync(
                to: email,
                subject: EmailConstants.Subjects.ChangePasswordOtp,
                templateName: EnumSenderTemplate.SendOtpChangePassword.ToString(),
                templateData: templateData
            );

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
