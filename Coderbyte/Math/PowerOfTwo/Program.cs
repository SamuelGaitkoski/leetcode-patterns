namespace CodingPatterns.Coderbyte.Math.PowerOfTwo;

// Powers of two vs non-powers, including the 0 and 1 edge cases.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (int Input, string Expected)[]
        {
            (8, "true"),
            (16, "true"),
            (1, "true"),   // 2^0
            (6, "false"),
            (3, "false"),
            (0, "false"),
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.PowersofTwo(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"PowersofTwo({input}) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
