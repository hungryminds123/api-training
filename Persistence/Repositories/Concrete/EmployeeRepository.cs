using Domain;
using Persistence.Repositories.Interface;

namespace Persistence.Repositories.Concrete
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EFLearningContext dbContext) : base(dbContext)
        {

        }
    }
}
