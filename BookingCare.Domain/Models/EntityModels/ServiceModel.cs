namespace BookingCare.Domain.Models.EntityModels
{
    public class ServiceModel
    {
        public Guid Id { get; set; }
        public string? ServiceCode { get; set; }

        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public int DurationInMinutes { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
