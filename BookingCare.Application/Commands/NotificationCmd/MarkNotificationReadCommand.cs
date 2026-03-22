using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookingCare.Application.Commands.NotificationCmd
{
    public class MarkNotificationReadCommand : MarkNotificationReadCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class MarkNotificationReadCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<MarkNotificationReadCommand, MethodResult<bool>>
    {
        public async Task<MethodResult<bool>> Handle(MarkNotificationReadCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            MethodResult<bool> methodResult = new();

            var notification = await unitOfWork.Notifications.GetByIdAsync(request.NotificationId);
            if (notification == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.NotificationId), request.NotificationId);
                return methodResult;
            }

            notification.IsRead = true;
            unitOfWork.Notifications.Update(notification);
            await unitOfWork.SaveChangesAsync();

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
