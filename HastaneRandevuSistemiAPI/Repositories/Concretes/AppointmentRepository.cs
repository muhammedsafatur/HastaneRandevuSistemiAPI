using HastaneRandevuSistemiAPI.Contexts;
using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.DataAccesLayer.Concrete
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HospitalDbContext _context;

        public AppointmentRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public async Task<List<Appointment>> GetExpiredAppointmentsAsync()
        {
            return await _context.Appointments
                .Where(a => a.AppointmentDate < DateTime.Now)
                .ToListAsync();
        }

        public async Task AddAsync(Appointment entity)
        {
            await _context.Appointments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<List<Appointment>> GetByDateAsync(DateTime date)
        {
            return await _context.Appointments
                .Where(a => a.AppointmentDate.Date == date.Date)
                .ToListAsync();
        }

        public async Task<List<Appointment>> GetByDoctorIdAsync(int doctorId)
        {
            return await _context.Appointments
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<Appointment> GetByIdAsync(Guid id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task UpdateAsync(Guid id, Appointment entity)
        {
            var appointment = await GetByIdAsync(id);
            if (appointment != null)
            {
                appointment.AppointmentDate = entity.AppointmentDate;
                appointment.DoctorId = entity.DoctorId;
                appointment.Title = entity.Title;
                appointment.PatientTc = entity.PatientTc;
                appointment.Branch = entity.Branch;

                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsOlderThanAsync(DateTime dateTime)
        {
            return await _context.Appointments
                .Where(a => a.AppointmentDate < dateTime)
                .ToListAsync();
        }

    }
}
