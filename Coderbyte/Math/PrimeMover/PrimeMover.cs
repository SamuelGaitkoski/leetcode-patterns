namespace CodingPatterns.Coderbyte.Math.PrimeMover;

// Coderbyte — Prime Mover
// Return the num-th prime number (1st prime = 2, 2nd = 3, 3rd = 5, ...).
public class Solution
{
    // Count primes upward until we've seen num of them. Primality is tested by
    // trial division up to sqrt(candidate). O(num * sqrt(p)) time, O(1) space.
    public int PrimeMover(int num)
    {
        int count = 0;
        int candidate = 1;

        while (count < num)
        {
            candidate++;
            if (IsPrime(candidate))
                count++;
        }

        return candidate;
    }

    private static bool IsPrime(int n)
    {
        if (n < 2)
            return false;
        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }
}
