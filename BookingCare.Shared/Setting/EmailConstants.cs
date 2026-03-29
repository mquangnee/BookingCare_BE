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
        }

        public static class Subjects
        {
            public const string RegisterOtp = $"[{BrandName}] Mã xác thực đăng ký tài khoản";
            public const string ForgotPasswordOtp = $"[{BrandName}] Mã xác thực lấy lại mật khẩu";
            public const string ChangePasswordOtp = $"[{BrandName}] Mã xác thực đổi mật khẩu";
            public const string AppointmentSuccess = $"[{BrandName}] Xác nhận đặt lịch khám thành công";
        }
    }
}
