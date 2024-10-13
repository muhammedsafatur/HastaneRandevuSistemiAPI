using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.ServiceLayer.Abstracts
{
    public interface IAppointmentService : IEntityService<Appointment, Guid>
    {
        Task<List<Appointment>> GetByDateAsync(DateTime date);
        Task<List<Appointment>> GetByDoctorIdAsync(int doctorId);
    }
}
