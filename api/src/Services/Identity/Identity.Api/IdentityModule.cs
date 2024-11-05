using Identity.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UpWatch.IoC;
using UpWatch.IoC.Module;

namespace Identity.Api;

public class IdentityModule : Module
{
    protected override void Bootstrap(IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterModule<InfrastructureModule>();
    }
}
