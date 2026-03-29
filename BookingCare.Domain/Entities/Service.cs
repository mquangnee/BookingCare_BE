using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Entities
{
    public class Service
    {
        public Guid Id { get; set; }

        public string? ServiceCode { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public int DurationInMinutes { get; set; }
        public string? Description { get; set; }
        public Guid? SpecialtyId { get; set; }
        public Specialty? Specialty { get; set; }
        public EnumPosition? Position { get; set; }
        public Guid? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public ICollection<WorkSessionService>? WorkSessionServices { get; set; }
    }
}
