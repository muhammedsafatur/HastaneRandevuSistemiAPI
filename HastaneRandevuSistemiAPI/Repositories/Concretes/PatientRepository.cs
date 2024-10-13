using HastaneRandevuSistemiAPI.Contexts;
using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Models.Entities.Enums;
using HastaneRandevuSistemiAPI.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
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

        public async Task DeleteAsync(Patient entity)
        {
            var patientToRemove = await GetByIdAsync(entity.Id);
            if (patientToRemove != null)
            {
                _context.Patients.Remove(patientToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<Patient> GetAll()
        {
            return _context.Patients.AsQueryable();
        }

     

        public async Task<List<Patient>> GetAllPatientsByDoctorAsync(int id)
        {
            return await _context.Appointments
                .Where(a => a.DoctorId == id)
                .Select(a => a.Patient)
                .ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(string id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<Patient> GetPatientbyTcAsync(string tc)
        {
            return await _context.Patients
                .FirstOrDefaultAsync(p => p.Tc == tc); // Patient sınıfında Tc özelliği olmalı
        }

        public async Task UpdateAsync(Patient entity)
        {
            _context.Patients.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
