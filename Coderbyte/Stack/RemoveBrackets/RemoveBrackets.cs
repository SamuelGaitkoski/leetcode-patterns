namespace CodingPatterns.Coderbyte.Stack.RemoveBrackets;

using System.Collections.Generic;

// Coderbyte — Remove Brackets
// The string contains only '(' and ')'. Return the minimum number of brackets
// that must be removed to leave a correctly matched string. e.g. "(()))" -> 1.
public class Solution
{
    // Classic stack matching: push '(' and pop it when a ')' closes it. Anything
    // still on the stack at the end is unmatched — a ')' with no partner or a '('
    // with no partner — and each must be removed. O(n) time, O(n) space.
    public int RemoveBrackets(string str)
    {
        var stack = new Stack<char>();

        foreach (char c in str)
        {
            if (c == '(')
            {
                stack.Push(c);
            }
            else // ')'
            {
                if (stack.Count > 0 && stack.Peek() == '(')
                    stack.Pop();             // matched a pair
                else
                    stack.Push(c);           // unmatched ')'
            }
        }

        return stack.Count;                  // leftover unmatched brackets
    }
}
