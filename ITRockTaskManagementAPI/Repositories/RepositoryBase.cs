using ITRockTaskManagementAPI.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ITRockTaskManagementAPI.Repositories
{
    public abstract class RepositoryBase<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext
    {
        protected readonly TContext DbContext;

        protected RepositoryBase(TContext dbContext)
        {
            DbContext = dbContext;
        }

        protected abstract DbSet<T> DbSet { get; }

        public async Task<T> AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity != null)
            {
                DbSet.Remove(entity);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }
    }
}
