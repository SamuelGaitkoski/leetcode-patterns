namespace CodingPatterns.Coderbyte.SlidingWindow.KUniqueCharacters;

// Coderbyte example plus a k=1 case.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string Input, string Expected)[]
        {
            ("2aabbacbaa", "aabba"),  // longest with <= 2 distinct
            ("3aabbcc", "aabbcc"),
            ("1aaabbb", "aaa"),       // k = 1, first longest run
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.KUniqueCharacters(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"KUniqueCharacters(\"{input}\") = \"{actual}\" (expected \"{expected}\") {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
