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

namespace BookingCare.Application.Patients.Commands.AuthCmd
{
    public class SendVerifyPasswordOtpCommand : VerifyPasswordCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class SendVerifyPasswordOtpCommandHandler : IRequestHandler<SendVerifyPasswordOtpCommand, MethodResult<bool>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IOtpService _otpService;
        private readonly ISenderService _senderService;

        public SendVerifyPasswordOtpCommandHandler(UserManager<User> userManager, IOtpService otpService, ISenderService senderService)
        {
            _userManager = userManager;
            _otpService = otpService;
            _senderService = senderService;
        }

        public async Task<MethodResult<bool>> Handle(SendVerifyPasswordOtpCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            if (string.IsNullOrEmpty(request.Email))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Required), nameof(request.Email), request.Email);
                return methodResult;
            }
            var user = await _userManager.FindByEmailAsync(request.Email!);
            if (user == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.EmailNotExistOrInvalid), nameof(request.Email), request.Email);
                return methodResult;
            }

            _otpService.SetOtp(request.Email);
            var templateData = new Dictionary<string, string>
            {
                { EmailConstants.Keys.Email, request.Email },
                { EmailConstants.Keys.Otp, _otpService.GetOtp(request.Email) }
            };

            try
            {
                await _senderService.SendEmailAsync(
                    to: request.Email,
                    subject: EmailConstants.Subjects.ForgotPasswordOtp,
                    templateName: EnumSenderTemplate.SendOtpVerifyPassword.ToString(),
                    templateData: templateData
                );
            }
            catch (Exception)
            {
                methodResult.AddError(
                    StatusCodes.Status500InternalServerError,
                    nameof(EnumSystemErrorCode.ServerError),
                    nameof(request.Email),
                    "Failed to send OTP email."
                );
                return methodResult;
            }

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}