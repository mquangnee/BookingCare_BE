using System;

namespace BookingCare.Domain.Models.EntityModels
{
    public class PaymentResponseModel
    {
        public string CheckoutUrl { get; set; } = string.Empty;
        public Guid AppointmentId { get; set; }
        public Guid PaymentId { get; set; }
        public string PaymentCode { get; set; } = string.Empty;
        public Dictionary<string, string> FormFields { get; set; } = new();
    }
}
