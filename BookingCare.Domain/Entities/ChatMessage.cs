using BookingCare.Shared.Enum;

namespace BookingCare.Domain.Entities
{
    public class ChatMessage
    {
        public Guid Id { get; set; }
        public Guid ChatSessionId { get; set; }
        public EnumChatMessageRole ChatRole { get; set; }
        public string? Content { get; set; }
        public string? ToolId { get; set; }
        public string? ToolName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ChatSession? ChatSession { get; set; }
    }
}
