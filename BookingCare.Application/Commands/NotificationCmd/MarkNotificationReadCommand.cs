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

    public class MarkNotificationReadCommandHandler : IRequestHandler<MarkNotificationReadCommand, MethodResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public MarkNotificationReadCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<bool>> Handle(MarkNotificationReadCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();
            var notification = await _unitOfWork.Notifications.GetByIdAsync(request.NotificationId);
            if (notification == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.NotificationId), request.NotificationId);
                return methodResult;
            }
            notification.IsRead = true;
            _unitOfWork.Notifications.Update(notification);
            await _unitOfWork.SaveChangesAsync();
            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
