using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Receptionists.Query
{
    public class GetReceptionistProfileQuery : IRequest<MethodResult<ReceptionistModel>>
    {
    }

    public class GetReceptionistProfileQueryHandler : IRequestHandler<GetReceptionistProfileQuery, MethodResult<ReceptionistModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetReceptionistProfileQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MethodResult<ReceptionistModel>> Handle(GetReceptionistProfileQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<ReceptionistModel>();

            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }

            var receptionist = await _unitOfWork.Receptionists
                .QueryableAsync()
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.UserId == userId, cancellationToken);
            if (receptionist == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist));
                return methodResult;
            }
            var receptionistModel = new ReceptionistModel
            {
                Id = receptionist.Id,
                UserId = receptionist.UserId,
                ReceptionistCode = receptionist.ReceptionistCode,
                Email = receptionist.User!.Email,
                PhoneNumber = receptionist.User!.PhoneNumber,
                AvatarUrl = receptionist.AvatarUrl,
                FullName = receptionist.FullName,
                DateOfBirth = receptionist.DateOfBirth,
                Gender = receptionist.Gender
            };

            methodResult.Result = receptionistModel;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
