namespace CodingPatterns.Coderbyte.Math.FirstFactorial;

// Coderbyte — First Factorial
// Return num! (num factorial). The input is between 1 and 18, so the result can
// exceed a 32-bit int — use a 64-bit long.
public class Solution
{
    // Iterative product 2*3*...*num. O(num) time, O(1) space.
    // (The imported version recursed; the loop avoids the call stack.)
    public long FirstFactorial(int num)
    {
        long result = 1;
        for (int i = 2; i <= num; i++)
            result *= i;
        return result;
    }
}
