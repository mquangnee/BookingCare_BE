using BookingCare.Application.Services;
using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Enum.ErrorCode;
using BookingCare.Shared.Setting;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookingCare.Application.Admins.Command
{
    public class CreateReceptionistAccountCommand : CreateReceptionistAccountCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class CreateReceptionistAccountCommandHandler : IRequestHandler<CreateReceptionistAccountCommand, MethodResult<bool>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGeneratorCodeService _generatorCodeService;
        private readonly ICloudStorageService _cloudStorageService;
        private readonly ISenderService _senderService;
        private readonly CloudStorageSetting _cloudStorageSetting;

        public CreateReceptionistAccountCommandHandler(
            UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            IGeneratorCodeService generatorCodeService,
            ICloudStorageService cloudStorageService,
            ISenderService senderService,
            IOptions<CloudStorageSetting> options)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _generatorCodeService = generatorCodeService;
            _cloudStorageService = cloudStorageService;
            _senderService = senderService;
            _cloudStorageSetting = options.Value;
        }

        public async Task<MethodResult<bool>> Handle(CreateReceptionistAccountCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            var existingUserByEmail = await _userManager.FindByEmailAsync(request.Email!);
            if (existingUserByEmail != null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataAlreadyExist), nameof(request.Email), request.Email);
                return methodResult;
            }

            if (!string.IsNullOrEmpty(request.PhoneNumber))
            {
                var existingUserByPhone = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber, cancellationToken);
                if (existingUserByPhone != null)
                {
                    methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataAlreadyExist), nameof(request.PhoneNumber), request.PhoneNumber);
                    return methodResult;
                }
            }

            var isCitizenIdExists = await _unitOfWork.Receptionists.QueryableAsync()
                            .AnyAsync(r => r.CitizenId == request.CitizenId, cancellationToken) ||
                        await _unitOfWork.PatientProfiles.QueryableAsync()
                            .AnyAsync(p => p.CitizenId == request.CitizenId, cancellationToken) ||
                        await _unitOfWork.Doctors.QueryableAsync()
                            .AnyAsync(d => d.CitizenId == request.CitizenId, cancellationToken);

            if (isCitizenIdExists)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataAlreadyExist), nameof(request.CitizenId), request.CitizenId);
                return methodResult;
            }

            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                EmailConfirmed = true
            };

            var createResult = await _userManager.CreateAsync(user, request.Password!);
            if (!createResult.Succeeded)
            {
                foreach (var error in createResult.Errors)
                {
                    methodResult.AddErrorBadRequest(error.Code, error.Description);
                }
                return methodResult;
            }

            await _userManager.AddToRoleAsync(user, RoleConstants.Receptionist);

            string? avatarUrl = null;
            if (request.Avatar != null)
            {
                avatarUrl = await _cloudStorageService.UploadFileAsync(request.Avatar, _cloudStorageSetting.ReceptionistFolder);
            }

            var receptionistCode = await _generatorCodeService.GenerateReceptionistCodeAsync();
            var receptionist = new Receptionist
            {
                UserId = user.Id,
                ReceptionistCode = receptionistCode,
                AvatarUrl = avatarUrl,
                FullName = request.FullName,
                CitizenId = request.CitizenId,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender
            };
            await _unitOfWork.Receptionists.AddAsync(receptionist);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var templateData = new Dictionary<string, string>
            {
                { EmailConstants.Keys.FullName, request.FullName! },
                { EmailConstants.Keys.Email, request.Email! },
                { EmailConstants.Keys.Password, request.Password! }
            };

            await _senderService.SendEmailAsync(
                to: request.Email!,
                subject: EmailConstants.Subjects.CreateReceptionistAccount,
                templateName: EnumSenderTemplate.CreateReceptionistAccount.ToString(),
                templateData: templateData
            );

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}