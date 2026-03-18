namespace BookingCare.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string? PatientCode { get; set; }
    }
}
