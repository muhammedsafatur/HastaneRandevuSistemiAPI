
using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Repository.Abstract;

namespace HastaneRandevuSistemiAPI.DataAccesLayer.Concrete;

public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase<T,string>
{
    public Task AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
