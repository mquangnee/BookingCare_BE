using BonBonCar.Application.Common;
using BookingCare.Sender.Domain.Models;
using BookingCare.Shared.Setting;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingCare.Sender.Application.Commands
{
    public class SendEmailCommand : SendEmailCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, MethodResult<bool>>
    {
        private readonly SmtpSetting _smtpSetting;

        public SendEmailCommandHandler(IOptions<SmtpSetting> smtpOptions)
        {
            _smtpSetting = smtpOptions.Value;
        }

        public async Task<MethodResult<bool>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();
            
            SendEmai
            if (string.IsNullOrWhiteSpace(request.To) || string.IsNullOrWhiteSpace(request.Subject) || string.IsNullOrWhiteSpace(request.Body))
            {
                methodResult.AddErrorBadRequest("To, Subject, and Body are required fields.");
                return methodResult;
            }
            // Call the sender service to send the email
            bool isSent = await _senderService.SendEmailAsync(request.To, request.Subject, request.Body);
            methodResult.Result = isSent;
            methodResult.StatusCode = isSent ? 200 : 500; // Assuming 200 for success and 500 for failure
            return methodResult;
        }
    }
}
