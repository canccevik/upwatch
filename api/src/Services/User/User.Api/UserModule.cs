using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UpWatch.IoC;
using UpWatch.IoC.Module;
using User.Infrastructure;

namespace User.Api;

public class UserModule : Module
{
    protected override void Bootstrap(IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterModule<InfrastructureModule>();
    }
}
