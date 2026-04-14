using BookingCare.Shared.Enum;
using System.Text.Json.Serialization;

namespace BookingCare.Domain.Entities
{
    public class Service
    {
        public Guid Id { get; set; }
        public Guid? SpecialtyId { get; set; }
        public string? ServiceCode { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public int DurationInMinutes { get; set; }
        public string? Description { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnumPosition? Position { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public Specialty? Specialty { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<Doctor>? Doctors { get; set; }
        public ICollection<WorkSession>? WorkSessions { get; set; }
    }
}
