using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();
app
    .UseSwagger()
    .UseSwaggerUI();

app.MapGet("ka/{pow}", (int pow) => IsPow2(pow))
    .WithName("IsPowOfTwo")
    .Produces<bool>(StatusCodes.Status200OK)
    .WithTags("Examples");

// [new] Explicit return type in lambdas
// [new] Lambdas with attributes
// [new] improved type inference
var lambda = string ([NotNull] string arg) => arg;

app.MapGet("example/{arg}", lambda)
    .ExcludeFromDescription();

app.Run();
