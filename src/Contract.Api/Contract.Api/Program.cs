using Contract.Api.Context.Repositories;
using Contract.Api.Extensions;
using Contract.Api.Middlewares;
using Contract.Api.Services;
using JFA.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppDbContext(builder.Configuration);
builder.AddSeriologConfig();
builder.Services.AddServicesFromAttribute();

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

//1.ContractService cihini to`ldirish
//2.UnitTest yoizsh
//3.Dockerfile yozish
//4.Hub yozish
//5.emailsender yozish
//6.validator yozish
//7.