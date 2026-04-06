using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingCare.Domain.IRepository
{
    public interface IAdminRepository : IRepository<Admin>
    {
    }

    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}