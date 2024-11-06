using Identity.Api;
using UpWatch.IoC;
using UpWatch.IoC.Module;

namespace UpWatch.Api;

public class ApiModule : Module
{
    protected override void Bootstrap(IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterModule<IdentityModule>();
    }
}
 