using Microsoft.Extensions.Logging;

namespace PartialMethods;

public static class LoggerExtensions
{
    private static readonly Action<ILogger, string, Exception?> logHelloWorld =
        LoggerMessage.Define<string>(
            logLevel: LogLevel.Information,
            eventId: 0,
            formatString: "Hello {Message}");

    public static void LogHelloWorldOld(this ILogger logger, string message) =>
        logHelloWorld(logger, message, default!);
}
