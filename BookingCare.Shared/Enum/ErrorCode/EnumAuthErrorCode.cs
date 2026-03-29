namespace BookingCare.Shared.Enum.ErrorCode
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
        VerifyPasswordFailed,
        OldPasswordNotMatch,
        ChangePasswordFailed,
    }
}
