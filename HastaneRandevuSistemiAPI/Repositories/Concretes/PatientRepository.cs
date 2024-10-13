using HastaneRandevuSistemiAPI.Contexts;
using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Models.Entities.Enums;
using HastaneRandevuSistemiAPI.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.DataAccesLayer.Concrete
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalDbContext _context;

        public PatientRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Patient entity)
        {
            await _context.Patients.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var patient = await GetByIdAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<List<Patient>> GetAllPatientsByDoctorAsync(int id)
        {
            return await _context.Appointments
                .Where(a => a.DoctorId == id)
                .Select(a => a.Patient)
                .Distinct()
                .ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(string id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<Patient> GetPatientByTcAsync(string tc)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.Tc == tc);
        }

        public async Task<List<Patient>> GetPatientsByBranchAsync(Branch branch)
        {
            return await _context.Patients
                .Where(p => p.Branch == branch)
                .ToListAsync();
        }

        public async Task<List<Patient>> GetPatientsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Appointments
                .Where(a => a.AppointmentDate >= startDate && a.AppointmentDate <= endDate)
                .Select(a => a.Patient)
                .Distinct()
                .ToListAsync();
        }

        public async Task UpdateAsync(string id, Patient entity)
        {
            var existingPatient = await GetByIdAsync(id);
            if (existingPatient != null)
            {
                _context.Entry(existingPatient).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
