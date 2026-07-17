namespace CodingPatterns.Coderbyte.Strings.RunLength;

using System.Text;

// Coderbyte — Run Length
// Return the run-length encoding of a string: each maximal run of a repeated
// character becomes "<count><char>". e.g. "wwwggopp" -> "3w2g1o2p".
public class Solution
{
    // Walk the string in runs: for each position, count how many identical
    // characters follow, emit "<count><char>", then jump past the run.
    // O(n) time, O(n) space.
    public string RunLength(string str)
    {
        var sb = new StringBuilder();
        int i = 0;

        while (i < str.Length)
        {
            int count = 1;
            while (i + count < str.Length && str[i + count] == str[i])
                count++;

            sb.Append(count).Append(str[i]);
            i += count;
        }

        return sb.ToString();
    }
}
