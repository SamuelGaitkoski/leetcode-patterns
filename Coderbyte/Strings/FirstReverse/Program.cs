namespace CodingPatterns.Coderbyte.Strings.FirstReverse;

// Runs the Coderbyte example plus edge cases. `dotnet run` from this folder.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string Input, string Expected)[]
        {
            ("Hello World and Coders", "sredoC dna dlroW olleH"), // Coderbyte example
            ("coderbyte", "etybredoc"),
            ("a", "a"),
            ("", ""),
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.FirstReverse(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"FirstReverse(\"{input}\") = \"{actual}\" (expected \"{expected}\") {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
