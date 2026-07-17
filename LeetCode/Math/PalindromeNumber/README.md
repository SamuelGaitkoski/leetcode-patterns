# 9. Palindrome Number

- **Link:** <https://leetcode.com/problems/palindrome-number/>
- **Difficulty:** Easy
- **Pattern:** Math (with a Two-Pointers flavor in the string approach)

## The problem in my own words

Given an integer `x`, return `true` if it reads the same left-to-right and
right-to-left. Negative numbers are never palindromes (the `-` sign only appears
on one end).

## First-attempt notes

My first cut used nested loops and did `return text[i] == text[j]` **inside**
the inner loop. That's a classic trap: it returns on the very first comparison
instead of checking every pair, so it only ever looks at one pair of digits. The
fix is to only `return false` on a mismatch, and return `true` *after* the loop
finishes without finding one.

The real question the problem is nudging toward is the **follow-up**: can you do
it without converting to a string at all?

## Key insight that unlocked it

You don't have to reverse the whole number (which can overflow `int`). Reverse
only the **second half** and compare it to the first half. You know you've hit
the halfway point when the reversed part becomes `>=` the shrinking original.

## Approach(es)

### Approach 1 — string + two pointers (`IsPalindromeString`)

Convert to a string, then walk one pointer from the left and one from the right,
comparing as they move inward. Stop early on any mismatch.

### Approach 2 — reverse half the digits (`IsPalindromeMath`, the follow-up)

Handle two quick rejections first:

- `x < 0` → not a palindrome.
- `x` ends in `0` but isn't `0` (e.g. `10`, `120`) → not a palindrome, because a
  palindrome can't have a leading zero.

Then peel digits off the end of `x` and build them up in `reversedHalf`:

```
reversedHalf = reversedHalf * 10 + x % 10;
x /= 10;
```

Loop while `x > reversedHalf`. When it stops, `reversedHalf` holds the reversed
back half:

- **Even number of digits** → `x == reversedHalf`.
- **Odd number of digits** → the middle digit is stuck on `reversedHalf`, so
  `x == reversedHalf / 10` (integer division drops it).

Worked example, `x = 12321`:

| step | x     | reversedHalf |
|------|-------|--------------|
| start| 12321 | 0            |
| 1    | 1232  | 1            |
| 2    | 123   | 12           |
| 3    | 12    | 123          |

Now `x (12) <= reversedHalf (123)`, loop stops. `reversedHalf / 10 == 12 == x` → palindrome ✅

## Complexity

| Approach                 | Time        | Space |
| ------------------------ | ----------- | ----- |
| String + two pointers    | O(n)        | O(n)  |
| Reverse half (math)      | O(log₁₀ n)  | O(1)  |

`n` = number of digits. The math approach avoids allocating a string and never
reverses the full value, so it can't overflow.

## What tripped me up

- **Returning inside the loop too early** (the original nested-loop bug).
- Forgetting that **trailing-zero** numbers like `10` fail — easy to miss until
  a test case catches it.
- The **odd-length** case in the math approach: remembering to strip the middle
  digit with `reversedHalf / 10`.

## Run it

```bash
cd Math/PalindromeNumber
dotnet run
```
