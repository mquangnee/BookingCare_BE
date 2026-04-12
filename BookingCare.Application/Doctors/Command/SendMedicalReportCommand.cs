using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookingCare.Application.Doctors.Command
{
    public class SendMedicalReportCommand : SendMedicalReportCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class SendMedicalReportCommandHandler : IRequestHandler<SendMedicalReportCommand, MethodResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SendMedicalReportCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<bool>> Handle(SendMedicalReportCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            var appointment = await _unitOfWork.Appointments.GetByIdAsync(request.AppointmentId);
            if (appointment == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.AppointmentId), request.AppointmentId);
                return methodResult;
            }
            var prescription = new Prescription
            {
                Id = Guid.NewGuid(),
                AppointmentId = request.AppointmentId,
                Diagnosis = request.Diagnosis,
                Instructions = request.Instructions
            };
            appointment.PrescriptionId = prescription.Id;
            appointment.Status = EnumAppointmentStatus.Completed;
            _unitOfWork.Appointments.Update(appointment);

            var prescriptionDetailList = new List<PrescriptionDetail>();
            foreach (var prescriptionDetail in request.PrescriptionDetails!)
            {
                var prescriptionDetailEntity = new PrescriptionDetail
                {
                    Id = Guid.NewGuid(),
                    PrescriptionId = prescription.Id,
                    MedicineId = prescriptionDetail.MedicineId,
                    Dosage = prescriptionDetail.Dosage,
                    Usage = prescriptionDetail.Usage
                };
                prescriptionDetailList.Add(prescriptionDetailEntity);
            }
            prescription.PrescriptionDetails = prescriptionDetailList;
            await _unitOfWork.Prescriptions.AddAsync(prescription);
            await _unitOfWork.PrescriptionDetails.AddRangeAsync(prescriptionDetailList);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
