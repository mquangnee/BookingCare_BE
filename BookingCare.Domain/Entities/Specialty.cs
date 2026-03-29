namespace BookingCare.Domain.Entities
{
    public class Specialty
    {
        public Guid Id { get; set; }

        public string? SpecialtyCode { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public ICollection<Doctor>? Doctors { get; set; }
    }
}
