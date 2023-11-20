using System.Linq.Expressions;

namespace Persistence.Repositories.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();  
        Task<T> Add(T entity);
        Task Update(T entity);  
        Task Delete(T entity);
        Task<T> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate);


    }
}
