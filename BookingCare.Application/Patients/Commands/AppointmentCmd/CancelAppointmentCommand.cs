using BookingCare.Domain.IRepository;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Patients.Commands.AppointmentCmd
{
    public class CancelAppointmentCommand : IRequest<MethodResult<bool>>
    {
        public Guid AppointmentId { get; set; }
    }

    public class CancelAppointmentCommandHandler : IRequestHandler<CancelAppointmentCommand, MethodResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private const int MinutesBeforeAllowedToCancel = 30;

        public CancelAppointmentCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MethodResult<bool>> Handle(CancelAppointmentCommand request, CancellationToken cancellationToken)
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
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(request.AppointmentId);
            if (appointment == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.AppointmentId), request.AppointmentId);
                return methodResult;
            }
            if (appointment.BookerId != userId)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }
            if (appointment.Status != EnumAppointmentStatus.Pending && appointment.Status != EnumAppointmentStatus.Approved)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAppointmentErrorCode.StatusNotValidForCancellation));
                return methodResult;
            }

            var appointmentDateTime = appointment.Date.Date + appointment.StartTime;
            var minutesUntilAppointment = (appointmentDateTime - DateTime.Now).Value.TotalMilliseconds;

            if (minutesUntilAppointment < MinutesBeforeAllowedToCancel)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAppointmentErrorCode.TimeNotValidForCancellation));
                return methodResult;
            }
            appointment.Status = EnumAppointmentStatus.Cancelled;
            _unitOfWork.Appointments.Update(appointment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}