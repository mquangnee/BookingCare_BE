using BookingCare.Domain.IRepository;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BookingCare.Domain.Models.EntityModels;

namespace BookingCare.Application.Doctors.Query
{
    public class GetPrescriptionPdfQuery : IRequest<MethodResult<byte[]>>
    {
        public Guid AppointmentId { get; set; }
    }

    public class GetPrescriptionPdfQueryHandler : IRequestHandler<GetPrescriptionPdfQuery, MethodResult<byte[]>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPdfService _pdfService;

        public GetPrescriptionPdfQueryHandler(IUnitOfWork unitOfWork, IPdfService pdfService)
        {
            _unitOfWork = unitOfWork;
            _pdfService = pdfService;
        }

        public async Task<MethodResult<byte[]>> Handle(GetPrescriptionPdfQuery request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<byte[]>();

            var appointment = await _unitOfWork.Appointments.QueryableAsync()
                .Include(a => a.PatientProfile)
                .Include(a => a.WorkSession)
                .FirstOrDefaultAsync(a => a.Id == request.AppointmentId, cancellationToken);

            if (appointment == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(appointment));
                return methodResult;
            }

            var doctor = await _unitOfWork.Doctors.QueryableAsync()
                .FirstOrDefaultAsync(d => d.Id == appointment.WorkSession!.DoctorId, cancellationToken);

            var prescription = await _unitOfWork.Prescriptions.QueryableAsync()
                .Include(p => p.PrescriptionDetails)!
                .ThenInclude(pd => pd.Medicine)
                .FirstOrDefaultAsync(p => p.AppointmentId == request.AppointmentId, cancellationToken);

            var model = new MedicalHistoryModel
            {
                AppointmentCode = appointment.AppointmentCode,
                ProfileCode = appointment.PatientProfile?.ProfileCode,
                PatientName = appointment.PatientProfile?.FullName,
                DoctorName = $"{doctor?.FullName} - {doctor?.DoctorCode}",
                Date = appointment.WorkSession!.Date,
                Age = appointment.PatientProfile != null ? DateTime.Now.Year - appointment.PatientProfile.DateOfBirth.Year : null,
                Gender = appointment.PatientProfile?.Gender,
                StartTime = appointment.StartTime,
                EndTime = appointment.EndTime,
                Diagnosis = prescription?.Diagnosis ?? "Không có chẩn đoán",
                Medicines = prescription?.PrescriptionDetails?.Select(pd => new PrescriptionMedicineModel
                {
                    MedicineId = pd.MedicineId,
                    MedicineName = pd.Medicine?.Name,
                    Unit = pd.Medicine?.Unit,
                    UsageInstruction = pd.Usage,
                    Dosage = pd.Dosage
                }).ToList() ?? new List<PrescriptionMedicineModel>()
            };

            methodResult.Result = _pdfService.GeneratePrescriptionPdf(model);
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}