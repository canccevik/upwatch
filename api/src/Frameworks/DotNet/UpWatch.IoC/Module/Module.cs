using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UpWatch.Configuration;

namespace UpWatch.IoC.Module;

public abstract class Module : IModule
{
    public void Configure(IServiceCollection services)
    {
        var configuration = ConfigurationHelper.GetConfiguration();
        Bootstrap(services, configuration);
    }

    protected abstract void Bootstrap(IServiceCollection services, IConfiguration configuration);
}
