using Microsoft.Extensions.DependencyInjection;

namespace UpWatch.IoC.Module;

public abstract class Module : IModule
{
    public void Configure(IServiceCollection services)
    {
        Bootstrap(services);
    }

    protected abstract void Bootstrap(IServiceCollection services);
}
