using HastaneRandevuSistemiAPI.DataAccesLayer.Concrete;
using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Repositories.Abstract;
using HastaneRandevuSistemiAPI.ServiceLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.ServiceLayer.Concretes
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
           
            _doctorRepository = doctorRepository;
        }

        public async Task AddAsync(Appointment entity)
        {
            var doctor = await _doctorRepository.GetByIdAsync(entity.DoctorId);
            var currentAppointments = await _appointmentRepository.GetAllAsync();

            // Doktorun mevcut randevularını kontrol et
            var doctorAppointmentsCount = currentAppointments.Count(a => a.DoctorId == doctor.Id);

            if (doctorAppointmentsCount >= 10)
            {
                throw new Exception("Doctor cannot have more than 10 appointments.");
            }

            await _appointmentRepository.AddAsync(entity);
        }


        public async Task DeleteAsync(Appointment entity)
        {
            await _appointmentRepository.DeleteAsync(entity.Id);
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _appointmentRepository.GetAllAsync();
        }

        public async Task<List<Appointment>> GetByDateAsync(DateTime date)
        {
            return await _appointmentRepository.GetByDateAsync(date);
        }

        public async Task<List<Appointment>> GetByDoctorIdAsync(int doctorId)
        {
            return await _appointmentRepository.GetByDoctorIdAsync(doctorId);
        }

        public async Task<Appointment> GetByIdAsync(Guid id)
        {
            return await _appointmentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Appointment entity)
        {
            await _appointmentRepository.UpdateAsync(entity.Id, entity);
        }
    }
}
