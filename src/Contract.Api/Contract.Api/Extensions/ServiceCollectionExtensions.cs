using Contract.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Contract.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppDbContext(this IServiceCollection collection, ConfigurationManager configuration)
        {
            collection.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("localhost")).UseLazyLoadingProxies();

            });
        }
    }
}
