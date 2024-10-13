using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Repository.Abstract;

namespace HastaneRandevuSistemiAPI.Repositories.Abstract
{
    public interface IDoctorRepository:IEntityRepository<Doctor,int>
    {
        List<Patient> GetAllPatients(int doctorId);
        Task UpdateAsync(Doctor entity);
    }
}
