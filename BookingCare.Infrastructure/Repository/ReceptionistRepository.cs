using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Infrastructure.Repository
{
    public class ReceptionistRepository : Repository<Receptionist>, IReceptionistRepository
    {
        public ReceptionistRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
