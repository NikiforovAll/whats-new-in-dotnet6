using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PartialMethods;

var services = new ServiceCollection();

services.AddLogging(cfg => cfg.AddConsole());
services.AddSingleton<HelloWorldService>();

var provider = services.BuildServiceProvider();

var hw = provider.GetRequiredService<HelloWorldService>();

hw.SayHelloOld("Old Style");

// https://andrewlock.net/exploring-dotnet-6-part-8-improving-logging-performance-with-source-generators/
hw.SayHello("New Style");

Console.ReadKey();
