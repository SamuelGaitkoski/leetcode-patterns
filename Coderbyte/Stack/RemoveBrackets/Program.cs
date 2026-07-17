namespace CodingPatterns.Coderbyte.Stack.RemoveBrackets;

// Coderbyte example plus already-balanced and fully-unmatched cases.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string Input, int Expected)[]
        {
            ("(()))", 1),   // Coderbyte example
            ("()()", 0),    // already balanced
            ("(()", 1),     // one unmatched '('
            ("))((", 4),    // nothing matches
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            int actual = solution.RemoveBrackets(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"RemoveBrackets(\"{input}\") = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
