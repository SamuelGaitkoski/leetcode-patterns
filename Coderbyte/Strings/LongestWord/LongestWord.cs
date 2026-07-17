namespace CodingPatterns.Coderbyte.Strings.LongestWord;

// Coderbyte — Longest Word
// Return the longest word in a sentence, ignoring punctuation. If several words
// tie for longest, return the first one.
using System.Text;

public class Solution
{
    // A "word" is a maximal run of letters/digits; anything else (spaces AND
    // punctuation) ends the current word. Treating punctuation as a separator
    // avoids gluing "hello,world" into one token. Strict ">" keeps the first of
    // equal-length words. O(n) time, O(n) space.
    public string LongestWord(string sentence)
    {
        string longest = string.Empty;
        var current = new StringBuilder();

        foreach (char c in sentence)
        {
            if (char.IsLetterOrDigit(c))
            {
                current.Append(c);
            }
            else
            {
                longest = KeepLonger(longest, current);
                current.Clear();
            }
        }

        return KeepLonger(longest, current);   // flush the final word
    }

    private static string KeepLonger(string longest, StringBuilder candidate) =>
        candidate.Length > longest.Length ? candidate.ToString() : longest;
}
