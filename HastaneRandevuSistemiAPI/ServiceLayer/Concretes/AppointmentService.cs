using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Repositories.Abstract;
using HastaneRandevuSistemiAPI.ServiceLayer.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq; // IQueryable için gerekli
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.ServiceLayer.Concretes
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment), "Appointment cannot be null.");
            }
            await _appointmentRepository.AddAsync(appointment);
        }

        public async Task<Appointment> GetAppointmentByIdAsync(Guid id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {id} not found.");
            }
            return appointment;
        }

        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await _appointmentRepository.GetAll().ToListAsync();
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment), "Appointment cannot be null.");
            }
            var existingAppointment = await _appointmentRepository.GetByIdAsync(appointment.Id);
            if (existingAppointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {appointment.Id} not found.");
            }
            await _appointmentRepository.UpdateAsync(appointment);
        }

        public async Task DeleteAppointmentAsync(Guid id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {id} not found.");
            }
            await _appointmentRepository.DeleteAsync(appointment);
        }

        public async Task<List<Appointment>> GetByDoctorIdAsync(int doctorId)
        {
            var appointments = await _appointmentRepository.GetByDoctorIdAsync(doctorId);
            if (appointments == null || !appointments.Any())
            {
                throw new KeyNotFoundException($"No appointments found for doctor ID {doctorId}.");
            }
            return appointments;
        }

        public async Task<List<Appointment>> GetByDateAsync(DateTime date)
        {
            var appointments = await _appointmentRepository.GetByDateAsync(date);
            if (appointments == null || !appointments.Any())
            {
                throw new KeyNotFoundException($"No appointments found for the date {date.ToShortDateString()}.");
            }
            return appointments;
        }

        public IQueryable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll(); // Repository'den tüm randevuları alır
        }

        // IAppointmentService arayüzündeki tanımlı metoda uygun dönüş tipi
        Task<List<Appointment>> IAppointmentService.GetByDoctorIdAsync(int doctorId)
        {
            return GetByDoctorIdAsync(doctorId); // Yukarıda tanımlanan metod kullanılır
        }
    }
}
