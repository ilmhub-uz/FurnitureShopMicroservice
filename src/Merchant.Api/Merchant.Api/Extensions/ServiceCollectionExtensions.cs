using Merchant.Api.Data;
using Merchant.Api.RabbitMQServices;
using Merchant.Api.Repositories;
using Merchant.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Merchant.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAppDbContext(this IServiceCollection collection, ConfigurationManager configuration)
    {
        collection.AddDbContext<AppDbContext>(options =>
        {
            options.UseLazyLoadingProxies().UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
    }

    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddScoped<IOrganizationService, OrganizationService>();
        collection.AddScoped<IOrganizationRepository, OrganizationRepository>();
        collection.AddScoped<IEmployeeRepository, EmployeeRepository>();
        collection.AddScoped<IEmployeeService, EmployeeService>();
        collection.AddScoped<IFileHelper, FileHelper>();
        collection.AddHostedService<ProductAddService>();
    }
}
