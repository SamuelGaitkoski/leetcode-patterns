namespace LeetCodePatterns.HashMap.RomanToInteger;

// LeetCode #13 — Roman to Integer
// Convert a valid Roman numeral string to its integer value.
public class Solution
{
    // Symbol -> value lookup, used by approaches 2 and 3. Static + readonly so
    // it's built once, not per call.
    private static readonly Dictionary<char, int> Values = new()
    {
        ['I'] = 1,
        ['V'] = 5,
        ['X'] = 10,
        ['L'] = 50,
        ['C'] = 100,
        ['D'] = 500,
        ['M'] = 1000,
    };

    // Approach 1: "look both ways" — my original attempt, corrected.
    // For each symbol, look at the PREVIOUS char to decide whether this larger
    // numeral is reduced (e.g. M after C is 900, not 1000), and look at the NEXT
    // char to skip a smaller numeral that is only a subtractive prefix (e.g. the
    // C in "CM" is counted when we reach the M, so we skip it here).
    // O(n) time, O(1) space.
    public int RomanToInt(string s)
    {
        int num = 0;

        for (int i = 0; i < s.Length; i++)
        {
            // Guard for the look-ahead: true when the next char is missing OR is
            // not one of the two larger numerals this symbol can prefix. Reading
            // s[i + 1] unconditionally (as the original did) threw
            // IndexOutOfRangeException on the last character. Treating "no next
            // char" as "not a larger numeral" means the symbol gets counted here.
            bool hasNext = i + 1 < s.Length;

            if (s[i] == 'M')
            {
                if (i > 0 && s[i - 1] == 'C')
                    num += 900;   // CM
                else
                    num += 1000;
            }

            if (s[i] == 'D')
            {
                if (i > 0 && s[i - 1] == 'C')
                    num += 400;   // CD
                else
                    num += 500;
            }

            if (s[i] == 'C' && (!hasNext || (s[i + 1] != 'D' && s[i + 1] != 'M')))
            {
                if (i > 0 && s[i - 1] == 'X')
                    num += 90;    // XC
                else
                    num += 100;
            }

            if (s[i] == 'L')
            {
                if (i > 0 && s[i - 1] == 'X')
                    num += 40;    // XL
                else
                    num += 50;
            }

            if (s[i] == 'X' && (!hasNext || (s[i + 1] != 'L' && s[i + 1] != 'C')))
            {
                if (i > 0 && s[i - 1] == 'I')
                    num += 9;     // IX
                else
                    num += 10;
            }

            if (s[i] == 'V')
            {
                if (i > 0 && s[i - 1] == 'I')
                    num += 4;     // IV
                else
                    num += 5;
            }

            if (s[i] == 'I' && (!hasNext || (s[i + 1] != 'V' && s[i + 1] != 'X')))
                num += 1;
        }

        return num;
    }

    // Approach 2: explicit subtractive pairs — my idea from Approach 1, simplified.
    // Instead of looking backward AND forward, only look forward: when the current
    // symbol starts one of the six subtractive pairs, add the pair's value and
    // skip the next char (i++); otherwise add the symbol on its own. Same spirit
    // as the original, but one direction and no per-symbol branch for the large
    // numerals. O(n) time, O(1) space.
    public int RomanToIntExplicit(string s)
    {
        int num = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            bool hasNext = i + 1 < s.Length;
            char next = hasNext ? s[i + 1] : '\0';  // '\0' safely matches nothing

            if (c == 'I' && next == 'V') { num += 4; i++; }
            else if (c == 'I' && next == 'X') { num += 9; i++; }
            else if (c == 'X' && next == 'L') { num += 40; i++; }
            else if (c == 'X' && next == 'C') { num += 90; i++; }
            else if (c == 'C' && next == 'D') { num += 400; i++; }
            else if (c == 'C' && next == 'M') { num += 900; i++; }
            else { num += Values[c]; }
        }

        return num;
    }

    // Approach 3: left-to-right, compare each numeral with the NEXT one.
    // The single rule that replaces all the special cases: a numeral that is
    // smaller than the one after it is subtractive (IV, IX, XL, CM, ...).
    // O(n) time, O(1) space.
    public int RomanToIntCompareNext(string s)
    {
        int total = 0;

        for (int i = 0; i < s.Length; i++)
        {
            int current = Values[s[i]];

            if (i + 1 < s.Length && current < Values[s[i + 1]])
                total -= current;
            else
                total += current;
        }

        return total;
    }

    // Approach 4: right-to-left, no look-ahead needed at all (LeetCode's Hint 1).
    // Walk from the end tracking the largest value seen so far. Anything smaller
    // than that maximum is a subtractive prefix. O(n) time, O(1) space.
    public int RomanToIntRightToLeft(string s)
    {
        int total = 0;
        int rightMax = 0;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            int current = Values[s[i]];

            if (current < rightMax)
            {
                total -= current;
            }
            else
            {
                total += current;
                rightMax = current;
            }
        }

        return total;
    }
}
