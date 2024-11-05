using Identity.Domain.Entities;
using Identity.Domain.Repositories;
using UpWatch.EntityFramework.Repositories;

namespace Identity.Infrastructure.Repositories;

public class UserRepository : EfRepository<AppDbContext, ApplicationUser>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
