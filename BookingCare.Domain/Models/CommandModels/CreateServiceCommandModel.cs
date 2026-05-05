namespace BookingCare.Domain.Models.CommandModels
{
    public class CreateServiceCommandModel
    {
        public Guid? SpecialtyId { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
