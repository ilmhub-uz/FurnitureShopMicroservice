namespace Contract.Api.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddLogger (this IServiceCollection services)
    {
        services.AddCors(option =>
        {
            option.AddPolicy("base",options =>
            {
                options.AllowAnyHeader().AllowAnyOrigin();
            });
        });
    }
}