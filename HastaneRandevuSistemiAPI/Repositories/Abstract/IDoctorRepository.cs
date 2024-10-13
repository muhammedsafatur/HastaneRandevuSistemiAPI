using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Repository.Abstract;

namespace HastaneRandevuSistemiAPI.Repositories.Abstract
{
    public interface IDoctorRepository:IEntityRepository<Doctor,int>
    {
        Doctor GetAllPatients();
       
    }
}
