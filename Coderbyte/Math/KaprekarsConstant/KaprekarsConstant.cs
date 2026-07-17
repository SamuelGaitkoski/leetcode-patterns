namespace CodingPatterns.Coderbyte.Math.KaprekarsConstant;

// Coderbyte — Kaprekar's Constant
// For a 4-digit number (with at least two distinct digits), repeatedly do:
// (digits in descending order) - (digits in ascending order). This always reaches
// 6174. Return how many iterations it takes. e.g. 3524 -> 3.
public class Solution
{
    // Apply Kaprekar's routine until the number is 6174, counting steps. Each step
    // sorts the four digits both ways and subtracts. O(1) — the routine reaches
    // 6174 in at most 7 iterations for any valid input.
    public int KaprekarsConstant(int num)
    {
        int count = 0;

        while (num != 6174)
        {
            int descending = SortedDigits(num, descending: true);
            int ascending = SortedDigits(num, descending: false);
            num = descending - ascending;
            count++;
        }

        return count;
    }

    // Pad to 4 digits, sort them, and read back as an int. Ascending order may
    // produce leading zeros (e.g. 0378) — int.Parse handles those fine.
    private static int SortedDigits(int num, bool descending)
    {
        char[] digits = num.ToString("D4").ToCharArray();
        Array.Sort(digits);
        if (descending)
            Array.Reverse(digits);
        return int.Parse(new string(digits));
    }
}
