namespace CodingPatterns.Coderbyte.Math.FirstFactorial;

// Small cases plus the upper bound 18! (which overflows a 32-bit int).
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (int Input, long Expected)[]
        {
            (4, 24),
            (1, 1),
            (0, 1),
            (5, 120),
            (18, 6402373705728000),
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            long actual = solution.FirstFactorial(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"FirstFactorial({input}) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
