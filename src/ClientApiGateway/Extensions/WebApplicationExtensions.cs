using ClientApiGateway.Options;

namespace ClientApiGateway.Extensions;

public static class WebApplicationExtensions
{
    public static void UseSwaggerUIWithOcelot(this WebApplication app, IConfiguration configuration)
    {
        app.UseSwaggerUI(c =>
        {
            var endPoints = configuration.GetSection(
                    SwaggerEndPointOptions.ConfigurationSectionName
                )
                .Get<IEnumerable<SwaggerEndPointOptions>>();

            if (endPoints is null)
            {
                throw new InvalidOperationException(
                    $"{SwaggerEndPointOptions.ConfigurationSectionName} configuration section is missing or empty."
                );
            }
            foreach (var endPoint in endPoints)
            {
                foreach (var config in endPoint.Config!)
                {
                    c.SwaggerEndpoint($"{config.Url}", $"{config.Name} - {config.Version}");
                    c.RoutePrefix = "swagger";
                }
            }
        });
    }
}