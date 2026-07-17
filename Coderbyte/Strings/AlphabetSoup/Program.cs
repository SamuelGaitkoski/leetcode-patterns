namespace CodingPatterns.Coderbyte.Strings.AlphabetSoup;

// Runs the Coderbyte example plus a few edge cases. `dotnet run` from this folder.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string Input, string Expected)[]
        {
            ("hello", "ehllo"),       // Coderbyte example
            ("coderbyte", "bcdeeorty"),
            ("a", "a"),               // single character
            ("", ""),                 // empty string
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.AlphabetSoup(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"AlphabetSoup(\"{input}\") = \"{actual}\" (expected \"{expected}\") {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
