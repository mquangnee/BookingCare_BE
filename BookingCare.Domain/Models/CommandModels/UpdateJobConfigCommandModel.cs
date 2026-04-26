namespace BookingCare.Domain.Models.CommandModels
{
    public class UpdateJobConfigCommandModel
    {
        public string JobName { get; set; } = string.Empty;
        public string? CronExpression { get; set; }
        public bool? IsEnabled { get; set; }
    }
}