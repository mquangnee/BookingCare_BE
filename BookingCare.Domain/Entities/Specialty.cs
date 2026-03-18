namespace BookingCare.Domain.Entities
{
    public class Specialty
    {
        public Guid Id { get; set; }
        public string? SpecialtyCode { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
    }
}
