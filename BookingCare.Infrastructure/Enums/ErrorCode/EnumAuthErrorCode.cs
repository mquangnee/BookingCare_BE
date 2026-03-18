namespace BookingCare.Infrastructure.Enums.ErrorCode
{
    public enum EnumAuthErrorCode
    {
        EmailAndPasswordNotEmpty,
        AccountLockedOut,
        EmailAndPasswordIncorrect,
        EmailNotExistOrInvalid,
        ConfirmPasswordNotMatch,
        OtpInvalid,
        RegisterFailed,
        VerifyPasswordFailed
    }
}
