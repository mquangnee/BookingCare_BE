namespace BookingCare.Shared.Setting
{
    public class JwtSetting
    {
        public const string SECTION_NAME = "Jwt";

        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? SecretKey { get; set; }
        public int AccessTokenMinutes { get; set; }
        public int RefreshTokenDays { get; set; }
    }
}
