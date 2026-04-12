using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Receptionists.Query
{
    public class GetAppointmentsByWorkSessionIdQuery : IRequest<MethodResult<List<AppointmentModel>>>
    {
        public Guid WorkSessionId { get; set; }
    }

    public class GetAppointmentsQueryHandler : IRequestHandler<GetAppointmentsByWorkSessionIdQuery, MethodResult<List<AppointmentModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAppointmentsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<List<AppointmentModel>>> Handle(GetAppointmentsByWorkSessionIdQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<AppointmentModel>>();

            var today = DateTime.Now;
            var appointments = await _unitOfWork.Appointments
                .QueryableAsync()
                .Include(a => a.PatientProfile)
                .Where(a => a.WorkSessionId == request.WorkSessionId && a.Status != EnumAppointmentStatus.Cancelled)
                .Select(a => new AppointmentModel
                {
                    Id = a.Id,
                    AppointmentCode = a.AppointmentCode,
                    BookerId = a.BookerId,
                    WorkSessionId = a.WorkSessionId,
                    PatientProfileId = a.PatientProfileId,
                    PatientName = a.PatientProfile!.FullName,
                    Age = today.Year - a.PatientProfile.DateOfBirth.Year,
                    Gender = a.PatientProfile.Gender,
                    Type = a.Type,
                    Status = a.Status,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime,
                    CheckInDate = a.CheckInDate
                })
                .ToListAsync(cancellationToken);

            methodResult.Result = appointments;
            return methodResult;
        }
    }
}
