using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Infrastructure.Repository
{
    public class ChatSessionRepository : Repository<ChatSession>, IChatSessionRepository
    {
        public ChatSessionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
