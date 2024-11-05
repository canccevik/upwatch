using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure;

public class AppDbContext  : IdentityDbContext<ApplicationUser, Role, Guid>
{
    public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
