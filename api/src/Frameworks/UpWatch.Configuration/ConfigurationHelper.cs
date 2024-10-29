using Microsoft.Extensions.Configuration;

namespace UpWatch.Configuration;

public static class ConfigurationHelper
{
    public static IConfiguration GetConfiguration()
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: false)
            .AddEnvironmentVariables();

        return builder.Build();
    }
}
