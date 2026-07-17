namespace CodingPatterns.Coderbyte.Strings.FirstReverse;

// Coderbyte — First Reverse
// Return the input string in reversed order
// (e.g. "Hello World and Coders" -> "sredoC dna dlroW olleH").
public class Solution
{
    // Reverse a char[] copy and rebuild the string.
    // O(n) time, O(n) space.
    public string FirstReverse(string str)
    {
        char[] chars = str.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}
