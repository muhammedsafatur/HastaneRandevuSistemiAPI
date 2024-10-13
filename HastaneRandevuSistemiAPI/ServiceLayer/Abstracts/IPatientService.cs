using HastaneRandevuSistemiAPI.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.ServiceLayer.Abstracts
{
    public interface IPatientService
    {
        Task AddPatientAsync(Patient patient);
        Task<Patient> GetPatientByIdAsync(string id);
        Task<List<Patient>> GetAllPatientsAsync();
        Task UpdatePatientAsync(Patient patient);
        Task DeletePatientAsync(string id);
        Task<Patient> GetPatientByTcAsync(string tc);
        Task<List<Patient>> GetAllPatientsByDoctorAsync(int doctorId);
    }
}
