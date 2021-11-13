using static System.Console;

await Parallel.ForEachAsync(Generate(), Handle)
    .WaitAsync(TimeSpan.FromSeconds(2))
    .ContinueWith(Report);

static async IAsyncEnumerable<int> Generate()
{
    while (true)
    {
        var delay = Random.Shared.Next(100);
        Console.ForegroundColor = ConsoleColor.Yellow;
        WriteLine($"Issued {delay}");
        ResetColor();
        await Task.Delay(delay);
        yield return delay;
    }
}

static async ValueTask Handle(int i, CancellationToken ct)
{
    await Task.Delay(i, ct);
    Console.ForegroundColor = ConsoleColor.Green;
    WriteLine($"Handled {i}");
    ResetColor();
}

static void Report(Task t) => WriteLine(
    $"Finished at: {DateTime.Now:T}, task.Status {t.Status}");
