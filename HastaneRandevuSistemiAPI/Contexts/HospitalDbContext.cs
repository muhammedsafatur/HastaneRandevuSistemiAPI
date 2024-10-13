using HastaneRandevuSistemiAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HastaneRandevuSistemiAPI.Contexts
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {

        }

    }
}
