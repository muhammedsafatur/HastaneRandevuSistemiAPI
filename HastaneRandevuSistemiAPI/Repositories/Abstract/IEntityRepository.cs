using HastaneRandevuSistemiAPI.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HastaneRandevuSistemiAPI.Repository.Abstract;

public interface IEntityRepository<T, TKey> where T : class, new()
{
    IQueryable<T> GetAll();
    Task<T> GetByIdAsync(TKey id);
    Task AddAsync(T entity);
    Task DeleteAsync(T entity);
}