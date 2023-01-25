using Merchant.Api.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Merchant.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddJwtBearer(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection("JwtBearer");
        services.Configure<JwtTokenValidationParameters>(section);

        var jwtOptions = section.Get<JwtTokenValidationParameters>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(jwtoption =>
            {
                jwtoption.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.ValidIssuer,
                    ValidateAudience = true,
                    ValidAudience = jwtOptions.ValidAudience,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtOptions.IssuerSigningKey!))
                };
            });
    }

    public static void AddSwaggerGenWithSecurityRequirement(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "FurnitureShop.Identity.Api",
                Version = "v1",
                Description = "API for Identity",
                TermsOfService = new Uri("https://furnitures.uz"),
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description = "JWT Bearer. : \"Authorization: Bearer { token }\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
    }
}