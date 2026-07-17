namespace CodingPatterns.Coderbyte.Strings.SimpleSymbols;

// Runs true/false cases, including a letter at the boundary.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string Input, string Expected)[]
        {
            ("+d+=3=+s+", "true"),   // every letter wrapped in '+'
            ("f++d+", "false"),      // leading 'f' has no '+' before it
            ("+d+", "true"),
            ("++dd++", "false"),     // the inner d's are adjacent, not '+'-wrapped
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.SimpleSymbols(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"SimpleSymbols(\"{input}\") = \"{actual}\" (expected \"{expected}\") {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
