using System.Runtime.CompilerServices;

namespace FileScopedNamespaces
{
    public class TestFramework
    {
        public static void Print(bool result, [CallerArgumentExpression("result")] string? expr = default)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine($"({expr}) is {result}");
            ResetColor();
        }

        public static void Assert(bool condition, [CallerArgumentExpression("condition")]
            string? conditionExpression = default)
        {
            if (!condition)
                throw new Exception($"Condition failed: {conditionExpression}");

            Print(condition, conditionExpression);
        }
    }
}
