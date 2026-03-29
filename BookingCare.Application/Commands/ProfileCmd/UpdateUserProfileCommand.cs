using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Commands.ProfileCmd
{
    public class UpdateUserProfileCommand : UpdateUserProfileCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, MethodResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateUserProfileCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MethodResult<bool>> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }
            var patient = await _unitOfWork.Patients.QueryableAsync().FirstOrDefaultAsync(p => p.UserId == userId, cancellationToken);
            if (patient == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(patient));
                return methodResult;
            }
            var patientProfile = await _unitOfWork.PatientProfiles.QueryableAsync()
                .FirstOrDefaultAsync(p => p.PatientId == patient.Id && p.ProfileCode == request.ProfileCode, cancellationToken);
            if (patientProfile == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(patientProfile));
                return methodResult;
            }

            if (!string.IsNullOrEmpty(request.FullName))
                patientProfile.FullName = request.FullName;
            if (request.DateOfBirth.HasValue)
                patientProfile.DateOfBirth = request.DateOfBirth.Value;
            if (request.Gender.HasValue)
                patientProfile.Gender = request.Gender.Value;
            if (!string.IsNullOrEmpty(request.CitizenId))
            {
                var existingCitizen = await _unitOfWork.PatientProfiles.QueryableAsync().FirstOrDefaultAsync(p => p.CitizenId == request.CitizenId && p.Id != patientProfile.Id, cancellationToken);
                if (existingCitizen != null)
                {
                     methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataAlreadyExist), nameof(request.CitizenId), request.CitizenId);
                     return methodResult;
                }
                patientProfile.CitizenId = request.CitizenId;
            }
            if (!string.IsNullOrEmpty(request.PhoneNumber))
                patientProfile.PhoneNumber = request.PhoneNumber;
            if (request.Relationship.HasValue)
                patientProfile.Relationship = request.Relationship.Value;
            if (request.BloodType.HasValue)
                patientProfile.BloodType = request.BloodType.Value;
            if (request.MedicalHistory != null)
                patientProfile.MedicalHistory = request.MedicalHistory;
            patientProfile.UpdatedDate = DateTime.Now;
            _unitOfWork.PatientProfiles.Update(patientProfile);
            await _unitOfWork.SaveChangesAsync();

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
