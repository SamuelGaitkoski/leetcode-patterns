namespace CodingPatterns.Coderbyte.Strings.QuestionMarks;

// Runs the Coderbyte example plus true/false edge cases.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string Input, string Expected)[]
        {
            ("arrb6???4xxbl5???eee5", "true"),  // Coderbyte example
            ("6???4", "true"),                  // exactly three '?'
            ("6??4", "false"),                  // only two '?'
            ("mmmm", "false"),                  // no digits summing to 10
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.QuestionsMarks(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"QuestionsMarks(\"{input}\") = \"{actual}\" (expected \"{expected}\") {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
