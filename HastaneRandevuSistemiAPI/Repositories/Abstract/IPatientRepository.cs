using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Models.Entities.Enums;
using HastaneRandevuSistemiAPI.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPatientRepository : IEntityRepository<Patient, string>
{
    Task<Patient> GetPatientByTcAsync(string tc);
    Task<List<Patient>> GetAllPatientsByDoctorAsync(int id);
    Task<List<Patient>> GetPatientsByBranchAsync(Branch branch);
    Task<List<Patient>> GetPatientsByDateRangeAsync(DateTime startDate, DateTime endDate);


}
