namespace CodingPatterns.Coderbyte.SlidingWindow.MinimumWindowSubstring;

// Coderbyte examples.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string[] Input, string Expected)[]
        {
            (new[] { "aaabaaddae", "aed" }, "dae"),
            (new[] { "aabdccdbcacd", "aad" }, "aabd"),
            (new[] { "ahffaksfajeeubsne", "jefaa" }, "aksfaje"),
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.MinWindowSubstring(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"MinWindowSubstring([\"{input[0]}\", \"{input[1]}\"]) = \"{actual}\" (expected \"{expected}\") {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
