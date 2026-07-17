namespace CodingPatterns.Coderbyte.Strings.NumberEncoding;

using System.Text;

// Coderbyte — Number Encoding
// Replace every letter with its 1-based position in the alphabet (a=1 ... z=26).
// Non-letters (spaces, symbols, digits) pass through unchanged.
// e.g. "af5c a#!" -> "1653 1#!".
public class Solution
{
    // Map letters to their alphabet index arithmetically (c - 'a' + 1); leave
    // everything else alone. O(n) time, O(n) space.
    public string NumberEncoding(string str)
    {
        var sb = new StringBuilder();

        foreach (char c in str)
        {
            if (char.IsLetter(c))
                sb.Append(char.ToLower(c) - 'a' + 1);
            else
                sb.Append(c);
        }

        return sb.ToString();
    }
}
