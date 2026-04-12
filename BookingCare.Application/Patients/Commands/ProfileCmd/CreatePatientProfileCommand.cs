using BookingCare.Application.Services;
using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Patients.Commands.ProfileCmd
{
    public class CreatePatientProfileCommand : CreatePatientProfileCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class CreatePatientProfileCommandHandler : IRequestHandler<CreatePatientProfileCommand, MethodResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGeneratorCodeService _generatorCodeService;

        public CreatePatientProfileCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IGeneratorCodeService generatorCodeService)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _generatorCodeService = generatorCodeService;
        }

        public async Task<MethodResult<bool>> Handle(CreatePatientProfileCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            if (HasMissingRequiredFields(request))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Required));
                return methodResult;
            }

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

            var isCitizenExist = await _unitOfWork.PatientProfiles.QueryableAsync().AnyAsync(p => p.CitizenId == request.CitizenId, cancellationToken);
            if (isCitizenExist)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataAlreadyExist), nameof(request.CitizenId), request.CitizenId);
                return methodResult;
            }

            var patientProfile = new PatientProfile
            {
                ProfileCode = await _generatorCodeService.GeneratePatientProfileCodeAsync(),
                PatientId = patient.Id,
                FullName = request.FullName,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                CitizenId = request.CitizenId,
                PhoneNumber = request.PhoneNumber,
                Relationship = request.Relationship,
                BloodType = request.BloodType,
                MedicalHistory = request.MedicalHistory
            };
            await _unitOfWork.PatientProfiles.AddAsync(patientProfile);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status201Created;
            return methodResult;
        }
        private static bool HasMissingRequiredFields(CreatePatientProfileCommand request)
        {
            return request.FullName == null
            || request.DateOfBirth == null
            || request.Gender == null
            || request.CitizenId == null
            || request.PhoneNumber == null
            || request.Relationship == null
            || request.BloodType == null;
        }
    }
}
