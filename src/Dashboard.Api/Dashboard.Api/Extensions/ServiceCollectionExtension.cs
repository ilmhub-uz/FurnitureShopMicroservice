using Dashboard.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Api.Extensions;

public static class ServiceCollectionExtension
{

    public static void AddDbContext(this IServiceCollection collection, ConfigurationManager configuration)
    {
        collection.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("localhost")).UseLazyLoadingProxies();
        });
    }


    public static void AddCorsPolicy(this IServiceCollection collection)
    {
        collection.AddCors(c =>
        {
            c.AddDefaultPolicy(cors =>
            {
                cors.WithOrigins("")// domain qoshish
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
            });

        });
    }
}
