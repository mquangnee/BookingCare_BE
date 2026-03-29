namespace BookingCare.Domain.Models.EntityModels
{
    public  class AvailableDayModel
    {
        public DateTime Date { get; set; }
        public List<AvailableTimeSlotModel>? AvailableTimeSlots { get; set; }
    }
    public class AvailableTimeSlotModel
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string TimeString => $"{StartTime:hh\\:mm} - {EndTime:hh\\:mm}";
        public bool IsFull { get; set; } = false;
    }
}
