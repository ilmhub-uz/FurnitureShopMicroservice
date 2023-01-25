using Merchant.Api.Configurations;
using JFA.DependencyInjection;
using Merchant.Api.Data;
using Merchant.Api.Extensions;
using Merchant.Api.Middleware;
using Merchant.Api.Repositories;
using Merchant.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var rabbitMqConfig = builder.Configuration
    .GetSection("RabbitMqConfigurations")
    .Get<RabbitMqConfigurations>();

builder.Services.AddSingleton(rabbitMqConfig);

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IFileHelper, FileHelper>();
builder.Services.AddHostedService<ProductAddService>();

builder.Services.AddSwaggerGenWithSecurityRequirement();

builder.Services.AddServicesFromAttribute();
builder.Services.AddJwtBearer(builder.Configuration);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseErrorHandlerMiddleware();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
