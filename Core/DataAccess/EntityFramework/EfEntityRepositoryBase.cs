using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IReadOnlyEntityRepository<TEntity>, ICRUDEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public async Task AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }
        public void AddRange(params TEntity[] entities)
        {
            using (var context = new TContext())
            {
                foreach (var entity in entities)
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Added;
                }
                context.SaveChanges();
            }
        }
        public async Task AddRangeAsync(params TEntity[] entities)
        {
            using (var context = new TContext())
            {
                foreach (var entity in entities)
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Added;
                }
                await context.SaveChangesAsync();
            }
        }


        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public async Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }
        public void DeleteRange(params TEntity[] entities)
        {
            using (var context = new TContext())
            {
                foreach (var entity in entities)
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }
        public async Task DeleteRangeAsync(params TEntity[] entities)
        {
            using (var context = new TContext())
            {
                foreach (var entity in entities)
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Deleted;
                }
                await context.SaveChangesAsync();
            }
        }


        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public async Task UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
        public void UpdateRange(params TEntity[] entities)
        {
            using (var context = new TContext())
            {
                foreach (var entity in entities)
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }
        public async Task UpdateRangeAsync(params TEntity[] entities)
        {
            using (var context = new TContext())
            {
                foreach (var entity in entities)
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Modified;
                }
                await context.SaveChangesAsync();
            }
        }


        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            using (var context = new TContext())
            {
                var query = context.Set<TEntity>().Where(filter);
                return includes.Aggregate(query, (current, includeProperty)=> current.Include(includeProperty)).SingleOrDefault();
            }
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            using (var context = new TContext())
            {
                var query = context.Set<TEntity>().Where(filter);
                return await includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).SingleOrDefaultAsync();
            }
        }


        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            using (var context = new TContext())
            {
                var query = filter == null ? context.Set<TEntity>() :
                                        context.Set<TEntity>().Where(filter);
                return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
            }
        }
        public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            using (var context = new TContext())
            {
                var query = filter == null ? context.Set<TEntity>() :
                                          context.Set<TEntity>().Where(filter);
                return await includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToListAsync();
            }
        }
    }

}
