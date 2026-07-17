namespace CodingPatterns.LeetCode.HashMap.RomanToInteger;

// Verifies both approaches against the LeetCode examples plus the edge case
// that crashed the original buggy attempt ("III").
// Run with `dotnet run` from this folder.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string S, int Expected)[]
        {
            ("III", 3),        // example 1 — also the input that threw the exception
            ("LVIII", 58),     // example 2
            ("MCMXCIV", 1994), // example 3
            ("IV", 4),         // subtractive pair
            ("IX", 9),         // subtractive pair
            ("MMMCMXCIX", 3999) // largest valid numeral
        };

        bool allPassed = true;

        foreach (var (s, expected) in cases)
        {
            int lookBothWays = solution.RomanToInt(s);
            int explicitPairs = solution.RomanToIntExplicit(s);
            int compareNext = solution.RomanToIntCompareNext(s);
            int rightToLeft = solution.RomanToIntRightToLeft(s);
            bool pass = lookBothWays == expected && explicitPairs == expected
                        && compareNext == expected && rightToLeft == expected;
            allPassed &= pass;

            Console.WriteLine($"{s,-10} -> bothWays={lookBothWays,-5} pairs={explicitPairs,-5} " +
                              $"next={compareNext,-5} rtl={rightToLeft,-5} " +
                              $"(expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
