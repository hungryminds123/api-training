using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interface;

namespace Persistence.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EFLearningContext _dbContext;

        public GenericRepository(EFLearningContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Task<T> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
