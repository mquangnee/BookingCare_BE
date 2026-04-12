using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Doctors.Query
{
    public class GetDoctorProfileQuery : IRequest<MethodResult<DoctorModel>>
    {
    }

    public class GetDoctorProfileQueryHandler : IRequestHandler<GetDoctorProfileQuery, MethodResult<DoctorModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetDoctorProfileQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MethodResult<DoctorModel>> Handle(GetDoctorProfileQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<DoctorModel>();

            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }
            var doctor = await _unitOfWork.Doctors
                .QueryableAsync()
                .Include(d => d.Specialty)
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.UserId == userId, cancellationToken);
            if (doctor == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist));
                return methodResult;
            }
            var doctorModel = new DoctorModel
            {
                Id = doctor.Id,
                UserId = doctor.UserId,
                SpecialtyId = doctor.SpecialtyId,
                SpecialtyName = doctor.Specialty?.Name,
                DoctorCode = doctor.DoctorCode,
                Email = doctor.User!.Email,
                PhoneNumber = doctor.User!.PhoneNumber,
                AvatarUrl = doctor.AvatarUrl,
                FullName = doctor.FullName,
                DateOfBirth = doctor.DateOfBirth,
                Gender = doctor.Gender,
                CitizenId = doctor.CitizenId,
                ExperienceYears = doctor.ExperienceYears,
                Position = doctor.Position,
                WorkingHistory = doctor.WorkingHistory,
                Description = doctor.Description
            };
            
            methodResult.Result = doctorModel;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
