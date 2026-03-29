using BookingCare.Application.Services;
using BookingCare.Domain.IRepository;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Commands.ProfileCmd
{
    public class CancelShareProfileCommand : IRequest<MethodResult<bool>>
    {
        public Guid ProfileShareId { get; set; }
    }

    public class CancelShareProfileCommandHandler : IRequestHandler<CancelShareProfileCommand, MethodResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;

        public CancelShareProfileCommandHandler(IUnitOfWork unitOfWork, INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
        }

        public async Task<MethodResult<bool>> Handle(CancelShareProfileCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            var profileShare = await _unitOfWork.ProfileShares.GetByIdAsync(request.ProfileShareId);
            if (profileShare == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.ProfileShareId), request.ProfileShareId);
                return methodResult;
            }
            profileShare.ShareStatus = EnumShareStatus.Rejected;
            _unitOfWork.ProfileShares.Update(profileShare);
            await _unitOfWork.SaveChangesAsync();

            var profile = await _unitOfWork.PatientProfiles.GetByIdAsync(profileShare.ProfileId);
            if (profile == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(profileShare.ProfileId), profileShare.ProfileId);
                return methodResult;
            }
            var fullName = await GetInfor(_unitOfWork, profileShare.SharedByUserId);
            var userName = await GetInfor(_unitOfWork, profileShare.SharedToUserId);
            var messageParams = new List<object> { fullName ?? string.Empty, userName ?? string.Empty };
            await SendNotification(_notificationService, null, profileShare.SharedByUserId, profileShare.SharedToUserId, messageParams);

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }

        private static async Task<string?> GetInfor(IUnitOfWork unitOfWork, Guid userId)
        {
            var patient = await unitOfWork.Patients.QueryableAsync()
                .FirstOrDefaultAsync(p => p.UserId == userId);
            if (patient == null)
            {
                return null;
            }
            var profile = await unitOfWork.PatientProfiles.QueryableAsync().FirstOrDefaultAsync(p => p.PatientId == patient.Id && p.Relationship == EnumRelationship.MySelf);
            if (profile == null)
            {
                return null;
            }
            return profile.FullName;
        }

        private static async Task SendNotification(INotificationService notificationService, Guid? shareProfileId, Guid senderId, Guid receiverId, List<object> messageParams)
        {
            await notificationService.SendNotificationAsync(
                receiverId: receiverId,
                senderId: senderId,
                shareProfileId: shareProfileId,
                content: EnumNotificationContent.ShareProfileRevoked,
                type: EnumNotificationType.ShareProfileRevoked,
                objectId: null,
                messageParams: messageParams
            );
        }
    }
}
