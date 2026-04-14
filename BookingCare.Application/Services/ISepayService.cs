using BookingCare.Domain.Entities;
using BookingCare.Domain.Models.EntityModels;

namespace BookingCare.Application.Services
{
    public interface ISepayService
    {
        Task<PaymentResponseModel> CreateCheckoutAsync(Payment payment, Appointment appointment);
        Task<SepayOrderDetailResult?> GetOrderDetailAsync(string orderId, CancellationToken cancellationToken = default);
        Task<bool> VerifyPaidOrderAndUpdateAsync(string orderId, CancellationToken cancellationToken = default);
    }

    public class SepayOrderDetailResult
    {
        public string? OrderId { get; set; }
        public string? OrderStatus { get; set; }
        public string? OrderInvoiceNumber { get; set; }
        public decimal OrderAmount { get; set; }
        public string? TransactionId { get; set; }
        public string? TransactionStatus { get; set; }
        public string? PaymentMethod { get; set; }
        public string? RawResponse { get; set; }
    }
}