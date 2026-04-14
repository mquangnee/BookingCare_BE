using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Entities
{
    public class PaymentTransaction
    {
        public Guid Id { get; set; }
        public Guid PaymentId { get; set; }
        public string? TransactionCode { get; set; }
        public string? ExternalOrderCode { get; set; }
        public double Amount { get; set; }
        public EnumPaymentProvider Provider { get; set; }
        public EnumPaymentTransactionStatus Status { get; set; } = EnumPaymentTransactionStatus.Pending;
        public string? GatewayResponse { get; set; }
        public string? FailureReason { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public Payment? Payment { get; set; }
    }
}
