namespace CodingPatterns.Coderbyte.Strings.SimpleSymbols;

// Coderbyte — Simple Symbols
// The string is made of '+' and '=' symbols with letters between them
// (e.g. "++d+===+c++==a"). It is acceptable only when EVERY letter has a '+'
// immediately before AND after it. Return "true" or "false".
public class Solution
{
    // Check each letter's two neighbours. A single unguarded letter (including a
    // letter at either boundary, which cannot have both neighbours) fails.
    // O(n) time, O(1) space.
    public string SimpleSymbols(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsLetter(str[i]))
            {
                bool surrounded = i > 0 && i < str.Length - 1
                                  && str[i - 1] == '+' && str[i + 1] == '+';
                if (!surrounded)
                    return "false";
            }
        }

        return "true";
    }
}
