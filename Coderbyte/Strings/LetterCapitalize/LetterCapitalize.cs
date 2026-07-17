namespace CodingPatterns.Coderbyte.Strings.LetterCapitalize;

// Coderbyte — Letter Capitalize
// Capitalize the first letter of each word. Words are separated by a single
// space (e.g. "hello world" -> "Hello World").
public class Solution
{
    // A character starts a word when it is the very first character or the one
    // right after a space. Uppercase exactly those.
    // O(n) time, O(n) space.
    public string LetterCapitalize(string str)
    {
        char[] chars = str.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            bool startOfWord = i == 0 || chars[i - 1] == ' ';
            if (startOfWord)
                chars[i] = char.ToUpper(chars[i]);
        }

        return new string(chars);
    }
}
