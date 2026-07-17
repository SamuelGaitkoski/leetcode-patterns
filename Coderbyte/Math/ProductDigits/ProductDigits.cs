namespace CodingPatterns.Coderbyte.Math.ProductDigits;

// Coderbyte — Product Digits
// Return the least number of digits needed to multiply two factors together to
// produce num. e.g. 24 = 8 * 3 -> 2 digits; 90 = 10 * 9 -> 3 digits.
public class Solution
{
    // Every factor pair (i, num/i) with i <= sqrt(num) is a candidate; the digit
    // cost is the digit count of both factors. The most "balanced" factorization
    // tends to minimize total digits, so scan all divisors up to the square root.
    // O(sqrt(num)) time, O(1) space.
    public int ProductDigits(int num)
    {
        // Fallback: num itself times 1 (digits(num) + 1 for the "1").
        int best = num.ToString().Length + 1;

        for (int i = 1; i * i <= num; i++)
        {
            if (num % i != 0)
                continue;

            int factor = num / i;
            int digits = i.ToString().Length + factor.ToString().Length;
            best = System.Math.Min(best, digits);
        }

        return best;
    }
}
