using HastaneRandevuSistemiAPI.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HastaneRandevuSistemiAPI.Repository.Abstract;

public interface IEntityRepository<T, TKey> where T : class, new()
{
    IQueryable<T> GetAll();
    IQueryable<T> GetById(TKey id); // ID tipi generic
    Task AddAsync(T entity);
    void Delete(T entity);
    void Update(T entity);
}
