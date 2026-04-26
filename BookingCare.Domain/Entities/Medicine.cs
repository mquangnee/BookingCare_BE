using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Entities
{
    public class Medicine
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public EnumMedicineUnit Unit { get; set; }
        public string? Function { get; set; }
        public EnumStatus Status { get; set; } = EnumStatus.Active;
        public ICollection<PrescriptionDetail>? PrescriptionDetails { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
