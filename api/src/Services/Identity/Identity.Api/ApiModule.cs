using Identity.Application;
using Identity.Infrastructure;
using UpWatch.IoC;
using UpWatch.IoC.Module;

namespace Identity.Api;

public class ApiModule : Module
{
    protected override void Bootstrap(IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterModule<ApplicationModule>();
        services.RegisterModule<InfrastructureModule>();
    }
}
