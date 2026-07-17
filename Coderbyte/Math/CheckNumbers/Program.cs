namespace CodingPatterns.Coderbyte.Math.CheckNumbers;

// Covers all three comparison outcomes.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (int A, int B, string Expected)[]
        {
            (4, 5, "true"),    // 5 > 4
            (5, 4, "false"),   // 4 < 5
            (3, 3, "-1"),      // equal
        };

        bool allPassed = true;
        foreach (var (a, b, expected) in cases)
        {
            string actual = solution.CheckNumber(a, b);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"CheckNumber({a}, {b}) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
