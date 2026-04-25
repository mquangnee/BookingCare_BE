using BookingCare.Application.Services;
using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using BookingCare.Shared.Setting;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BookingCare.Application.Admins.Command
{
    public class UpdateReceptionistProfileCommand : UpdateReceptionistProfileCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class UpdateReceptionistProfileCommandHandler : IRequestHandler<UpdateReceptionistProfileCommand, MethodResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly ICloudStorageService _cloudStorageService;
        private readonly CloudStorageSetting _cloudStorageSetting;

        public UpdateReceptionistProfileCommandHandler(
            IUnitOfWork unitOfWork, 
            UserManager<User> userManager,
            ICloudStorageService cloudStorageService,
            IOptions<CloudStorageSetting> options)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _cloudStorageService = cloudStorageService;
            _cloudStorageSetting = options.Value;
        }

        public async Task<MethodResult<bool>> Handle(UpdateReceptionistProfileCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            var receptionist = await _unitOfWork.Receptionists.GetByIdAsync(request.ReceptionistId);
            if (receptionist == null)
            {
                methodResult.AddError(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.ReceptionistId), request.ReceptionistId);
                return methodResult;
            }
            var user = await _userManager.FindByIdAsync(receptionist.UserId.ToString());
            if (user == null)
            {
                methodResult.AddError(nameof(EnumSystemErrorCode.DataNotExist), nameof(receptionist.UserId), receptionist.UserId);
                return methodResult;
            }

            if (request.Avatar != null)
            {
                receptionist.AvatarUrl = await _cloudStorageService.UploadFileAsync(request.Avatar, _cloudStorageSetting.ReceptionistFolder);
            }

            receptionist.FullName = request.FullName;
            receptionist.DateOfBirth = request.DateOfBirth;
            receptionist.Gender = request.Gender;

            _unitOfWork.Receptionists.Update(receptionist);

            user.PhoneNumber = request.PhoneNumber;
            user.UpdatedDate = DateTime.Now;
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            var res = await _userManager.UpdateAsync(user);
            if (res.Succeeded == false)
            {
                methodResult.AddError(nameof(EnumDashboardErrorCode.UpdateInfoFailed));
                return methodResult;
            }

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}