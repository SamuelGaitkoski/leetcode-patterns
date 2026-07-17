namespace CodingPatterns.LeetCode.Strings.LongestCommonPrefix;

// Verifies all five approaches against the LeetCode examples plus edge cases:
// an empty string in the array, a single string, and identical strings.
// Each approach gets a fresh array copy because the sort approach reorders it.
// Run with `dotnet run` from this folder.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string[] Strs, string Expected)[]
        {
            (new[] { "flower", "flow", "flight" }, "fl"),   // example 1
            (new[] { "dog", "racecar", "car" }, ""),        // example 2 — no common prefix
            (new[] { "" }, ""),                             // single empty string
            (new[] { "", "b" }, ""),                        // an empty string kills the prefix
            (new[] { "abc" }, "abc"),                       // single string -> itself
            (new[] { "abab", "aba", "abc" }, "ab"),         // one string is a prefix of another
            (new[] { "same", "same", "same" }, "same"),     // all identical
        };

        bool allPassed = true;

        foreach (var (strs, expected) in cases)
        {
            string vertical = solution.LongestCommonPrefix(Copy(strs));
            string horizontal = solution.LongestCommonPrefixHorizontal(Copy(strs));
            string sort = solution.LongestCommonPrefixSort(Copy(strs));
            string divide = solution.LongestCommonPrefixDivideConquer(Copy(strs));
            string binary = solution.LongestCommonPrefixBinarySearch(Copy(strs));

            bool pass = vertical == expected && horizontal == expected && sort == expected
                        && divide == expected && binary == expected;
            allPassed &= pass;

            Console.WriteLine($"[{string.Join(",", strs),-25}] -> vert=\"{vertical}\" horiz=\"{horizontal}\" " +
                              $"sort=\"{sort}\" d&c=\"{divide}\" bin=\"{binary}\" " +
                              $"(expected \"{expected}\") {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }

    // Approaches like the sort trick reorder the array in place, so hand each call
    // its own copy to keep the cases independent.
    private static string[] Copy(string[] strs) => (string[])strs.Clone();
}
