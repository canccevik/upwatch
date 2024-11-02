using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UpWatch.IoC.Module;
using UpWatch.MediatR;

namespace Auth.Application;

public class ApplicationModule : Module
{
    protected override void Bootstrap(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatRWithFluentValidation(GetType());
    }
}
