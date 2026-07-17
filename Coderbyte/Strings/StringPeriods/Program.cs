namespace CodingPatterns.Coderbyte.Strings.StringPeriods;

// Runs the Coderbyte examples plus no-period edge cases.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string Input, string Expected)[]
        {
            ("abcababcababcab", "abcab"),   // Coderbyte example (repeated 3x)
            ("abababababab", "ababab"),      // longest is "ababab", not "ab"
            ("aa", "a"),
            ("xyz", "-1"),                   // no repeating block
            ("a", "-1"),                     // single character
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.StringPeriods(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"StringPeriods(\"{input}\") = \"{actual}\" (expected \"{expected}\") {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
