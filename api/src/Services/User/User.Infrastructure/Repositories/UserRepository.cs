using UpWatch.EntityFramework.Repositories;
using User.Domain.Entities;
using User.Domain.Repositories;

namespace User.Infrastructure.Repositories;

public class UserRepository : EfRepository<UserDbContext, ApplicationUser>, IUserRepository
{
    public UserRepository(UserDbContext dbContext) : base(dbContext)
    {
    }
}
