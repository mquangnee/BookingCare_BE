using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Queries.NotificationQuery
{
    public class GetNotificationsQuery : IRequest<MethodResult<List<NotificationModel>>>
    {
    }

    public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, MethodResult<List<NotificationModel>>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public GetNotificationsQueryHandler(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<List<NotificationModel>>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<NotificationModel>>();

            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }
            var notifications = await _unitOfWork.Notifications.QueryableAsync()
                .Where(n => n.ReceiverId == userId)
                .OrderByDescending(n => n.CreatedDate)
                .Select(n => new NotificationModel
                {
                    NotificationId = n.Id,
                    ReceiverId = n.ReceiverId,
                    SenderId = n.SenderId,
                    Message = n.Message,
                    Type = n.Type,
                    ObjectId = n.ObjectId,
                    IsRead = n.IsRead,
                    IsAccepted = n.IsAccepted,
                    IsActioned = n.IsActioned,
                    CreatedDate = n.CreatedDate
                })
                .ToListAsync(cancellationToken);

            methodResult.Result = notifications;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
