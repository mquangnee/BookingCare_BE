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

        public RegisterCommandHandler(UserManager<User> userManager, IOtpService otpService, IJwtService jwtService, IUnitOfWork unitOfWork, IOptions<JwtSetting> jwtOptions)
        {
            _userManager = userManager;
            _otpService = otpService;
            _jwtService = jwtService;
            _unitOfWork = unitOfWork;
            _jwtSetting = jwtOptions.Value;
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
            var existingCitizen = await _userManager.Users.FirstOrDefaultAsync(u => u.CitizenId == request.Citizend, cancellationToken);
            if (existingCitizen != null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataAlreadyExist), nameof(request.Citizend), request.Citizend);
                return methodResult;
            }

            var newUser = new User
            {
                UserName = request.Email,
                Email = request.Email,
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                CitizenId = request.Citizend
            };
            var result = await _userManager.CreateAsync(newUser, request.Password!);
            if (!result.Succeeded)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.RegisterFailed), nameof(request.Email), request.Email);
                return methodResult;
            }
            await _userManager.AddToRoleAsync(newUser, PATIENT_ROLE);

            var newPatient = new Patient
            {
                UserId = newUser.Id,
                FullName = newUser.FullName,
                DateOfBirth = newUser.DateOfBirth,
                Gender = newUser.Gender,
                CitizenId = newUser.CitizenId,
                PhoneNumber = newUser.PhoneNumber
            };
            await _unitOfWork.Patients.AddAsync(newPatient);
            await _unitOfWork.SaveChangesAsync();

            var token = await GenerateTokenAsync(newUser, _jwtService);
            newUser.RefreshToken = token.RefreshToken;
            newUser.TokenExpiry = DateTime.UtcNow.AddDays(_jwtSetting.RefreshTokenDays);
            await _userManager.UpdateAsync(newUser);

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
                || request.Citizend == null;
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
