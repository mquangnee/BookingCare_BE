using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
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

    public class UpdateUserProfileCommandHandler(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor) : IRequestHandler<UpdateUserProfileCommand, MethodResult<bool>>
    {
        public async Task<MethodResult<bool>> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            MethodResult<bool> methodResult = new();

            var userIdString = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }

            var patient = await unitOfWork.Patients.QueryableAsync().FirstOrDefaultAsync(p => p.UserId == userId, cancellationToken);
            if (patient == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(patient));
                return methodResult;
            }

            var patientProfile = await unitOfWork.PatientProfiles.QueryableAsync()
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
                var existingCitizen = await unitOfWork.PatientProfiles.QueryableAsync()
                    .FirstOrDefaultAsync(p => p.CitizenId == request.CitizenId && p.Id != patientProfile.Id, cancellationToken);

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

            unitOfWork.PatientProfiles.Update(patientProfile);
            await unitOfWork.SaveChangesAsync();

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
