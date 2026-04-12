using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface IPrescriptionDetailRepository : IRepository<PrescriptionDetail>
    {
    }

    public class PrescriptionDetailRepository : Repository<PrescriptionDetail>, IPrescriptionDetailRepository
    {
        public PrescriptionDetailRepository(DbContext context) : base(context)
        {
        }
    }
}
