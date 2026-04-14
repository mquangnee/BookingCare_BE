using BookingCare.Shared.Enum;
using System.Text.Json.Serialization;

namespace BookingCare.Domain.Entities
{
    public class Medicine
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnumMedicineUnit Unit { get; set; }
        public string? Function { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnumStatus Status { get; set; } = EnumStatus.Active;
        public ICollection<PrescriptionDetail>? PrescriptionDetails { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
