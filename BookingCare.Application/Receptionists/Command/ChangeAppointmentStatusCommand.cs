using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Enum.ErrorCode;
using BookingCare.Shared.Setting;
using BookingCare.Shared.SignalR;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Receptionists.Command
{
    public class ChangeAppointmentStatusCommand : IRequest<MethodResult<bool>>
    {
        public Guid AppointmentId { get; set; }
        public EnumAppointmentStatus Status { get; set; }
        public EnumAppointmentPriority Priority { get; set; }
    }

    public class ChangeAppointmentStatusCommandHandler : IRequestHandler<ChangeAppointmentStatusCommand, MethodResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<AppointmentHub> _hubContext;

        public ChangeAppointmentStatusCommandHandler(IUnitOfWork unitOfWork, IHubContext<AppointmentHub> hubContext)
        {
            _unitOfWork = unitOfWork;
            _hubContext = hubContext;
        }

        public async Task<MethodResult<bool>> Handle(ChangeAppointmentStatusCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            var query = _unitOfWork.Appointments.QueryableAsync();

            if (request.Status == EnumAppointmentStatus.Waiting)
            {
                query = query
                    .Include(a => a.WorkSession!)
                        .ThenInclude(ws => ws.Doctor)
                    .Include(a => a.PatientProfile);
            }

            var appointment = await query.FirstOrDefaultAsync(a => a.Id == request.AppointmentId, cancellationToken);
            if (appointment == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.AppointmentId), request.AppointmentId);
                return methodResult;
            }

            appointment.Status = request.Status;
            appointment.Priority = request.Priority;
            appointment.CheckInDate = DateTime.Now;
            appointment.UpdatedDate = DateTime.Now;

            _unitOfWork.Appointments.Update(appointment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (request.Status == EnumAppointmentStatus.Waiting)
            {
                var appointmentModel = new AppointmentModel
                {
                    Id = appointment.Id,
                    AppointmentCode = appointment.AppointmentCode,
                    BookerId = appointment.BookerId,
                    WorkSessionId = appointment.WorkSessionId,
                    DoctorName = appointment.WorkSession!.Doctor!.FullName,
                    PatientProfileId = appointment.PatientProfileId,
                    PatientName = appointment.PatientProfile!.FullName,
                    Age = DateTime.Now.Year - appointment.PatientProfile.DateOfBirth.Year,
                    Gender = appointment.PatientProfile.Gender,
                    Date = appointment.Date,
                    StartTime = appointment.StartTime,
                    EndTime = appointment.EndTime,
                    Status = appointment.Status
                };
                var userId = appointment.WorkSession!.Doctor!.UserId;
                await _hubContext.Clients.Group($"doctor_{userId}").SendAsync(HubSetting.Method.AppointmentStatusChanged, appointmentModel, cancellationToken);
            }

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
