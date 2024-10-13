using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Repositories.Abstract;
using HastaneRandevuSistemiAPI.ServiceLayer.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.ServiceLayer.Concretes
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task AddPatientAsync(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient), "Patient cannot be null.");
            }
            await _patientRepository.AddAsync(patient);
        }

        public async Task<Patient> GetPatientByIdAsync(string id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with ID {id} not found.");
            }
            return patient;
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _patientRepository.GetAll().ToListAsync();
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient), "Patient cannot be null.");
            }
            var existingPatient = await _patientRepository.GetByIdAsync(patient.Id);
            if (existingPatient == null)
            {
                throw new KeyNotFoundException($"Patient with ID {patient.Id} not found.");
            }
            await _patientRepository.UpdateAsync(patient);
        }

        public async Task DeletePatientAsync(string id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with ID {id} not found.");
            }
            await _patientRepository.DeleteAsync(patient);
        }

        public async Task<Patient> GetPatientByTcAsync(string tc)
        {
            var patient = await _patientRepository.GetPatientbyTcAsync(tc);
            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with TC {tc} not found.");
            }
            return patient;
        }

        public async Task<List<Patient>> GetAllPatientsByDoctorAsync(int doctorId)
        {
            return await _patientRepository.GetAllPatientsByDoctorAsync(doctorId);
        }

    }
}
