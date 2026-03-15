using BookingCare.Application.Services;
using BookingCare.Domain.Entities;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Setting;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BookingCare.Identity.Application.Commands.AuthCmd
{
    public class SendRegisterOtpCommand : SendRegisterOtpCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class SendRegisterOtpCommandHandler : IRequestHandler<SendRegisterOtpCommand, MethodResult<bool>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IOtpService _otpService;
        private readonly ISenderService _senderService;

        public SendRegisterOtpCommandHandler(UserManager<User> userManager, IOtpService otpService, ISenderService senderService)
        {
            _userManager = userManager;
            _otpService = otpService;
            _senderService = senderService;
        }

        public async Task<MethodResult<bool>> Handle(SendRegisterOtpCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Required), nameof(request.Email), request.Email);
                return methodResult;
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataAlreadyExist), nameof(request.Email), request.Email);
                return methodResult;
            }

            _otpService.SetOtp(request.Email);
            var templateData = new Dictionary<string, string>
            {
                { EmailConstants.Keys.FullName, request.FullName! },
                { EmailConstants.Keys.Otp, _otpService.GetOtp(request.Email) }
            };

            await _senderService.SendEmailAsync(
                to: request.Email,
                subject: EmailConstants.Subjects.RegisterOtp,
                templateName: EnumSenderTemplate.SendOtpRegister.ToString(),
                templateData: templateData
            );

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
