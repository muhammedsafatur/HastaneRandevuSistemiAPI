using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Repositories.Abstract;
using HastaneRandevuSistemiAPI.ServiceLayer.Abstracts;
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

        public async Task AddAsync(Patient entity)
        {
            await _patientRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(Patient entity)
        {
            await _patientRepository.DeleteAsync(entity.Id); // ID özelliğini kullanarak silme
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _patientRepository.GetAllAsync();
        }

        public async Task<List<Patient>> GetAllPatientsByDoctorAsync(int doctorId)
        {
            return await _patientRepository.GetAllPatientsByDoctorAsync(doctorId);
        }

        public async Task<Patient> GetByIdAsync(string id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        public async Task<Patient> GetPatientByTcAsync(string tc)
        {
            return await _patientRepository.GetPatientByTcAsync(tc);
        }

        public async Task UpdateAsync(Patient entity)
        {
            await _patientRepository.UpdateAsync(entity.Id, entity); // ID özelliğini kullanarak güncelleme
        }
    }
}
