using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.Repositories.Abstract
{
    public interface IAppointmentRepository : IEntityRepository<Appointment, Guid>
    {

        Task<List<Appointment>> GetByDateAsync(DateTime date);
        Task<List<Appointment>> GetByDoctorIdAsync(int doctorId);
        Task<List<Appointment>> GetExpiredAppointmentsAsync();
    }
}
