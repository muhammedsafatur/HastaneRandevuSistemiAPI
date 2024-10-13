using HastaneRandevuSistemiAPI.Models.Entities.Enums;
using HastaneRandevuSistemiAPI.Repository.Abstract;
using Umbraco.Core.Persistence.Repositories;

namespace HastaneRandevuSistemiAPI.Repositories.Abstract;

public interface IBranchRepository : IEntityRepository<Branch,Branch>
{
    Branch GetAllAppointmentsbyBranch(Branch Branch);
}
