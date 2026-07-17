namespace CodingPatterns.Coderbyte.Math.FibonacciChecker;

// Coderbyte — Fibonacci Checker
// Return "yes" if num is a Fibonacci number (0, 1, 1, 2, 3, 5, 8, 13, ...),
// otherwise "no".
public class Solution
{
    // Generate Fibonacci numbers until we reach or pass num, then check equality.
    // O(log num) terms (Fibonacci grows exponentially), O(1) space.
    public string FibonacciChecker(int num)
    {
        int a = 0, b = 1;

        while (a < num)
        {
            int next = a + b;
            a = b;
            b = next;
        }

        return a == num ? "yes" : "no";
    }
}
