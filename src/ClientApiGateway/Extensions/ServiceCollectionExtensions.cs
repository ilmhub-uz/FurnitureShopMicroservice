using Ocelot.DependencyInjection;

namespace ClientApiGateway.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddOcelotWithJsonConfig(this IServiceCollection services, ConfigurationManager configuration)
    {
        configuration.AddJsonFile("ocelot.json", false, true);
        services.AddOcelot(configuration);
    }
}