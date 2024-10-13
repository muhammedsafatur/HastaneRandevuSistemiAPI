using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Models.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSistemiAPI.Contexts
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=HastaneRandevuSistemi_db;User=sa;Password=admin123456789;TrustServerCertificate=true");
            }
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Appointment - Doctor ilişkisi
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            // Appointment - Patient ilişkisi
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientTc);

            // Doctor-Patient (Many-to-Many)
            modelBuilder.Entity<DoctorPatient>()
                .HasKey(dp => new { dp.DoctorId, dp.PatientTc });
            modelBuilder.Entity<Patient>()
       .HasIndex(p => p.Tc) // Tc alanı için benzersiz indeks oluştur
       .IsUnique();
            modelBuilder.Entity<Patient>()
      .HasKey(p => p.Tc); // Tc alanını birincil anahtar olarak ayarla
  
            modelBuilder.Entity<DoctorPatient>()
                .HasOne(dp => dp.Doctor)
                .WithMany(d => d.DoctorPatients)
                .HasForeignKey(dp => dp.DoctorId);

            modelBuilder.Entity<DoctorPatient>()
                .HasOne(dp => dp.Patient)
                .WithMany(p => p.DoctorPatients)
                .HasForeignKey(dp => dp.PatientTc);

            // Seed verileri
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Ali", Surname = "Yılmaz",Branch = Branch.Bagimlilik, Role = DRole.SpecialistDoctor },
                new Doctor { Id = 2, Name = "Ayşe", Surname = "Kara",  Branch = Branch.KBB, Role = DRole.AssociateProfessor },
                new Doctor { Id = 3, Name = "Mehmet", Surname = "Demir",  Branch = Branch.GenelCerrahi, Role = DRole.Intern }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Tc = "12345678901", Name = "Zeynep", Surname = "Aydın", Phone = "5551234567", Email = "zeynep.aydin@example.com" },
                new Patient { Tc = "23456789012", Name = "Emre", Surname = "Koç", Phone = "5557654321", Email = "emre.koc@example.com" },
                new Patient { Tc = "34567890123", Name = "Elif", Surname = "Polat", Phone = "5559876543", Email = "elif.polat@example.com" }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = Guid.NewGuid(), DoctorId = 1, PatientTc = "12345678901", AppointmentDate = new DateTime(2024, 10, 15)},
                new Appointment { Id = Guid.NewGuid(), DoctorId = 2, PatientTc = "23456789012", AppointmentDate = new DateTime(2024, 10, 16) },
                new Appointment { Id = Guid.NewGuid(), DoctorId = 3, PatientTc = "34567890123", AppointmentDate = new DateTime(2024, 10, 17) }
            );
        }
    }
}
