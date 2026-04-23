using BookingCare.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Text.Json;

namespace BookingCare.Infrastructure
{
    public class DataContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
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
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionDetail> PrescriptionDetails { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ChatSession> ChatSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Identity Configurations
            builder.Entity<Admin>()
                .HasOne(a => a.User)
                .WithOne(u => u.Admin)
                .HasForeignKey<Admin>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithOne(u => u.Patient)
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PatientProfile>()
                .HasOne(pp => pp.Patient)
                .WithMany(p => p.PatientProfiles)
                .HasForeignKey(pp => pp.PatientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

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
            
            builder.Entity<Doctor>()
                .HasOne(d => d.Service)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.ServiceId)
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

            builder.Entity<Appointment>()
                .HasOne(a => a.Prescription)
                .WithOne(p => p.Appointment)
                .HasForeignKey<Appointment>(a => a.PrescriptionId)
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

            builder.Entity<Prescription>()
                .HasOne(p => p.Appointment)
                .WithOne(a => a.Prescription)
                .HasForeignKey<Prescription>(p => p.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PrescriptionDetail>()
                .HasOne(pd => pd.Prescription)
                .WithMany(p => p.PrescriptionDetails)
                .HasForeignKey(pd => pd.PrescriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Medicine>()
                .HasMany(m => m.PrescriptionDetails)
                .WithOne(pd => pd.Medicine)
                .HasForeignKey(pd => pd.MedicineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.Service)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Payment>()
                .HasOne(p => p.Appointment)
                .WithOne(a => a.Payment)
                .HasForeignKey<Payment>(p => p.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PaymentTransaction>()
                .HasOne(pt => pt.Payment)
                .WithMany(p => p.Transactions)
                .HasForeignKey(pt => pt.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ChatSession>()
                .HasOne(cs => cs.User)
                .WithMany()
                .HasForeignKey(cs => cs.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ChatMessage>()
                .HasOne(cm => cm.ChatSession)
                .WithMany(cs => cs.ChatMessages)
                .HasForeignKey(cm => cm.ChatSessionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ChatSession>()
                .HasIndex(cs => new { cs.UserId, cs.CreatedDate })
                .HasDatabaseName("IX_ChatSessions_UserId_CreatedDate");

            builder.Entity<ChatMessage>()
                .HasIndex(cm => new { cm.ChatSessionId, cm.CreatedDate })
                .HasDatabaseName("IX_ChatMessages_ChatSessionId_CreatedDate");
            #endregion

            #region Convertion for Enums to string
            builder.Entity<Doctor>()
                .Property(d => d.Position)
                .HasConversion<string>();

            builder.Entity<Doctor>()
                .Property(d => d.Gender)
                .HasConversion<string>();

            builder.Entity<Medicine>()
                .Property(m => m.Unit)
                .HasConversion<string>();

            builder.Entity<Medicine>()
                .Property(m => m.Status)
                .HasConversion<string>();

            builder.Entity<Appointment>()
                .Property(a => a.Type)
                .HasConversion<string>();

            builder.Entity<Appointment>()
                .Property(a => a.Status)
                .HasConversion<string>();

            builder.Entity<Appointment>()
                .Property(a => a.Priority)
                .HasConversion<string>();

            builder.Entity<PatientProfile>()
                .Property(a => a.Gender)
                .HasConversion<string>();

            builder.Entity<PatientProfile>()
                .Property(a => a.Relationship)
                .HasConversion<string>();

            builder.Entity<PatientProfile>()
                .Property(a => a.BloodType)
                .HasConversion<string>();

            builder.Entity<Notification>()
                .Property(n => n.Type)
                .HasConversion<string>();

            builder.Entity<NotificationType>()
                .Property(nt => nt.Content)
                .HasConversion<string>();

            builder.Entity<Payment>()
                .Property(p => p.Status)
                .HasConversion<string>();

            builder.Entity<Payment>()
                .Property(p => p.Method)
                .HasConversion<string>();

            builder.Entity<PaymentTransaction>()
                .Property(pt => pt.Provider)
                .HasConversion<string>();

            builder.Entity<PaymentTransaction>()
                .Property(pt => pt.Status)
                .HasConversion<string>();

            builder.Entity<ProfileShare>()
                .Property(ps => ps.ShareStatus)
                .HasConversion<string>();

            builder.Entity<ProfileShare>()
                .Property(ps => ps.SharePermission)
                .HasConversion<string>();

            builder.Entity<Receptionist>()
                .Property(r => r.Gender)
                .HasConversion<string>();

            builder.Entity<Service>()
                .Property(s => s.Position)
                .HasConversion<string>();

            builder.Entity<ChatMessage>()
                .Property(cm => cm.ChatRole)
                .HasConversion<string>();
            #endregion

            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Seeder");

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

            var adminJson = File.ReadAllText(Path.Combine(path, "admins.json"));
            var admins = JsonSerializer.Deserialize<List<Admin>>(adminJson, jsonOptions);
            if (admins != null) builder.Entity<Admin>().HasData(admins);

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

            var medicinesJson = File.ReadAllText(Path.Combine(path, "medicines.json"));
            var medicines = JsonSerializer.Deserialize<List<Medicine>>(medicinesJson, jsonOptions);
            if (medicines != null) builder.Entity<Medicine>().HasData(medicines);
        }
    }
}
