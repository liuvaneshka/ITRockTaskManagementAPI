using System.Linq.Expressions;

namespace ITRockTaskManagementAPI.RepositoryContracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
