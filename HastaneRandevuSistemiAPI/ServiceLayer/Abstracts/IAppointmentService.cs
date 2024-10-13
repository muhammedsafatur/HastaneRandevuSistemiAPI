using HastaneRandevuSistemiAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.ServiceLayer.Abstracts
{
    public interface IAppointmentService
    {
        Task AddAppointmentAsync(Appointment appointment);
        Task<Appointment> GetAppointmentByIdAsync(Guid id);
        Task<List<Appointment>> GetAllAppointmentsAsync();
        Task UpdateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(Guid id);
        Task<List<Appointment>> GetByDoctorIdAsync(int doctorId); // Değişiklik burada
        Task<List<Appointment>> GetByDateAsync(DateTime date);
        IQueryable<Appointment> GetAll();
    }
}
