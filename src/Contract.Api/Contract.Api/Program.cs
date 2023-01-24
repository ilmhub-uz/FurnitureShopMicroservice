using Contract.Api.Extensions;

using Contract.Api.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAppDbContext(builder.Configuration);
builder.AddSeriologConfig();

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("localhost"));
});

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
