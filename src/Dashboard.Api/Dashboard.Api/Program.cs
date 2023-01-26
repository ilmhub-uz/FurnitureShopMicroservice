using Dashboard.Api.Extensions;
using Dashboard.Api.Helpers;
using Dashboard.Api.Middleware;
using Dashboard.Api.RabbitMQ;
using JFA.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServicesFromAttribute();
builder.Services.AddHttpContextAccessor();
//builder.Services.AddHostedService<ProductConsumer>();

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddCorsPolicy();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Services.GetServices<IHttpContextAccessor>() is not null)
    HttpContextHelper.Accessor = app.Services.GetService<IHttpContextAccessor>();

app.UseCors();

app.UseErrorHandlerMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
