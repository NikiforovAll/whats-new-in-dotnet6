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

public sealed class ReverseComparer<T> : IComparer<T>
{
    public static readonly ReverseComparer<T> Default = new(Comparer<T>.Default);

    public static ReverseComparer<T> Reverse(IComparer<T> comparer) =>
        new ReverseComparer<T>(comparer);

    private readonly IComparer<T> comparer = Default;

    private ReverseComparer(IComparer<T> comparer) =>
        this.comparer = comparer;

    public int Compare(T? x, T? y) => comparer.Compare(y, x);
}

public static class ProduceNumericEnumeratorExtensions
{
    public static IEnumerator<int> GetEnumerator(this int number)
    {
        for (var i = 0; i < number; i++)
        {
            yield return i;
        }
    }
}
