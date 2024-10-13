using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Models.Entities.Enums;
using HastaneRandevuSistemiAPI.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.ServiceLayer.Abstracts
{
    public interface IDoctorService: IEntityService<Doctor,int>
    {

        Task<Doctor> GetByBranchAsync(Branch branch);
        Task<List<Doctor>> GetAllDoctorsWithAppointmentsAsync();
        Task<List<Doctor>> GetDoctorsByRoleAsync(DRole role);
    }
}
