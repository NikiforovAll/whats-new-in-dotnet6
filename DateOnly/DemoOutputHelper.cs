global using static DemoOutputHelpers.DemoOutputHelper;

using static System.Console;

using System.Runtime.CompilerServices;

namespace DemoOutputHelpers;

public static class DemoOutputHelper
{
    public static void Write(
        object obj,
        [CallerArgumentExpression("obj")] string? expr = default) =>
            WriteLine($"{expr} is {obj}");
}
