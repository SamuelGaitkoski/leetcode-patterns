namespace LeetCodePatterns.Math.PalindromeNumber;

// LeetCode #9 — Palindrome Number
// Return true if the integer reads the same forwards and backwards.
public class Solution
{
    // Approach 1: convert to a string, then two pointers from both ends.
    // O(n) time, O(n) space (n = number of digits).
    public bool IsPalindromeString(int x)
    {
        // Negative numbers are never palindromes because of the leading '-'.
        if (x < 0)
            return false;

        string text = x.ToString();
        int left = 0, right = text.Length - 1;

        while (left < right)
        {
            // Bail out on the first mismatch; only conclude "palindrome" once
            // the pointers have crossed without finding one.
            if (text[left] != text[right])
                return false;

            left++;
            right--;
        }

        return true;
    }

    // Approach 2 (follow-up): no string conversion — reverse only the second
    // half of the number and compare it to the first half.
    // O(log10 n) time, O(1) space.
    public bool IsPalindromeMath(int x)
    {
        // Negatives fail, and any number ending in 0 (except 0 itself) can't be
        // a palindrome — its reverse would have a leading zero.
        if (x < 0 || (x % 10 == 0 && x != 0))
            return false;

        int reversedHalf = 0;

        // Peel digits off the end of x onto reversedHalf. Stop once reversedHalf
        // has "caught up" to x, meaning we've processed half the digits — this
        // also avoids the integer overflow of reversing the whole number.
        while (x > reversedHalf)
        {
            reversedHalf = reversedHalf * 10 + x % 10;
            x /= 10;
        }

        // Even length: the two halves match exactly (x == reversedHalf).
        // Odd length: the middle digit sits in reversedHalf, so drop it with /10.
        return x == reversedHalf || x == reversedHalf / 10;
    }
}
