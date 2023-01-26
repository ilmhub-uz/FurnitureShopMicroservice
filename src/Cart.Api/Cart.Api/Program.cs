using Cart.Api.Middlewares;
using Cart.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddDistributedRedisCache(options =>
{
    options.Configuration = "redis";
    options.InstanceName = "cart_api";
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseErrorHandlerMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
