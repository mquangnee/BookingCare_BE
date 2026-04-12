using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Entities
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SpecialtyId { get; set; }
        public string? DoctorCode { get; set; }
        public string? AvatarUrl { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EnumGender Gender { get; set; }
        public string? CitizenId { get; set; }
        public int ExperienceYears { get; set; }
        public EnumPosition Position { get; set; }
        public IList<string>? SubSpecialties { get; set; }
        public string? WorkingHistory { get; set; }
        public string? Description { get; set; }
        
        public User? User { get; set; }
        public Specialty? Specialty { get; set; }
        public ICollection<WorkSession>? WorkSessions { get; set; }
        public ICollection<Service>? Services { get; set; }
    }
}
