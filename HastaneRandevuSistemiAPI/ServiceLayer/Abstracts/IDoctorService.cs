using HastaneRandevuSistemiAPI.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.ServiceLayer.Abstracts
{
    public interface IDoctorService
    {
        Task AddDoctorAsync(Doctor doctor);
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<List<Doctor>> GetAllDoctorsAsync();
        Task UpdateDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(int id);
        Task<List<Patient>> GetAllPatientsAsync(int doctorId);
    }
}
