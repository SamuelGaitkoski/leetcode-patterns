namespace CodingPatterns.Coderbyte.Strings.LetterChanges;

// Coderbyte — Letter Changes
// Replace every letter with the letter that follows it in the alphabet
// (c -> d, z -> a), then capitalize every vowel in the result.
public class Solution
{
    // One pass: shift each letter, wrapping z -> a, then upper-case vowels.
    // O(n) time, O(n) space.
    public string LetterChanges(string str)
    {
        char[] chars = str.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            char c = chars[i];

            if (char.IsLetter(c))
                c = c == 'z' ? 'a' : (char)(c + 1);   // wrap the end of the alphabet

            if (c is 'a' or 'e' or 'i' or 'o' or 'u')
                c = char.ToUpper(c);

            chars[i] = c;
        }

        return new string(chars);
    }
}
