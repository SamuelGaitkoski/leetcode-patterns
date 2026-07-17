namespace CodingPatterns.Coderbyte.Strings.RunLength;

// Coderbyte example plus all-same and all-distinct cases.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string Input, string Expected)[]
        {
            ("wwwggopp", "3w2g1o2p"),  // Coderbyte example
            ("aaa", "3a"),
            ("abc", "1a1b1c"),
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.RunLength(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"RunLength(\"{input}\") = \"{actual}\" (expected \"{expected}\") {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
