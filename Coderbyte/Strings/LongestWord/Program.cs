namespace CodingPatterns.Coderbyte.Strings.LongestWord;

// Runs the Coderbyte-style examples plus a punctuation case.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string Input, string Expected)[]
        {
            ("the quick brown fox jumped", "jumped"),
            ("hello world", "hello"),   // tie on length -> first wins
            ("fun&!! time", "time"),    // punctuation stripped from "fun&!!"
            ("cat", "cat"),             // single word
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.LongestWord(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"LongestWord(\"{input}\") = \"{actual}\" (expected \"{expected}\") {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
