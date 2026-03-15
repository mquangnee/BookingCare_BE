namespace BookingCare.Infrastructure.Enums.ErrorCode
{
    public enum EnumAuthErrorCode
    {
        EmailAndPasswordNotEmpty,
        AccountLockedOut,
        EmailAndPasswordIncorrect,
        ConfirmPasswordNotMatch,
        OtpInvalid,
        RegisterFailed,
    }
}
