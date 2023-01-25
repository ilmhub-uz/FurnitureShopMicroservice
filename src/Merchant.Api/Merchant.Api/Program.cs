using Merchant.Api.Data;
using Merchant.Api.Middleware;
using Merchant.Api.Repositories;
using Merchant.Api.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<IFileHelper, FileHelper>();
builder.Services.AddHostedService<ProductAddService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
