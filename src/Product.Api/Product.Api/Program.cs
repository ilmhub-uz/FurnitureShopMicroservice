using FluentValidation.AspNetCore;
using FluentValidation;
using Product.Api.RabbitMq;
using Product.Api.Repositories;
using Product.Api.Services;
using System.Reflection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var logger  = new LoggerConfiguration()
	.WriteTo.Console()
	.WriteTo.File(path: "ProductApi.log", rollingInterval: RollingInterval.Year,
		outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
	.CreateLogger();

builder.Services.AddFluentValidationAutoValidation(options =>
{
    options.DisableDataAnnotationsValidation = false;
});

builder.Services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Program)));

IConfigurationSection appsettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appsettingsSection);
builder.Services.AddSingleton<SendToGetMessage>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
