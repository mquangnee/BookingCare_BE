using BookingCare.Application.Services;
using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Patients.Commands.AppointmentCmd
{
    public class CreateAppointmentCommand : CreateAppointmentCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, MethodResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGeneratorCodeService _generatorCodeService;

        public CreateAppointmentCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IGeneratorCodeService generatorCodeService)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _generatorCodeService = generatorCodeService;
        }

        public async Task<MethodResult<bool>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid bookerId))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }
            if (!request.DoctorId.HasValue)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Required), nameof(request.DoctorId), request.DoctorId);
                return methodResult;
            }
            var workSession = await _unitOfWork.WorkSessions.QueryableAsync()
                .FirstOrDefaultAsync(ws => ws.DoctorId == request.DoctorId
                                        && ws.Date == request.Date.Date
                                        && ws.StartTime <= request.StartTime
                                        && ws.EndTime >= request.EndTime, cancellationToken);
            if (workSession == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(workSession));
                return methodResult;
            }
            bool isSlotTaken = await _unitOfWork.Appointments.QueryableAsync()
                .AnyAsync(a => a.WorkSessionId == workSession.Id
                            && a.Status != EnumAppointmentStatus.Cancelled
                            && a.StartTime == request.StartTime, cancellationToken);
            if (isSlotTaken)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAppointmentErrorCode.SlotIsTaken));
                return methodResult;
            }
            bool isPatientBusy = await _unitOfWork.Appointments.QueryableAsync()
                .AnyAsync(a => a.PatientProfileId == request.PatientProfileId
                            && a.Date.Date == request.Date.Date
                            && a.Status != EnumAppointmentStatus.Cancelled
                            && a.StartTime < request.EndTime
                            && a.EndTime > request.StartTime, cancellationToken);
            if (isPatientBusy)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAppointmentErrorCode.PatientHasOverlappingAppointment));
                return methodResult;
            }
            Service? targetService = null;
            if (request.ServiceId.HasValue)
            {
                targetService = await _unitOfWork.Services.QueryableAsync().FirstOrDefaultAsync(s => s.Id == request.ServiceId, cancellationToken);
            }
            else
            {
                var doctor = await _unitOfWork.Doctors.QueryableAsync().FirstOrDefaultAsync(d => d.Id == request.DoctorId, cancellationToken);
                if (doctor != null)
                {
                    targetService = await _unitOfWork.Services.QueryableAsync().FirstOrDefaultAsync(s => s.Position == doctor.Position && s.SpecialtyId == doctor.SpecialtyId, cancellationToken);
                }
            }
            if (targetService == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(targetService));
                return methodResult;
            }
            string appointmentCode = await _generatorCodeService.GenerateAppointmentCodeAsync();

            var newAppointment = new Appointment
            {
                Id = Guid.NewGuid(),
                AppointmentCode = appointmentCode,
                BookerId = bookerId,
                Status = EnumAppointmentStatus.Pending,
                Date = request.Date,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                CreatedDate = DateTime.Now,
                WorkSessionId = workSession.Id,
                PatientProfileId = request.PatientProfileId,
                ServiceId = targetService.Id,
                ServicePrice = targetService.Price,
                Type = request.Type
            };

            await _unitOfWork.Appointments.AddAsync(newAppointment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status201Created;
            return methodResult;
        }
    }
}
