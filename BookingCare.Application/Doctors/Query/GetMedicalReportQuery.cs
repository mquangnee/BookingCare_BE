using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Doctors.Query
{
    public class GetMedicalReportQuery : IRequest<MethodResult<PrescriptionModel>>
    {
        public Guid AppointmentId { get; set; }
    }

    public class GetMedicalReportQueryHandler : IRequestHandler<GetMedicalReportQuery, MethodResult<PrescriptionModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMedicalReportQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<PrescriptionModel>> Handle(GetMedicalReportQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<PrescriptionModel>();

            var prescription = await _unitOfWork.Prescriptions.QueryableAsync().FirstOrDefaultAsync(p => p.AppointmentId == request.AppointmentId);
            if (prescription == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumAppointmentErrorCode.PrescriptionNotFound));
                return methodResult;
            }

            var prescriptionDetails = await _unitOfWork.PrescriptionDetails.QueryableAsync().Where(pd => pd.PrescriptionId == prescription.Id).ToListAsync();
            if (prescriptionDetails == null || !prescriptionDetails.Any())
            {
                methodResult.AddErrorBadRequest(nameof(EnumAppointmentErrorCode.PrescriptionDetailNotFound));
                return methodResult;
            }

            var medicineIds = prescriptionDetails.Select(pd => pd.MedicineId).ToList();
            var medicines = await _unitOfWork.Medicines
                .QueryableAsync()
                .Where(m => medicineIds.Contains(m.Id))
                .ToListAsync();

            var prescriptionDetailModels = prescriptionDetails.Select(pd => new PrescriptionDetailModel
            {
                Id = pd.Id,
                PrescriptionId = pd.Id,
                MedicineId = pd.MedicineId,
                MedicineName = medicines.FirstOrDefault(m => m.Id == pd.MedicineId)?.Name,
                MedicineUnit = medicines.FirstOrDefault(m => m.Id == pd.MedicineId)?.Unit,
                Dosage = pd.Dosage,
                Usage = pd.Usage
            }).ToList();
            var prescriptionModel = new PrescriptionModel
            {
                AppointmentId = prescription.AppointmentId,
                PrescriptionId = prescription.Id,
                Diagnosis = prescription.Diagnosis,
                Instructions = prescription.Instructions,
                PrescriptionDetails = prescriptionDetailModels
            };

            methodResult.Result = prescriptionModel;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
