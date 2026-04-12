namespace BookingCare.Shared.Setting
{
    public static class HubSetting
    {
        public static class Pattern
        {
            public const string NotificationHub = $"/notification";
            public const string AppointmentHub = $"/appointment";
        }

        public static class Method
        {
            public const string NotificationMessage = $"NotificationMessage";
            public const string AppointmentStatusChanged = $"AppointmentStatusChanged";
        }
    }
}
