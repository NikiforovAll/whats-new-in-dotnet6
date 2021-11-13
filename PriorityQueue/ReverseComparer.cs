namespace Comparers;

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