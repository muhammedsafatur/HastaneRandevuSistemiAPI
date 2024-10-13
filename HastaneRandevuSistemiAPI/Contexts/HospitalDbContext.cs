using HastaneRandevuSistemiAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSistemiAPI.Contexts
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureAppointmentModel(modelBuilder);
            ConfigurePatientModel(modelBuilder);
        }

        private void ConfigureAppointmentModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientTc);
        }

        private void ConfigurePatientModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasKey(p => p.Tc);

            modelBuilder.Entity<Patient>()
                .HasIndex(p => p.Tc)
                .IsUnique();
        }
    }
}
