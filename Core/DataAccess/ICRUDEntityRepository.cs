using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface ICRUDEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);

        void AddRange(params TEntity[] entity);
        void UpdateRange(params TEntity[] entity);
        void DeleteRange(params TEntity[] entity);

        Task AddRangeAsync(params TEntity[] entity);
        Task UpdateRangeAsync(params TEntity[] entity);
        Task DeleteRangeAsync(params TEntity[] entity);
    }
}
