using Microsoft.Extensions.Logging;

namespace PartialMethods;

public partial class HelloWorldService
{
    private readonly ILogger<HelloWorldService> logger;

    [LoggerMessage(0, LogLevel.Information, "Hello {Message}")]
    partial void LogHelloWorld(string message);

    public HelloWorldService(ILogger<HelloWorldService> logger) => this.logger = logger;

    public void SayHello(string message) => LogHelloWorld(message);
    public void SayHelloOld(string message) => logger.LogHelloWorldOld(message);
}
