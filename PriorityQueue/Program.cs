using Comparers;
using static System.Console;

var queue = new PriorityQueue<Job, int>(ReverseComparer<int>.Default);

foreach (var i in 10)
{
    var p = Random.Shared.Next(100);
    queue.Enqueue(new($"Job{i}", p), p);
}

using var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(500));

while (await timer.WaitForNextTickAsync())
{
    if (!queue.TryDequeue(out var job, out _))
        break;

    WriteLine(job);
}

public record struct Job(string Name, int Priority);

public static class ProduceNumericEnumeratorExtensions
{
    // C# 9 feature
    public static IEnumerator<int> GetEnumerator(this int number)
    {
        for (var i = 0; i < number; i++)
        {
            yield return i;
        }
    }
}
