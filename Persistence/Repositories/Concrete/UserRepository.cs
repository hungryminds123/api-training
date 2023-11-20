using Domain;
using Persistence.Repositories.Interface;

namespace Persistence.Repositories.Concrete;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(EFLearningContext dbContext) : base(dbContext)
    {

    }
}