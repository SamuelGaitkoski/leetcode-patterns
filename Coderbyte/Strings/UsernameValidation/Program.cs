namespace CodingPatterns.Coderbyte.Strings.UsernameValidation;

// One case per rule (plus a fully valid username).
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string Input, string Expected)[]
        {
            ("goodusername", "true"),
            ("aa_1", "true"),          // minimum length, all rules pass
            ("us", "false"),           // rule 1: too short
            ("1username", "false"),    // rule 2: starts with a digit
            ("user_", "false"),        // rule 4: ends with underscore
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.CodelandUsernameValidation(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"CodelandUsernameValidation(\"{input}\") = \"{actual}\" (expected \"{expected}\") {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
