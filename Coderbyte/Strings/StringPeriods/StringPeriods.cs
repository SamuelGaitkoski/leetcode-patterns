namespace CodingPatterns.Coderbyte.Strings.StringPeriods;

using System.Text;

// Coderbyte — String Periods
// Find the longest substring K that can be repeated N > 1 times to reproduce the
// input exactly (e.g. "abcababcababcab" -> "abcab"). Return "-1" if none exists
// (including single-character strings).
public class Solution
{
    // A repeating block K must divide the string evenly, and to repeat more than
    // once it can be at most half the length. Trying lengths in increasing order
    // means the last one that tiles the string is the longest.
    // O(n^2) time (each candidate length rebuilds the string), O(n) space.
    public string StringPeriods(string str)
    {
        string result = "-1";

        for (int len = 1; len <= str.Length / 2; len++)
        {
            if (str.Length % len != 0)
                continue;                     // K must tile the string with no remainder

            string candidate = str.Substring(0, len);
            if (Tiles(candidate, str))
                result = candidate;           // longer valid K seen later overwrites
        }

        return result;
    }

    // True when repeating `block` reproduces `full` exactly.
    private static bool Tiles(string block, string full)
    {
        var sb = new StringBuilder(full.Length);
        while (sb.Length < full.Length)
            sb.Append(block);
        return sb.ToString() == full;
    }
}
