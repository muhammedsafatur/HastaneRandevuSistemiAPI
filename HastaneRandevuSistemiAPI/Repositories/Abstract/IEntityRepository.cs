namespace HastaneRandevuSistemiAPI.Repository.Abstract
{
    public interface IEntityRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetById(string id);
        Task AddAsync(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
