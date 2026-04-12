using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
    }

    public class PrescriptionRepository : Repository<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(DbContext context) : base(context)
        {
        }
    }
}
