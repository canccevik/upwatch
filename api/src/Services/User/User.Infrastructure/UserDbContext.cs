using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;

namespace User.Infrastructure;

public class UserDbContext : IdentityDbContext<ApplicationUser, Role, Guid>
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }
}
