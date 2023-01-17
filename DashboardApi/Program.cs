using DashboardApi.Data;
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


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var context = app.Services.GetRequiredService<AppDbContext>();
context.Database.Migrate();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
