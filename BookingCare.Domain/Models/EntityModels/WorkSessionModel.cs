using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Models.EntityModels
{
    public class WorkSessionModel
    {
        public Guid? Id { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? SpecialtyId { get; set; }
        public string? DoctorCode { get; set; }
        public string? DoctorName { get; set; }
        public string? SpecialtyName { get; set; }
        public string? AvatarUrl { get; set; }
        public int? DurationInMinutes { get; set; }
        public double? DoctorPrice { get; set; }
        public EnumPosition? Position { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
