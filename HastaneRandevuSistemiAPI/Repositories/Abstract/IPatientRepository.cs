using HastaneRandevuSistemiAPI.Models.Entities.Enums;
using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Repository.Abstract;

public interface IPatientRepository : IEntityRepository<Patient, string>
{
    Task<Patient> GetPatientbyTcAsync(string tc);
    Task<List<Patient>> GetAllPatientsByDoctorAsync(int id);
}
