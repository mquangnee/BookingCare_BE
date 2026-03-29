using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingCare.Domain.IRepository
{
    public interface IAppointmentServiceRepository : IRepository<AppointmentService>
    {
    }

    public class AppointmentServiceRepository : Repository<AppointmentService>, IAppointmentServiceRepository
    {
        public AppointmentServiceRepository(DbContext context) : base(context)
        {
        }
    }
}
