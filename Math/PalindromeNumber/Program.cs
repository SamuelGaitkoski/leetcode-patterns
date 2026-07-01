namespace LeetCodePatterns.Math.PalindromeNumber;

// Verifies both approaches against the LeetCode examples plus a few edge cases.
// Run with `dotnet run` from this folder.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (int X, bool Expected)[]
        {
            (121, true),    // example 1
            (-121, false),  // example 2 — negative
            (10, false),    // example 3 — trailing zero
            (0, true),      // edge: zero
            (12321, true),  // edge: odd length
            (1221, true),   // edge: even length
        };

        bool allPassed = true;

        foreach (var (x, expected) in cases)
        {
            bool str = solution.IsPalindromeString(x);
            bool math = solution.IsPalindromeMath(x);
            bool pass = str == expected && math == expected;
            allPassed &= pass;

            Console.WriteLine($"x={x,-6} -> string={str,-5} math={math,-5} " +
                              $"(expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
