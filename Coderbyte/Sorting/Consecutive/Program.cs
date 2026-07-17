namespace CodingPatterns.Coderbyte.Sorting.Consecutive;

// Coderbyte example plus already-consecutive and wide-gap cases.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (int[] Input, int Expected)[]
        {
            (new[] { 4, 8, 6 }, 2),   // add 5 and 7
            (new[] { 1, 2, 3 }, 0),   // already consecutive
            (new[] { 5, 10 }, 4),     // 6,7,8,9
            (new[] { 1, 1, 3 }, 1),   // duplicate 1: only 2 is missing
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            int actual = solution.Consecutive(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"Consecutive([{string.Join(",", input)}]) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
