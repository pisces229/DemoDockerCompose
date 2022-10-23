using DemoDockerCompose.Service;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Logging
    .SetMinimumLevel(LogLevel.Information)
    .AddConsole();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "redis,defaultDatabase=0";
});

builder.Services.AddScoped<RedisService>();

builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.IncludeFields = true;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

var app = builder.Build();

const string APP_KEY = "Second";

app.MapGet("/", async ([FromServices] RedisService service) =>
{
    app.Logger.LogInformation($"[{APP_KEY}]");
    return await Task.FromResult($"[{APP_KEY}]");
});

app.MapGet("/Set", async ([FromServices] RedisService service) =>
{
    var value = Guid.NewGuid().ToString();
    await service.Set(APP_KEY, value);
    app.Logger.LogInformation($"[{APP_KEY}] [{value}]!");
});

app.MapGet("/Get", async ([FromServices] RedisService service) =>
{
    var value = await service.Get(APP_KEY);
    app.Logger.LogInformation($"[{APP_KEY}] [{value}]!");
});

app.Run();