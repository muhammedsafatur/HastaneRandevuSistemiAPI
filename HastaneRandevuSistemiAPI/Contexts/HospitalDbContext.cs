using HastaneRandevuSistemiAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HastaneRandevuSistemiAPI.Contexts;


public class HospitalDbContext : DbContext

{
    public HospitalDbContext(DbContextOptions opt) : base(opt)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server= localhost,1433; Database = Identit_db; User=sa; Password=admin123456789; TrustServerCertificate=true");

    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    

}
