using System.Net.Http.Headers;
using System.Text.Json;
using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Enum;
using BookingCare.Shared.Setting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookingCare.Application.Services
{
    public class SepayService : ISepayService
    {
        private readonly SepaySetting _sepaySetting;
        private readonly HttpClient _httpClient;
        private readonly IUnitOfWork _unitOfWork;

        public SepayService(
            IOptions<SepaySetting> sepaySetting,
            HttpClient httpClient,
            IUnitOfWork unitOfWork)
        {
            _sepaySetting = sepaySetting.Value;
            _httpClient = httpClient;
            _unitOfWork = unitOfWork;
        }

        public Task<PaymentResponseModel> CreateCheckoutAsync(Payment payment, Appointment appointment)
        {
            var orderAmount = Convert.ToInt64(Math.Round(payment.Amount)).ToString();
            var orderDescription = $"Thanh toan lich hen {appointment.AppointmentCode ?? appointment.Id.ToString("N")[..8]}";
            var orderInvoiceNumber = payment.PaymentCode ?? $"PAY{payment.Id:N}";
            var customerId = appointment.BookerId.ToString();

            var formFields = new Dictionary<string, string>
            {
                ["order_amount"] = orderAmount,
                ["merchant"] = _sepaySetting.MerchantId,
                ["currency"] = "VND",
                ["operation"] = "PURCHASE",
                ["order_description"] = orderDescription,
                ["order_invoice_number"] = orderInvoiceNumber,
                ["customer_id"] = customerId,
                ["payment_method"] = "BANK_TRANSFER",
                ["success_url"] = _sepaySetting.SuccessUrl,
                ["error_url"] = _sepaySetting.ErrorUrl,
                ["cancel_url"] = _sepaySetting.CancelUrl
            };

            var signature = SepaySignatureHelper.Sign(formFields, _sepaySetting.SecretKey);
            formFields["signature"] = signature;

            return Task.FromResult(new PaymentResponseModel
            {
                AppointmentId = appointment.Id,
                PaymentId = payment.Id,
                PaymentCode = payment.PaymentCode ?? string.Empty,
                CheckoutUrl = _sepaySetting.CheckoutInitUrl,
                FormFields = formFields
            });
        }

        public async Task<SepayOrderDetailResult?> GetOrderDetailAsync(string orderId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(orderId))
                throw new ArgumentException("orderId is required", nameof(orderId));

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization =
                AuthenticationHeaderValue.Parse(
                    SepaySignatureHelper.BuildBasicAuth(_sepaySetting.MerchantId, _sepaySetting.SecretKey));

            var requestUrl = $"{_sepaySetting.ApiBaseUrl}/order/detail/{orderId}";
            var response = await _httpClient.GetAsync(requestUrl, cancellationToken);
            var raw = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"SePay order detail failed. Status={(int)response.StatusCode}, Body={raw}");
            }

            using var document = JsonDocument.Parse(raw);
            var root = document.RootElement;

            if (!root.TryGetProperty("data", out var data))
            {
                return new SepayOrderDetailResult { RawResponse = raw };
            }

            string? GetString(JsonElement element, string name)
                => element.TryGetProperty(name, out var p) ? p.GetString() : null;

            decimal GetDecimal(JsonElement element, string name)
            {
                if (!element.TryGetProperty(name, out var p)) return 0;
                if (p.ValueKind == JsonValueKind.Number && p.TryGetDecimal(out var d)) return d;
                if (p.ValueKind == JsonValueKind.String && decimal.TryParse(p.GetString(), out var ds)) return ds;
                return 0;
            }

            var result = new SepayOrderDetailResult
            {
                OrderId = GetString(data, "order_id"),
                OrderStatus = GetString(data, "order_status"),
                OrderInvoiceNumber = GetString(data, "order_invoice_number"),
                OrderAmount = GetDecimal(data, "order_amount"),
                RawResponse = raw
            };

            if (data.TryGetProperty("transaction", out var transaction))
            {
                result.TransactionId = GetString(transaction, "transaction_id");
                result.TransactionStatus = GetString(transaction, "transaction_status");
                result.PaymentMethod = GetString(transaction, "payment_method");
            }

            return result;
        }

        public async Task<bool> VerifyPaidOrderAndUpdateAsync(string orderId, CancellationToken cancellationToken = default)
        {
            var order = await GetOrderDetailAsync(orderId, cancellationToken);
            if (order == null || string.IsNullOrWhiteSpace(order.OrderInvoiceNumber))
            {
                return false;
            }

            var payment = await _unitOfWork.Payments.QueryableAsync()
                .Include(p => p.Appointment)
                .Include(p => p.Transactions)
                .FirstOrDefaultAsync(
                    p => p.PaymentCode == order.OrderInvoiceNumber,
                    cancellationToken);

            if (payment == null)
            {
                return false;
            }

            var latestTransaction = payment.Transactions?
                .OrderByDescending(x => x.CreatedDate)
                .FirstOrDefault();

            if (string.Equals(order.OrderStatus, "CAPTURED", StringComparison.OrdinalIgnoreCase))
            {
                payment.Status = EnumPaymentStatus.Paid;
                payment.PaidAt = DateTime.Now;
                payment.UpdatedDate = DateTime.Now;

                if (payment.Appointment != null)
                {
                    payment.Appointment.Status = EnumAppointmentStatus.Approved;
                    payment.Appointment.UpdatedDate = DateTime.Now;
                }

                if (latestTransaction != null)
                {
                    latestTransaction.Status = EnumPaymentTransactionStatus.Success;
                    latestTransaction.TransactionCode = order.TransactionId ?? latestTransaction.TransactionCode;
                    latestTransaction.GatewayResponse = order.RawResponse;
                    latestTransaction.UpdatedDate = DateTime.Now;
                }

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return true;
            }

            if (string.Equals(order.OrderStatus, "CANCELLED", StringComparison.OrdinalIgnoreCase))
            {
                payment.Status = EnumPaymentStatus.Cancelled;
                payment.UpdatedDate = DateTime.Now;

                if (latestTransaction != null)
                {
                    latestTransaction.Status = EnumPaymentTransactionStatus.Failed;
                    latestTransaction.FailureReason = "SePay order cancelled";
                    latestTransaction.GatewayResponse = order.RawResponse;
                    latestTransaction.UpdatedDate = DateTime.Now;
                }

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return false;
            }

            if (latestTransaction != null)
            {
                latestTransaction.GatewayResponse = order.RawResponse;
                latestTransaction.UpdatedDate = DateTime.Now;
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return false;
        }
    }
}