namespace CodingPatterns.Coderbyte.Strings.QuestionMarks;

// Coderbyte — Question Marks
// The string contains single digits, letters and question marks. Return "true"
// if every pair of consecutive digits that sums to 10 has exactly three '?'
// between them (and at least one such pair exists), otherwise "false".
// e.g. "arrb6???4xxbl5???eee5" -> "true" (6+4 and 5+5, each with three '?').
public class Solution
{
    // Single pass tracking the previous digit and how many '?' we've seen since
    // it. Whenever two consecutive digits sum to 10, the '?' count between them
    // must be exactly 3 — any violation fails immediately.
    // O(n) time, O(1) space.
    public string QuestionsMarks(string str)
    {
        int previousDigit = -1;   // -1 means "no digit seen yet"
        int questionMarks = 0;    // '?' seen since the previous digit
        bool sawValidPair = false;

        foreach (char c in str)
        {
            if (char.IsDigit(c))
            {
                int digit = c - '0';

                if (previousDigit != -1 && previousDigit + digit == 10)
                {
                    if (questionMarks == 3)
                        sawValidPair = true;
                    else
                        return "false";
                }

                previousDigit = digit;
                questionMarks = 0;
            }
            else if (c == '?')
            {
                questionMarks++;
            }
        }

        return sawValidPair ? "true" : "false";
    }
}
