
using HastaneRandevuSistemiAPI.Models.Entities.Enums;
using HastaneRandevuSistemiAPI.Repositories.Abstract;

namespace HastaneRandevuSistemiAPI.Repositories.Concretes;

public class BranchRepository : IBranchRepository
{
    public Task AddAsync(Branch entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Branch entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Branch> GetAll()
    {
        throw new NotImplementedException();
    }

    public Branch GetAllAppointmentsbyBranch()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Branch> GetById(Branch id)
    {
        throw new NotImplementedException();
    }

    public void Update(Branch entity)
    {
        throw new NotImplementedException();
    }
}