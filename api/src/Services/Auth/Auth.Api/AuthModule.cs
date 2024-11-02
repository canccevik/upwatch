using Auth.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UpWatch.IoC;
using UpWatch.IoC.Module;

namespace Auth.Api;

public class AuthModule : Module
{
    protected override void Bootstrap(IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterModule<ApplicationModule>();
    }
}
