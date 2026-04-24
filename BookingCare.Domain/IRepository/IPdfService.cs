using BookingCare.Domain.Models.EntityModels;

namespace BookingCare.Domain.IRepository
{
    public interface IPdfService
    {
        byte[] GeneratePrescriptionPdf(MedicalHistoryModel prescriptionDetails);
    }
}