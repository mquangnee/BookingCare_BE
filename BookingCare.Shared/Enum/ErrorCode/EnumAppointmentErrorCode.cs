namespace BookingCare.Shared.Enum.ErrorCode
{
    public enum EnumAppointmentErrorCode
    {
        SlotIsTaken,
        PatientHasOverlappingAppointment,
        StatusNotValidForCancellation,
        TimeNotValidForCancellation,
        PrescriptionNotFound,
        PrescriptionDetailNotFound
    }
}
