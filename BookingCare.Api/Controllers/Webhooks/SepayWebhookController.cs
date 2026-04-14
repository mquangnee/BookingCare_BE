using System.Text.Json;
using BookingCare.Application.Services;
using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Shared.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Api.Controllers.Webhooks
{
    [ApiController]
    [Route("api/payments/sepay")]
    public class SepayWebhookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;

        public SepayWebhookController(
            IUnitOfWork unitOfWork,
            INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
        }

        [HttpPost("webhook")]
        public async Task<IActionResult> HandleWebHook([FromBody] SepayWebhookPayload payload, CancellationToken cancellationToken)
        {
            if (payload == null || payload.order == null || string.IsNullOrWhiteSpace(payload.order.order_invoice_number))
            {
                return BadRequest(new { success = false, message = "Invalid payload" });
            }

            if (!string.Equals(payload.notification_type, "ORDER_PAID", StringComparison.OrdinalIgnoreCase))
            {
                return Ok(new { success = true, message = "Ignored notification type" });
            }

            var payment = await _unitOfWork.Payments.QueryableAsync()
                .Include(p => p.Appointment)
                .Include(p => p.Transactions)
                .FirstOrDefaultAsync(p => p.PaymentCode == payload.order.order_invoice_number, cancellationToken);

            if (payment == null)
            {
                return Ok(new { success = false, message = "Payment not found" });
            }

            if (payment.Status == EnumPaymentStatus.Paid)
            {
                return Ok(new { success = true, message = "Already paid" });
            }

            payment.Status = EnumPaymentStatus.Paid;
            payment.PaidAt = DateTime.Now;
            payment.UpdatedDate = DateTime.Now;

            if (payment.Appointment != null)
            {
                payment.Appointment.Status = EnumAppointmentStatus.Approved;
                payment.Appointment.UpdatedDate = DateTime.Now;
            }

            var transaction = new PaymentTransaction
            {
                Id = Guid.NewGuid(),
                PaymentId = payment.Id,
                TransactionCode = payload.transaction?.transaction_id,
                ExternalOrderCode = payload.order.order_id,
                Amount = decimal.TryParse(payload.transaction?.transaction_amount, out var amt) ? (double)amt : payment.Amount,
                Provider = EnumPaymentProvider.Sepay,
                Status = EnumPaymentTransactionStatus.Success,
                GatewayResponse = JsonSerializer.Serialize(payload),
                CreatedDate = DateTime.Now
            };

            await _unitOfWork.PaymentsTransactions.AddAsync(transaction);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            // await _notificationService.SendPaymentSuccessNotification(payment.Appointment);

            return Ok(new { success = true });
        }
    }

    public class SepayWebhookPayload
    {
        public long timestamp { get; set; }
        public string? notification_type { get; set; }
        public SepayWebhookOrder? order { get; set; }
        public SepayWebhookTransaction? transaction { get; set; }
    }

    public class SepayWebhookOrder
    {
        public string? id { get; set; }
        public string? order_id { get; set; }
        public string? order_status { get; set; }
        public string? order_currency { get; set; }
        public string? order_amount { get; set; }
        public string? order_invoice_number { get; set; }
        public string? order_description { get; set; }
    }

    public class SepayWebhookTransaction
    {
        public string? id { get; set; }
        public string? payment_method { get; set; }
        public string? transaction_id { get; set; }
        public string? transaction_type { get; set; }
        public string? transaction_date { get; set; }
        public string? transaction_status { get; set; }
        public string? transaction_amount { get; set; }
        public string? transaction_currency { get; set; }
        public string? authentication_status { get; set; }
    }
}