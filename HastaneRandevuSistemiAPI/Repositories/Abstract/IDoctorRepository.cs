using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Models.Entities.Enums;
using HastaneRandevuSistemiAPI.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.Repositories.Abstract
{
    public interface IDoctorRepository : IEntityRepository<Doctor, int>
    {
        Task<Doctor> GetByBranchAsync(Branch branch);
        Task<List<Doctor>> GetAllDoctorsWithAppointmentsAsync();
        Task<List<Doctor>> GetDoctorsByRoleAsync(DRole role);

    }
}
