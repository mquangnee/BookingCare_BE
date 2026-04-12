using BookingCare.Application.Services;
using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Receptionists.Command
{
    public class CreatePatientProfileCommand : CreatePatientProfileCommandModel, IRequest<MethodResult<PatientProfile>>
    {
    }

    public class CreatePatientProfileCommandHandler : IRequestHandler<CreatePatientProfileCommand, MethodResult<PatientProfile>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGeneratorCodeService _generatorCodeService;

        public CreatePatientProfileCommandHandler(IUnitOfWork unitOfWork, IGeneratorCodeService generatorCodeService)
        {
            _unitOfWork = unitOfWork;
            _generatorCodeService = generatorCodeService;
        }

        public async Task<MethodResult<PatientProfile>> Handle(CreatePatientProfileCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<PatientProfile>();

            var existingPhoneNumber = await _unitOfWork.PatientProfiles.QueryableAsync().FirstOrDefaultAsync(pp => pp.PhoneNumber == request.PhoneNumber);
            if (existingPhoneNumber != null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumPatientProfileErrorCode.PhoneNumberAlreadyExists), nameof(request.PhoneNumber), request.PhoneNumber);
                return methodResult;
            }
            var existingCitizenId = await _unitOfWork.PatientProfiles.QueryableAsync().FirstOrDefaultAsync(pp => pp.CitizenId == request.CitizenId);
            if (existingCitizenId != null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumPatientProfileErrorCode.CitizenIdAlreadyExists), nameof(request.CitizenId), request.CitizenId);
                return methodResult;
            }
            var patientProfile = new PatientProfile
            {
                Id = Guid.NewGuid(),
                ProfileCode = await _generatorCodeService.GeneratePatientProfileCodeAsync(),
                FullName = request.FullName,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                CitizenId = request.CitizenId
            };
            await _unitOfWork.PatientProfiles.AddAsync(patientProfile);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            methodResult.Result = patientProfile;
            methodResult.StatusCode = StatusCodes.Status201Created;
            return methodResult;
        }
    }
}
