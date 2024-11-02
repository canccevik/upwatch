using UpWatch.Repositories.Repository;
using User.Domain.Entities;

namespace User.Domain.Repositories;

public interface IUserRepository : IRepository<ApplicationUser>
{
}
