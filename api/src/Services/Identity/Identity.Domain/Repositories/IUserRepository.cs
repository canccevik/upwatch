using Identity.Domain.Entities;
using UpWatch.Repositories.Repository;

namespace Identity.Domain.Repositories;

public interface IUserRepository : IRepository<ApplicationUser>
{
}
