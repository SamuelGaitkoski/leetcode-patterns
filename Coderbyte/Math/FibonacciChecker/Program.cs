namespace CodingPatterns.Coderbyte.Math.FibonacciChecker;

// Fibonacci numbers vs non-Fibonacci numbers, including the 0 and 1 base cases.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (int Input, string Expected)[]
        {
            (8, "yes"),
            (13, "yes"),
            (0, "yes"),
            (1, "yes"),
            (4, "no"),
            (6, "no"),
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.FibonacciChecker(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"FibonacciChecker({input}) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
