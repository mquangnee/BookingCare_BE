using BookingCare.Domain.Entities;
using BookingCare.Infrastructure.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BookingCare.Infrastructure
{
    public class DataContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientProfile> PatientProfiles { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<ProfileShare> ProfileShares { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<WorkSession> WorkSessions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<WorkSessionService> WorkSessionServices { get; set; }
        public DbSet<AppointmentService> AppointmentServices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<WorkSessionService>()
                .HasOne(wss => wss.WorkSession)
                .WithMany(ws => ws.WorkSessionServices)
                .HasForeignKey(wss => wss.WorkSessionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WorkSessionService>()
                .HasOne(wss => wss.Service)
                .WithMany(s => s.WorkSessionServices)
                .HasForeignKey(wss => wss.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.WorkSession)
                .WithMany(ws => ws.Appointments)
                .HasForeignKey(a => a.WorkSessionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Service>()
                .HasOne(s => s.Doctor)
                .WithMany(d => d.Services)
                .HasForeignKey(s => s.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            // Đường dẫn tới thư mục chứa file json của bạn
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Seeder");

            // Seed Chuyên khoa
            var specialtiesJson = File.ReadAllText(Path.Combine(path, "specialties.json"));
            var specialties = JsonSerializer.Deserialize<List<Specialty>>(specialtiesJson);
            if (specialties != null) builder.Entity<Specialty>().HasData(specialties);

            // Seed Bác sĩ
            var doctorsJson = File.ReadAllText(Path.Combine(path, "doctors.json"));
            var doctors = JsonSerializer.Deserialize<List<Doctor>>(doctorsJson);
            if (doctors != null) builder.Entity<Doctor>().HasData(doctors);

            // Seed Dịch vụ (Ma trận giá)
            var servicesJson = File.ReadAllText(Path.Combine(path, "services.json"));
            var services = JsonSerializer.Deserialize<List<Service>>(servicesJson);
            if (services != null) builder.Entity<Service>().HasData(services);

            var workSessionJson = File.ReadAllText(Path.Combine(path, "worksessions.json"));
            var workSessions = JsonSerializer.Deserialize<List<WorkSession>>(workSessionJson);
            if (workSessions != null) builder.Entity<WorkSession>().HasData(workSessions);
        }
    }
}
