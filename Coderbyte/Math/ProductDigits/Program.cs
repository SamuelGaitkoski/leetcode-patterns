namespace CodingPatterns.Coderbyte.Math.ProductDigits;

// Coderbyte examples and sample test cases.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (int Input, int Expected)[]
        {
            (24, 2),   // 8 * 3
            (90, 3),   // 10 * 9
            (6, 2),    // 2 * 3
            (23, 3),   // prime: 1 * 23
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            int actual = solution.ProductDigits(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"ProductDigits({input}) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
