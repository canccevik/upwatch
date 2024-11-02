using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UpWatch.IoC.Module;
using User.Domain.Entities;
using User.Domain.Repositories;
using User.Infrastructure.Repositories;

namespace User.Infrastructure;

public class InfrastructureModule : Module
{
    protected override void Bootstrap(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UserDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services
            .AddIdentity<ApplicationUser, Role>()
            .AddEntityFrameworkStores<UserDbContext>()
            .AddDefaultTokenProviders()
            .AddUserStore<UserStore<ApplicationUser, Role, UserDbContext, Guid>>()
            .AddRoleStore<RoleStore<Role, UserDbContext, Guid>>();

        services.AddTransient<IUserRepository, UserRepository>();
    }
}
