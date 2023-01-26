using JFA.DependencyInjection;
using Merchant.Api.Configurations;
using Merchant.Api.Extensions;
using Merchant.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("RabbitMq.json", false, true);

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