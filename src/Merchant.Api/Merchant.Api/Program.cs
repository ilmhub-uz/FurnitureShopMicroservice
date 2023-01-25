using Merchant.Api.Configurations;
using JFA.DependencyInjection;
using Merchant.Api.Data;
using Merchant.Api.Extensions;
using Merchant.Api.Middleware;
using Merchant.Api.RabbitMQServices;
using Merchant.Api.Repositories;
using Merchant.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var rabbitMqConfig = builder.Configuration
    .GetSection("RabbitMqConfigurations")
    .Get<RabbitMqConfigurations>();

builder.Services.AddAppDbContext(builder.Configuration);
builder.Services.AddSingleton(rabbitMqConfig);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGenWithSecurityRequirement();

builder.Services.AddServicesFromAttribute();
builder.Services.AddJwtBearer(builder.Configuration);
builder.Services.AddServices();

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