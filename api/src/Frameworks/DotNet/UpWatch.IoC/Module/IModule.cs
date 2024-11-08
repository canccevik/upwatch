using Microsoft.Extensions.DependencyInjection;

namespace UpWatch.IoC.Module;

public interface IModule
{
    void Configure(IServiceCollection services);
}
