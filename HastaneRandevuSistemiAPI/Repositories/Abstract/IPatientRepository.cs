using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Models.Entities.Enums;
using HastaneRandevuSistemiAPI.Repository.Abstract;

namespace HastaneRandevuSistemiAPI.Repositories.Abstract;

public interface IPatientRepository:IEntityRepository<Patient,string>
{
    Patient GetPatientbyTc(string tc);
    List<Patient> GetAllPatientsByDoctor(int id);
    List<Patient>GetAllPatientsByDocBranch(Branch branch);
}
