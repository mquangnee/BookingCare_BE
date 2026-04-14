using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid AppointmentId { get; set; }
        public string? PaymentCode { get; set; }
        public double Amount { get; set; }
        public EnumPaymentStatus Status { get; set; } = EnumPaymentStatus.Pending;
        public EnumPaymentMethod Method { get; set; }
        public DateTime? PaidAt { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public Appointment? Appointment { get; set; }
        public ICollection<PaymentTransaction>? Transactions { get; set; }
    }
}
