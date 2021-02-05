using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebApplication.DataAccess.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        protected RepositoryBase(DbContext context)
        {
            Context = context;
        }
        
        public virtual async Task<TEntity> FindAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<EntityEntry<TEntity>> SaveAsync(TEntity entity)
        {
            return await Context.Set<TEntity>().AddAsync(entity);
        }

        public EntityEntry<TEntity> Update(TEntity entity)
        {
            return Context.Set<TEntity>().Update(entity);
        }

        public EntityEntry<TEntity> Remove(TEntity entity)
        {
            return Context.Set<TEntity>().Remove(entity);
        }
    }
}