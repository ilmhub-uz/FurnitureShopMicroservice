using Contract.Api.Context.Repositories;
using Contract.Api.Entities;
using Contract.Api.Extensions;
using Contract.Api.Middlewares;
using Contract.Api.RabbitMq;
using JFA.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<EmailBody>(builder.Configuration.GetSection("EmailBody"));
builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration"));

builder.Services.AddAppDbContext(builder.Configuration);
builder.Services.AddServicesFromAttribute();
builder.Services.AddAutoDtoValidation();
builder.Services.AddSingleton<SendToGetMessage>();
builder.AddSeriologConfig();

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