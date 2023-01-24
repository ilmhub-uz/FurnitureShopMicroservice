using Product.Api.RabbitMq;
using Product.Api.Repositories;
using Product.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
