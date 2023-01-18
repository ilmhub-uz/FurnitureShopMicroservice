using DashboardApi.Data;
using DashboardApi.Hubs;
using DashboardApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<ProductService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql("Host=dashboardapi_db;Port=5432;Username=postgres;Password=password;database=postgres");
});

builder.Services.AddCors(cors =>
{
    cors.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

builder.Services.AddSignalR();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var context = app.Services.GetRequiredService<AppDbContext>();
context.Database.Migrate();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.MapHub<ProductsHub>("products-hub");

app.Run();
