using System.Runtime.CompilerServices;

namespace FileScopedNamespaces
{
    public class ExpressionPrinter
    {
        public static void Print(
            bool result, [CallerArgumentExpression("result")] string? expr = default)
        {
            WriteLine($"({expr}) is {result}");
        }
    }
}
