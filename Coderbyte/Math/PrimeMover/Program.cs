namespace CodingPatterns.Coderbyte.Math.PrimeMover;

// A few known prime positions.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (int Input, int Expected)[]
        {
            (1, 2),
            (5, 11),
            (6, 13),
            (10, 29),
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            int actual = solution.PrimeMover(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"PrimeMover({input}) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
