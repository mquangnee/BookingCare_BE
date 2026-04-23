namespace BookingCare.Shared.Setting
{
    public class GroqSetting
    {
        public const string SECTION_NAME = "GroqSettings";

        public string? ApiKey { get; set; }
        public string? BaseUrl { get; set; }
        public string? Model { get; set; }
    }
}
