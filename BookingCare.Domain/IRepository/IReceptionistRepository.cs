using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface IReceptionistRepository : IRepository<Receptionist>
    {
    }

    public class ReceptionistRepository : Repository<Receptionist>, IReceptionistRepository
    {
        public ReceptionistRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
