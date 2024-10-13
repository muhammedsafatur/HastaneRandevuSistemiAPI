using HastaneRandevuSistemiAPI.Contexts;
using HastaneRandevuSistemiAPI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.DataAccesLayer.Concrete
{
    public class EntityRepository<T, TKey> : IEntityRepository<T, TKey> where T : class, new()
    {
        private readonly HospitalDbContext _context;

        public EntityRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TKey id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(TKey id, T entity)
        {
            var existingEntity = await GetByIdAsync(id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
