namespace CodingPatterns.Coderbyte.Strings.AlphabetSoup;

// Coderbyte — Alphabet Soup
// Return the string with its letters rearranged into alphabetical order
// (e.g. "hello" -> "ehllo"). The input contains only letters — no digits or
// punctuation.
public class Solution
{
    // Sorting is the whole problem: put the characters in order and rebuild.
    // O(n log n) time for the sort, O(n) space for the char buffer.
    public string AlphabetSoup(string str)
    {
        char[] chars = str.ToCharArray();
        Array.Sort(chars);           // ordinal order == alphabetical for single-case letters
        return new string(chars);
    }
}
