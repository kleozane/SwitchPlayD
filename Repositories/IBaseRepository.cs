using System.Linq.Expressions;

namespace SwitchPlayD.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        void Add(TEntity entity);
        void SaveChanges();
        IQueryable<TEntity> AsQueryable();
        IEnumerable<TEntity> GetAll();
        Task Create(TEntity entity);
        void Update(TEntity entity);
        Task Delete(int id);
        List<TEntity> Find(Func<TEntity, bool> filter);
        void Remove(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(int id);
        Task SaveChangesAsync();
    }
}
