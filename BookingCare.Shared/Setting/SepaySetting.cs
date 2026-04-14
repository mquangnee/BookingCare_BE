namespace BookingCare.Shared.Setting
{
    public class SepaySetting
    {
        public string MerchantId { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
        public string CheckoutInitUrl { get; set; } = "https://pgapi-sandbox.sepay.vn/v1/checkout/init";
        public string ApiBaseUrl { get; set; } = "https://pgapi-sandbox.sepay.vn/v1";
        public string SuccessUrl { get; set; } = string.Empty;
        public string ErrorUrl { get; set; } = string.Empty;
        public string CancelUrl { get; set; } = string.Empty;
    }
}