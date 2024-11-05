using Identity.Domain.Entities;
using Identity.Domain.Repositories;
using Identity.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UpWatch.IoC.Module;

namespace Identity.Infrastructure;

public class InfrastructureModule : Module
{
    protected override void Bootstrap(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services
            .AddIdentity<ApplicationUser, Role>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddUserStore<UserStore<ApplicationUser, Role, AppDbContext, Guid>>()
            .AddRoleStore<RoleStore<Role, AppDbContext, Guid>>();

        services.AddTransient<IUserRepository, UserRepository>();
    }
}
