namespace Persistence.Repositories.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        IEnumerable<T> GetAll();  
        Task<T> Add(T entity);
        Task Update(T entity);  
        Task Delete(T entity);

    }
}
