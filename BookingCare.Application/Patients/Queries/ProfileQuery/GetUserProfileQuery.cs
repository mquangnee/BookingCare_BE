using AutoMapper;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Patients.Queries.ProfileQuery
{
    public class GetUserProfileQuery : IRequest<MethodResult<UserProfileModel>>
    {
        public Guid? ProfileId { get; set; }
    }

    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, MethodResult<UserProfileModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetUserProfileQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MethodResult<UserProfileModel>> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<UserProfileModel>();

            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }
            var patient = await _unitOfWork.Patients.QueryableAsync()
                .FirstOrDefaultAsync(p => p.UserId == userId, cancellationToken);
            if (patient == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(patient));
                return methodResult;
            }
            var patientProfile = request.ProfileId == null ?
                await _unitOfWork.PatientProfiles.QueryableAsync().FirstOrDefaultAsync(p => p.PatientId == patient.Id && p.Relationship == EnumRelationship.MySelf, cancellationToken) :
                await _unitOfWork.PatientProfiles.QueryableAsync().FirstOrDefaultAsync(p => p.Id == request.ProfileId, cancellationToken);
            if (patientProfile == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(patientProfile));
                return methodResult;
            }
            
            methodResult.Result = new UserProfileModel
            {
                Id = patientProfile.Id,
                PatientCode = patient.PatientCode,
                ProfileCode = patientProfile.ProfileCode,
                FullName = patientProfile.FullName,
                DateOfBirth = patientProfile.DateOfBirth,
                Gender = patientProfile.Gender,
                CitizenId = patientProfile.CitizenId,
                PhoneNumber = patientProfile.PhoneNumber,
                Relationship = patientProfile.Relationship,
                BloodType = patientProfile.BloodType,
                MedicalHistory = patientProfile.MedicalHistory
            };
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
