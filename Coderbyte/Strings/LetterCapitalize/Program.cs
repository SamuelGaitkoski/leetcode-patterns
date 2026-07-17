namespace CodingPatterns.Coderbyte.Strings.LetterCapitalize;

// Runs the Coderbyte example plus edge cases. `dotnet run` from this folder.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string Input, string Expected)[]
        {
            ("hello world", "Hello World"),      // Coderbyte example
            ("i love coding", "I Love Coding"),
            ("a b c", "A B C"),
            ("already Capital", "Already Capital"),
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.LetterCapitalize(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"LetterCapitalize(\"{input}\") = \"{actual}\" (expected \"{expected}\") {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
