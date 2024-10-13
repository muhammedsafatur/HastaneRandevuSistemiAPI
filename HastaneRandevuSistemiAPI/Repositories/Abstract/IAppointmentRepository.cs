using HastaneRandevuSistemiAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.Repositories.Abstract
{
    public interface IAppointmentRepository
    {
        Task AddAsync(Appointment entity);
        Task DeleteAsync(Appointment entity);
        Task<Appointment> GetByIdAsync(Guid id);
        IQueryable<Appointment> GetAll(); // IQueryable döndürüyor.
        Task<List<Appointment>> GetByDoctorIdAsync(int doctorId);
        Task<List<Appointment>> GetByDateAsync(DateTime date);
        Task UpdateAsync(Appointment entity); // Burayı ekleyin
    }
}
