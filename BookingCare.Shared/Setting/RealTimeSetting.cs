namespace BookingCare.Shared.Setting
{
    public static class RealTimeSetting
    {
        public static class NotificationHub
        {
            public const string Pattern = $"/notification";
            public static class Method
            {
                public const string NotificationMessage = $"NotificationMessage";
            }
        }
    }
}
