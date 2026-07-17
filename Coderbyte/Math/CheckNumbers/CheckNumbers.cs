namespace CodingPatterns.Coderbyte.Math.CheckNumbers;

// Coderbyte — Check Numbers
// Given num1 and num2, return "true" if num2 is greater than num1, "false" if it
// is smaller, and "-1" if they are equal.
public class Solution
{
    // A three-way comparison. O(1) time and space.
    public string CheckNumber(int num1, int num2)
    {
        if (num2 > num1)
            return "true";
        if (num2 < num1)
            return "false";
        return "-1";
    }
}
