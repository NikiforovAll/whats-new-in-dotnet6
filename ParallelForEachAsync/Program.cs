using static System.Console;

await Parallel.ForEachAsync(Generate(), Handle)
    .WaitAsync(TimeSpan.FromMilliseconds(200))
    .ContinueWith(Report);

static async IAsyncEnumerable<int> Generate()
{
    while (true)
    {
        var delay = Random.Shared.Next(100);
        WriteLine($"Issued {delay}");
        await Task.Delay(delay);
        yield return delay;
    }
}

static async ValueTask Handle(int i, CancellationToken ct)
{
    await Task.Delay(i, ct);
    WriteLine($"Handled {i}");
}

static void Report(Task t) => WriteLine(
    $"Finished at: {DateTime.Now:T}, task.Status {t.Status}");
