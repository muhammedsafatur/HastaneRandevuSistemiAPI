using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Models.Entities.Enums;
using HastaneRandevuSistemiAPI.Repositories.Abstract;
using HastaneRandevuSistemiAPI.ServiceLayer.Abstracts;
using System;
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

        public async Task AddAsync(Doctor entity)
        {
            await _doctorRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(Doctor entity)
        {
            await _doctorRepository.DeleteAsync(entity.Id);
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _doctorRepository.GetAllAsync();
        }

        public async Task<List<Doctor>> GetAllDoctorsWithAppointmentsAsync()
        {
            return await _doctorRepository.GetAllDoctorsWithAppointmentsAsync();
        }

        public async Task<Doctor> GetByBranchAsync(Branch branch)
        {
            return await _doctorRepository.GetByBranchAsync(branch);
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            return await _doctorRepository.GetByIdAsync(id);
        }

        public async Task<List<Doctor>> GetDoctorsByRoleAsync(DRole role)
        {
            return await _doctorRepository.GetDoctorsByRoleAsync(role);
        }

        public async Task UpdateAsync(Doctor entity)
        {
            await _doctorRepository.UpdateAsync(entity.Id, entity);
        }
    }
}
