# Microservices

__ PM> NuGet\Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 7.0.2 __

***

```
  "JwtBearer": {
    "ValidIssuer": "furnitureshop.uz",
    "ValidAudience": "furnitureshop",
    "IssuerSigningKey": "asda;odbuads;b242342hbiahbasdada"
  }
```
***

```C#
    public class JwtTokenValidationParameters
    {
        public string? ValidIssuer { get; set; }
        public string? ValidAudience { get; set; }
        public string IssuerSigningKey { get; set; } = string.Empty;
    }
```
***

```C#
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
```

***

```C#
    builder.Services.AddSwaggerGenWithSecurityRequirement();

    builder.Services.AddJwtBearer(builder.Configuration);
    ...
    app.UseAuthentication();
```

***

```C#
    [HttpGet]
    [Authorize]
    public IActionResult Profile()
    {
        var username = User.FindFirst(ClaimTypes.Name)!.Value;
        return Ok();
    }
```