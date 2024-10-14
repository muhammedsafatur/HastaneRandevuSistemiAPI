using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.ServiceLayer.Abstracts
{
    public interface IAppointmentService
    {
        Task AddAsync(Appointment entity);
        Task DeleteAsync(Appointment entity);
        Task<List<Appointment>> GetAllAsync();
        Task<List<Appointment>> GetByDateAsync(DateTime date);
        Task<List<Appointment>> GetByDoctorIdAsync(int doctorId);
        Task<Appointment> GetByIdAsync(Guid id);
        Task UpdateAsync(Appointment entity);
        Task CleanupOldAppointmentsAsync();
    }
}
