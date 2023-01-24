using ClientApiGateway.Extensions;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelotWithJsonConfig(builder.Configuration);

var conf = builder.Configuration;

var app = builder.Build();

app.UseSwaggerUIWithOcelot(conf);

app.UseHttpsRedirection();

await app.UseOcelot();

app.Run();