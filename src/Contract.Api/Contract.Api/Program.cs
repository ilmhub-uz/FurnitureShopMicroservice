using Contract.Api.Context.Repositories;
using Contract.Api.Extensions;
using Contract.Api.Middlewares;
using Contract.Api.Services;
using Contract.Api.Services.Interface;
using JFA.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppDbContext(builder.Configuration);
builder.AddSeriologConfig();
builder.Services.AddServicesFromAttribute();
builder.Services.AddScoped<ContractRepository>();
var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseErrorHandlerMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();

//1.ContractService ichini to`ldirish                    //chala
//2.UnitTest yozish                                      //chala
//3.Dockerfile yozish                                    //chala
//4.Hub yozish 
//5.emailsender yozish
//6.validator yozish
//7.