using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Infrastructure.Repository
{
    public class PatientProfileRepository : Repository<PatientProfile>, IPatientProfileRepository
    {
        public PatientProfileRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
