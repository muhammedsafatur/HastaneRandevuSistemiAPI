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
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalDbContext _context;

        public DoctorRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Doctor entity)
        {
            await _context.Doctors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<List<Doctor>> GetAllDoctorsWithAppointmentsAsync()
        {
            return await _context.Doctors
                .Include(d => d.Appointments)
                .ToListAsync();
        }

        public async Task<Doctor> GetByBranchAsync(Branch branch)
        {
            return await _context.Doctors
                .FirstOrDefaultAsync(d => d.Branch == branch);
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task UpdateAsync(int id, Doctor entity)
        {
            var doctor = await GetByIdAsync(id);
            if (doctor != null)
            {
                doctor.Name = entity.Name;
                doctor.Branch = entity.Branch;
                doctor.Role = entity.Role;

                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Doctor>> GetDoctorsByRoleAsync(DRole role)
        {
            return await _context.Doctors
                .Where(d => d.Role == role)
                .ToListAsync();
        }

    }
}
