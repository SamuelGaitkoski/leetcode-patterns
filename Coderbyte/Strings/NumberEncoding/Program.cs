namespace CodingPatterns.Coderbyte.Strings.NumberEncoding;

// Coderbyte example plus letter-only and mixed cases.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string Input, string Expected)[]
        {
            ("af5c a#!", "1653 1#!"),  // Coderbyte example
            ("abc", "123"),
            ("hello", "85121215"),     // h=8 e=5 l=12 l=12 o=15
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.NumberEncoding(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"NumberEncoding(\"{input}\") = \"{actual}\" (expected \"{expected}\") {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
