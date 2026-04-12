using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface IMedicineRepository : IRepository<Medicine>
    {
    }

    public class MedicineRepository : Repository<Medicine>, IMedicineRepository
    {
        public MedicineRepository(DbContext context) : base(context)
        {
        }
    }
}
