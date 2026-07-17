namespace CodingPatterns.Coderbyte.Math.SimpleAdding;

// Coderbyte — Simple Adding
// Return 1 + 2 + 3 + ... + num.
public class Solution
{
    // Gauss's closed form n(n+1)/2 — no loop needed. O(1) time and space.
    // (num and num+1 are consecutive, so one is even and the /2 is exact.)
    public int SimpleAdding(int num)
    {
        return num * (num + 1) / 2;
    }
}
