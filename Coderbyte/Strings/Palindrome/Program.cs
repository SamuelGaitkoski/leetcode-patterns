namespace CodingPatterns.Coderbyte.Strings.Palindrome;

// Runs the Coderbyte examples plus a spaces-ignored case.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string Input, string Expected)[]
        {
            ("racecar", "true"),
            ("hello", "false"),
            ("never odd or even", "true"), // spaces ignored
            ("eye", "true"),
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.Palindrome(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"Palindrome(\"{input}\") = \"{actual}\" (expected \"{expected}\") {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
