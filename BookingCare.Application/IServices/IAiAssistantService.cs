namespace BookingCare.Application.IServices
{
    public interface IAiAssistantService
    {
        Task<string> ProcessChatAsync(string? message);
    }
}
