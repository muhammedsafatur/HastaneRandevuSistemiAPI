using System.Linq;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.Repository.Abstract
{
    public interface IEntityRepository<TEntity, TId>
    {
        Task<TEntity> GetByIdAsync(TId id);
        Task<List<TEntity>> GetAllAsync(); // Bu metodu ekleyin
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TId id, TEntity entity);
        Task DeleteAsync(TId id );
    }

}
