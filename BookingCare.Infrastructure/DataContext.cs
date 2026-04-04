using BookingCare.Domain.Entities;
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
        public DbSet<AppointmentService> AppointmentServices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithOne(u => u.Patient)
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PatientProfile>()
                .HasOne(pp => pp.Patient)
                .WithMany(p => p.PatientProfiles)
                .HasForeignKey(pp => pp.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne(u => u.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Doctor>()
                .HasOne(d => d.Specialty)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.SpecialtyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Receptionist>()
                .HasOne(r => r.User)
                .WithOne(u => u.Receptionist)
                .HasForeignKey<Receptionist>(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<WorkSession>()
                .HasOne(ws => ws.Doctor)
                .WithMany(d => d.WorkSessions)
                .HasForeignKey(ws => ws.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Service>()
                .HasOne(s => s.Doctor)
                .WithMany(d => d.Services)
                .HasForeignKey(s => s.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Service>()
                .HasOne(s => s.Specialty)
                .WithMany(sp => sp.Services)
                .HasForeignKey(s => s.SpecialtyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WorkSession>()
                .HasOne(ws => ws.Service)
                .WithMany(s => s.WorkSessions)
                .HasForeignKey(ws => ws.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.WorkSession)
                .WithMany(ws => ws.Appointments)
                .HasForeignKey(a => a.WorkSessionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.PatientProfile)
                .WithMany(pp => pp.Appointments)
                .HasForeignKey(a => a.PatientProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Appointment>()
                .HasOne(a => a.Booker)
                .WithMany()
                .HasForeignKey(a => a.BookerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AppointmentService>()
                .HasOne(asvc => asvc.Appointment)
                .WithMany(a => a.AppointmentServices)
                .HasForeignKey(asvc => asvc.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AppointmentService>()
                .HasOne(asvc => asvc.Service)
                .WithMany(s => s.AppointmentServices)
                .HasForeignKey(asvc => asvc.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProfileShare>()
                .HasOne(ps => ps.PatientProfile)
                .WithMany(pp => pp.SharedProfiles)
                .HasForeignKey(ps => ps.PatientProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProfileShare>()
                .HasOne(ps => ps.SharedByUser)
                .WithMany()
                .HasForeignKey(ps => ps.SharedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProfileShare>()
                .HasOne(ps => ps.SharedToUser)
                .WithMany()
                .HasForeignKey(ps => ps.SharedToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Notification>()
                .HasOne(n => n.Receiver)
                .WithMany()
                .HasForeignKey(n => n.ReceiverId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Notification>()
                .HasOne(n => n.Sender)
                .WithMany()
                .HasForeignKey(n => n.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Notification>()
                .HasOne(n => n.NotificationType)
                .WithMany()
                .HasForeignKey(n => n.NotificationTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Seeder");

            // QUAN TRỌNG: Thiết lập này giúp bỏ qua lỗi phân biệt hoa/thường (ví dụ: "id" trong JSON sẽ tự map vào "Id" trong C#)
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var rolesJson = File.ReadAllText(Path.Combine(path, "roles.json"));
            var roles = JsonSerializer.Deserialize<List<IdentityRole<Guid>>>(rolesJson, jsonOptions);
            if (roles != null) builder.Entity<IdentityRole<Guid>>().HasData(roles);

            var usersJson = File.ReadAllText(Path.Combine(path, "users.json"));
            var users = JsonSerializer.Deserialize<List<User>>(usersJson, jsonOptions);
            if (users != null) builder.Entity<User>().HasData(users);

            var userRolesJson = File.ReadAllText(Path.Combine(path, "userroles.json"));
            var userRoles = JsonSerializer.Deserialize<List<IdentityUserRole<Guid>>>(userRolesJson, jsonOptions);
            if (userRoles != null) builder.Entity<IdentityUserRole<Guid>>().HasData(userRoles);

            var notificationTypesJson = File.ReadAllText(Path.Combine(path, "notificationtypes.json"));
            var notificationTypes = JsonSerializer.Deserialize<List<NotificationType>>(notificationTypesJson, jsonOptions);
            if (notificationTypes != null) builder.Entity<NotificationType>().HasData(notificationTypes);

            var specialtiesJson = File.ReadAllText(Path.Combine(path, "specialties.json"));
            var specialties = JsonSerializer.Deserialize<List<Specialty>>(specialtiesJson, jsonOptions);
            if (specialties != null) builder.Entity<Specialty>().HasData(specialties);

            var doctorsJson = File.ReadAllText(Path.Combine(path, "doctors.json"));
            var doctors = JsonSerializer.Deserialize<List<Doctor>>(doctorsJson, jsonOptions);
            if (doctors != null) builder.Entity<Doctor>().HasData(doctors);

            var servicesJson = File.ReadAllText(Path.Combine(path, "services.json"));
            var services = JsonSerializer.Deserialize<List<Service>>(servicesJson, jsonOptions);
            if (services != null) builder.Entity<Service>().HasData(services);

            var workSessionJson = File.ReadAllText(Path.Combine(path, "worksessions.json"));
            var workSessions = JsonSerializer.Deserialize<List<WorkSession>>(workSessionJson, jsonOptions);
            if (workSessions != null) builder.Entity<WorkSession>().HasData(workSessions);
        }
    }
}
