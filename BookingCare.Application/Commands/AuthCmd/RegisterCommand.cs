using BookingCare.Application.Services;
using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Infrastructure.Enums.ErrorCode;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Setting;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookingCare.Application.Commands.AuthCmd
{
    public class RegisterCommand : RegisterCommandModel, IRequest<MethodResult<TokenModel>> 
    {
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, MethodResult<TokenModel>>
    {
        private const string PATIENT_ROLE = "Patient";

        private readonly UserManager<User> _userManager;
        private readonly IOtpService _otpService;
        private readonly IJwtService _jwtService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtSetting _jwtSetting;
        private readonly IGeneratorCodeService _generatorCodeService;

        public RegisterCommandHandler(
            UserManager<User> userManager, 
            IOtpService otpService, 
            IJwtService jwtService, 
            IUnitOfWork unitOfWork, 
            IOptions<JwtSetting> jwtOptions,
            IGeneratorCodeService generatorCodeService)
        {
            _userManager = userManager;
            _otpService = otpService;
            _jwtService = jwtService;
            _unitOfWork = unitOfWork;
            _jwtSetting = jwtOptions.Value;
            _generatorCodeService = generatorCodeService;
        }

        public async Task<MethodResult<TokenModel>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<TokenModel>();

            if (HasMissingRequiredFields(request))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Required), nameof(request.Email), request.Email);
                return methodResult;
            }
            if (request.Password != request.ConfirmPassword)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.ConfirmPasswordNotMatch), nameof(request.Password), request.Password);
                return methodResult;
            }

            var cachedOtp = _otpService.GetOtp(request.Email!);
            if (request.Otp != cachedOtp)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.OtpInvalid), nameof(request.Otp), request.Otp);
                return methodResult;
            }

            var existingUser = await _userManager.FindByEmailAsync(request.Email!);
            if (existingUser != null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataAlreadyExist), nameof(request.Email), request.Email);
                return methodResult;
            }

            var existingCitizenId = await _unitOfWork.PatientProfiles.QueryableAsync()
                .FirstOrDefaultAsync(p => p.CitizenId == request.CitizenId && p.PatientId != null, cancellationToken);
            if (existingCitizenId != null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataAlreadyExist), nameof(request.CitizenId), request.CitizenId);
                return methodResult;
            }

            var newUser = new User
            {
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            var createResult = await _userManager.CreateAsync(newUser, request.Password!);
            if (!createResult.Succeeded)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.RegisterFailed), nameof(request.Email), request.Email);
                return methodResult;
            }
            await _userManager.AddToRoleAsync(newUser, PATIENT_ROLE);

            var newPatient = new Patient
            {
                UserId = newUser.Id,
                PatientCode = await _generatorCodeService.GeneratePatientCodeAsync()
            };
            await _unitOfWork.Patients.AddAsync(newPatient);

            var existingProfile = await _unitOfWork.PatientProfiles.QueryableAsync()
                .FirstOrDefaultAsync(p => p.CitizenId == request.CitizenId && p.PatientId == null, cancellationToken);
            if (existingProfile != null)
            {
                existingProfile.PatientId = newPatient.Id;
                _unitOfWork.PatientProfiles.Update(existingProfile);
            }
            else
            {
                var newPatientProfile = new PatientProfile
                {
                    PatientId = newPatient.Id,
                    FullName = request.FullName,
                    DateOfBirth = request.DateOfBirth,
                    Gender = request.Gender,
                    CitizenId = request.CitizenId,
                    PhoneNumber = request.PhoneNumber
                };
                await _unitOfWork.PatientProfiles.AddAsync(newPatientProfile);
            }
            await _unitOfWork.SaveChangesAsync();

            var token = await GenerateTokenAsync(newUser, _jwtService);
            newUser.RefreshToken = token.RefreshToken;
            newUser.TokenExpiry = DateTime.UtcNow.AddDays(_jwtSetting.RefreshTokenDays);
            await _userManager.UpdateAsync(newUser);
            _otpService.RemoveOtp(request.Email!);

            methodResult.Result = token;
            methodResult.StatusCode = StatusCodes.Status201Created;
            return methodResult;
        }

        private static bool HasMissingRequiredFields(RegisterCommand request)
        {
            return request.Email == null 
                || request.Password == null 
                || request.ConfirmPassword == null 
                || request.Otp == null 
                || request.FullName == null 
                || request.PhoneNumber == null 
                || request.CitizenId == null;
        }

        private static async Task<TokenModel> GenerateTokenAsync(User user, IJwtService jwtService)
        {
            var accessToken = await jwtService.GenerateAccessToken(user);
            var refreshToken = jwtService.GenerateRefreshToken();
            return new TokenModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
