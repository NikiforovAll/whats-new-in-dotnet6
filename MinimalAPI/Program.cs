var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();
app
    .UseSwagger()
    .UseSwaggerUI();

app.MapGet("ka/{pow}", (int pow) => IsPow2(pow));

app.Run();
