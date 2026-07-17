namespace CodingPatterns.Coderbyte.Math.PowerOfTwo;

// Coderbyte — Power of 2
// Return "true" if num is a power of two (1, 2, 4, 8, 16, ...), otherwise "false".
public class Solution
{
    // A positive power of two has exactly one bit set, so num & (num - 1) clears
    // that bit and yields 0. Guarding num > 0 rules out zero and negatives.
    // O(1) time, O(1) space.
    public string PowersofTwo(int num)
    {
        bool isPowerOfTwo = num > 0 && (num & (num - 1)) == 0;
        return isPowerOfTwo ? "true" : "false";
    }
}
