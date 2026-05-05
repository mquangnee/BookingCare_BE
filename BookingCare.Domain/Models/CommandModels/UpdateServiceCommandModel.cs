namespace BookingCare.Domain.Models.CommandModels
{
    public class UpdateServiceCommandModel
    {
        public Guid Id { get; set; }
        public Guid? SpecialtyId { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
