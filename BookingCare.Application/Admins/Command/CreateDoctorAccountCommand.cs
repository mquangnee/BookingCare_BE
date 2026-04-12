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
    public class CreateDoctorAccountCommand : CreateDoctorAccountCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class CreateDoctorAccountCommandHandler : IRequestHandler<CreateDoctorAccountCommand, MethodResult<bool>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGeneratorCodeService _generatorCodeService;
        private readonly ICloudStorageService _cloudStorageService;
        private readonly ISenderService _senderService;
        private readonly CloudStorageSetting _cloudStorageSetting;

        public CreateDoctorAccountCommandHandler(
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

        public async Task<MethodResult<bool>> Handle(CreateDoctorAccountCommand request, CancellationToken cancellationToken)
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

            var isCitizenIdExists = await _unitOfWork.Doctors.QueryableAsync()
                            .AnyAsync(d => d.CitizenId == request.CitizenId, cancellationToken) ||
                        await _unitOfWork.PatientProfiles.QueryableAsync()
                            .AnyAsync(p => p.CitizenId == request.CitizenId, cancellationToken);

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

            var createResult = await _userManager.CreateAsync(user, request.Password);
            if (!createResult.Succeeded)
            {
                foreach (var error in createResult.Errors)
                {
                    methodResult.AddErrorBadRequest(error.Code, error.Description);
                }
                return methodResult;
            }

            await _userManager.AddToRoleAsync(user, RoleConstants.Doctor);

            string? avatarUrl = null;
            if (request.Avatar != null)
            {
                avatarUrl = await _cloudStorageService.UploadFileAsync(request.Avatar, _cloudStorageSetting.DoctorFolder);
            }

            var doctorCode = await _generatorCodeService.GenerateDoctorCodeAsync();
            var doctor = new Doctor
            {
                UserId = user.Id,
                DoctorCode = doctorCode,
                SpecialtyId = request.SpecialtyId,
                AvatarUrl = avatarUrl,
                FullName = request.FullName,
                CitizenId = request.CitizenId,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                ExperienceYears = request.ExperienceYears,
                Position = request.Position,
                WorkingHistory = request.WorkingHistory,
                Description = request.Description
            };
            await _unitOfWork.Doctors.AddAsync(doctor);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var templateData = new Dictionary<string, string>
            {
                { EmailConstants.Keys.FullName, request.FullName! },
                { EmailConstants.Keys.Email, request.Email! },
                { EmailConstants.Keys.Password, request.Password }
            };

            await _senderService.SendEmailAsync(
                to: request.Email!,
                subject: EmailConstants.Subjects.CreateDoctorAccount,
                templateName: EnumSenderTemplate.CreateDoctorAccount.ToString(),
                templateData: templateData
            );

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
