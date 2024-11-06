using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UpWatch.IoC;
using UpWatch.IoC.Module;
using UpWatch.MediatR;

namespace Identity.Application;

public class ApplicationModule : Module
{
    protected override void Bootstrap(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(GetType().Assembly);
        services.AddMediatRWithFluentValidation(GetType());
    }
}
