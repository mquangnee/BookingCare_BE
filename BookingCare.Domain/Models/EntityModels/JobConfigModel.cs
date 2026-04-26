namespace BookingCare.Domain.Models.EntityModels
{
    public class JobConfigModel
    {
        public string Id { get; set; } = string.Empty;
        public string JobName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string CronExpression { get; set; } = string.Empty;
        public bool IsEnabled { get; set; }
        public string? Endpoint { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? NextRun { get; set; }
    }
}