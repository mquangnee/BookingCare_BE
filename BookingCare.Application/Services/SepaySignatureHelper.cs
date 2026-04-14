using System.Security.Cryptography;
using System.Text;

namespace BookingCare.Application.Services
{
    public static class SepaySignatureHelper
    {
        public static string Sign(IDictionary<string, string> fields, string secretKey)
        {
            var allowedFields = new[]
            {
                "order_amount",
                "merchant",
                "currency",
                "operation",
                "order_description",
                "order_invoice_number",
                "customer_id",
                "payment_method",
                "success_url",
                "error_url",
                "cancel_url"
            };

            var signedParts = new List<string>();

            foreach (var field in allowedFields)
            {
                if (fields.TryGetValue(field, out var value) && !string.IsNullOrWhiteSpace(value))
                {
                    signedParts.Add($"{field}={value}");
                }
            }

            var signedString = string.Join(",", signedParts);

            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(signedString));

            return Convert.ToBase64String(hashBytes);
        }

        public static string BuildBasicAuth(string merchantId, string secretKey)
        {
            var raw = $"{merchantId}:{secretKey}";
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(raw));
            return $"Basic {base64}";
        }
    }
}