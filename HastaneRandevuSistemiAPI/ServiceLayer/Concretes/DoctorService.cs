using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Repositories.Abstract;
using HastaneRandevuSistemiAPI.ServiceLayer.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.ServiceLayer.Concretes
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor), "Doctor cannot be null.");
            }
            await _doctorRepository.AddAsync(doctor);
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                throw new KeyNotFoundException($"Doctor with ID {id} not found.");
            }
            return doctor;
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await _doctorRepository.GetAll().ToListAsync(); // IQueryable'ı listeye çeviriyoruz
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor), "Doctor cannot be null.");
            }
            var existingDoctor = await _doctorRepository.GetByIdAsync(doctor.Id);
            if (existingDoctor == null)
            {
                throw new KeyNotFoundException($"Doctor with ID {doctor.Id} not found.");
            }
            await _doctorRepository.UpdateAsync(doctor);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                throw new KeyNotFoundException($"Doctor with ID {id} not found.");
            }
            await _doctorRepository.DeleteAsync(doctor);
        }

        public async Task<List<Patient>> GetAllPatientsAsync(int doctorId)
        {
            return await Task.FromResult(_doctorRepository.GetAllPatients(doctorId));
        }
    }
}
