using FluentValidation.AspNetCore;
using FluentValidation;
using System.Reflection;

namespace Contract.Api.Extensions;

public static class AutoDtoValidationExtensions
{
    public static void AddAutoDtoValidation (this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Program)));
        services.AddFluentValidationAutoValidation(options =>
        {
            options.DisableDataAnnotationsValidation = true;
        });
    }
}
