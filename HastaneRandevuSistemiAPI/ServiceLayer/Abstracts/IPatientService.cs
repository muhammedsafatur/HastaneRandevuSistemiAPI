using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.ServiceLayer.Abstracts
{
    public interface IPatientService:IEntityService<Patient,string>
    {
        Task<Patient> GetPatientByTcAsync(string tc);
        Task<List<Patient>> GetAllPatientsByDoctorAsync(int doctorId);
    }
}
