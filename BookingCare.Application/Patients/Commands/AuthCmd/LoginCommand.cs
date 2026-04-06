using BookingCare.Application.Services;
using BookingCare.Domain.Entities;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Enum.ErrorCode;
using BookingCare.Shared.Setting;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BookingCare.Application.Patients.Commands.AuthCmd
{
    public class LoginCommand : LoginCommandModel, IRequest<MethodResult<TokenModel>>
    {
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, MethodResult<TokenModel>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;
        private readonly JwtSetting _jwtSetting;

        public LoginCommandHandler(UserManager<User> userManager, IJwtService jwtService, IOptions<JwtSetting> jwtOptions)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _jwtSetting = jwtOptions.Value;
        }

        public async Task<MethodResult<TokenModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<TokenModel>();

            if (request.Email == null || request.Password == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.EmailAndPasswordNotEmpty), nameof(request.Email), request.Email);
                return methodResult;
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.EmailAndPasswordIncorrect), nameof(request.Email), request.Email);
                return methodResult;
            }
            if (user.LockoutEnd != null && user.LockoutEnd > DateTime.UtcNow)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.AccountLockedOut), nameof(request.Email), request.Email);
                return methodResult;
            }

            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAuthErrorCode.EmailAndPasswordIncorrect), nameof(request.Email), request.Email);
                return methodResult;
            }

            var token = await GenerateTokenAsync(user, _jwtService);
            user.RefreshToken = token.RefreshToken;
            user.TokenExpiry = DateTime.UtcNow.AddDays(_jwtSetting.RefreshTokenDays);
            await _userManager.UpdateAsync(user);

            methodResult.Result = token;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
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
