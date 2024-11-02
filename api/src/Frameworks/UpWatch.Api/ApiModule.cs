using UpWatch.IoC;
using UpWatch.IoC.Module;
using User.Api;

namespace UpWatch.Api;

public class ApiModule : Module
{
    protected override void Bootstrap(IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterModule<UserModule>();
    }
}
