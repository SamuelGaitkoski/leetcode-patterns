namespace CodingPatterns.Coderbyte.Strings.Palindrome;

// Coderbyte — Palindrome
// Return "true" if the string reads the same forwards and backwards once
// spaces are ignored, otherwise "false".
public class Solution
{
    // Two pointers from both ends, skipping spaces. Returns the word "true" /
    // "false" as the challenge specifies (not a bool).
    // O(n) time, O(1) space.
    public string Palindrome(string str)
    {
        int left = 0, right = str.Length - 1;

        while (left < right)
        {
            if (str[left] == ' ') { left++; continue; }
            if (str[right] == ' ') { right--; continue; }

            if (str[left] != str[right])
                return "false";

            left++;
            right--;
        }

        return "true";
    }
}
