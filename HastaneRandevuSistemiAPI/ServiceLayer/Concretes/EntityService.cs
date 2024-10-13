using HastaneRandevuSistemiAPI.Repositories.Abstract;
using HastaneRandevuSistemiAPI.Repository.Abstract;
using HastaneRandevuSistemiAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.Services.Concrete
{
    public class EntityService<T, TKey> : IEntityService<T, TKey> where T : class, new()
    {
        private readonly IEntityRepository<T, TKey> _repository;

        public EntityService(IEntityRepository<T, TKey> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await _repository.DeleteAsync((entity as dynamic).Id); // ID'nin dinamik olarak alındığı varsayımı
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync((entity as dynamic).Id, entity); // ID'nin dinamik olarak alındığı varsayımı
        }
    }
}
