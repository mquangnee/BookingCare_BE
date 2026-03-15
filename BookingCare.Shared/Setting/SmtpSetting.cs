namespace BookingCare.Shared.Setting
{
    public class SmtpSetting
    {
        public const string SECTION_NAME = "Smtp";

        public string? From { get; set; }
        public string? Password { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
    }
}
