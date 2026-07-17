namespace CodingPatterns.Coderbyte.Strings.StringReduction;

// Coderbyte — String Reduction
// The string contains only 'a', 'b', 'c'. Repeatedly replace two DIFFERENT
// adjacent characters with the third (e.g. "ac" -> "b") until no more reductions
// are possible; return the length of the shortest string reachable.
public class Solution
{
    // Known closed form (the reduction preserves the parities of the three
    // counts): if only one distinct letter is present nothing reduces, so the
    // answer is the length. Otherwise the string collapses to length 1 unless all
    // three counts share the same parity, in which case it bottoms out at 2.
    // O(n) time, O(1) space.
    public int StringReduction(string str)
    {
        int a = 0, b = 0, c = 0;
        foreach (char ch in str)
        {
            if (ch == 'a') a++;
            else if (ch == 'b') b++;
            else c++;
        }

        int distinct = (a > 0 ? 1 : 0) + (b > 0 ? 1 : 0) + (c > 0 ? 1 : 0);
        if (distinct <= 1)
            return str.Length;              // nothing to reduce

        bool sameParity = a % 2 == b % 2 && b % 2 == c % 2;
        return sameParity ? 2 : 1;
    }
}
