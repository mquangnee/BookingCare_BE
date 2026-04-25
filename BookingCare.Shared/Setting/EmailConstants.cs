namespace BookingCare.Shared.Setting
{
    public static class EmailConstants
    {
        public const string BrandName = "BookingCare";

        public static class Keys
        {
            public const string Email = "Email";
            public const string Otp = "Otp";
            public const string FullName = "FullName";
            public const string BookerName = "BookerName";
            public const string Date = "Date";
            public const string AppointmentCount = "AppointmentCount";
            public const string AppointmentRows = "AppointmentRows";
            public const string Password = "Password";
        }

        public static class Subjects
        {
            public const string RegisterOtp = $"{BrandName} - Mã xác thực đăng ký tài khoản";
            public const string ForgotPasswordOtp = $"{BrandName} - Mã xác thực lấy lại mật khẩu";
            public const string ChangePasswordOtp = $"{BrandName} - Mã xác thực đổi mật khẩu";
            public const string AppointmentSuccess = $"{BrandName} - Xác nhận đặt lịch khám thành công";
            public const string DailySummary = BrandName + " - Lịch khám ngày {{Date}} của bạn";
            public const string CreateDoctorAccount = $"{BrandName} - Thông tin tài khoản bác sĩ của bạn";
            public const string CreateReceptionistAccount = $"{BrandName} - Thông tin tài khoản lễ tân của bạn";
        }
    }
}
