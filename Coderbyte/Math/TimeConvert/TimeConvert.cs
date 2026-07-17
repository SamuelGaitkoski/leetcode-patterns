namespace CodingPatterns.Coderbyte.Math.TimeConvert;

// Coderbyte — Time Convert
// Convert a number of minutes into "hours:minutes". e.g. 63 -> "1:3".
public class Solution
{
    // Integer division gives whole hours; the remainder gives leftover minutes.
    // O(1) time and space.
    public string TimeConvert(int num)
    {
        int hours = num / 60;
        int minutes = num % 60;
        return $"{hours}:{minutes}";
    }
}
