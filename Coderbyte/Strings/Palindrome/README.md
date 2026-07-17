# Palindrome

- **Source:** Coderbyte (Easy)
- **Pattern:** Strings (secondary: Two Pointers)

## The problem in my own words

Decide whether a string reads the same forwards and backwards, ignoring spaces,
and return the literal string `"true"` or `"false"`.

## Key insight that unlocked it

A palindrome check is the classic **two pointers** move: compare the ends and
walk inward. Ignoring spaces just means skipping a pointer forward/backward when
it lands on one, without consuming a comparison.

## Approach

`left` starts at the front, `right` at the back. Skip spaces on either side;
otherwise compare. A mismatch means "false"; if the pointers cross without a
mismatch, it's "true".

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Two pointers | O(n) | O(1) |

The original imported solution stripped spaces into a new string and reversed
it (O(n) extra space). Two pointers reaches the same answer without allocating.

## What tripped me up

- The challenge wants the **word** `"true"`/`"false"`, not a boolean.
- Remembering to skip spaces *before* comparing, so `"never odd or even"` is
  recognized as a palindrome.

## Run it

```bash
cd Coderbyte/Strings/Palindrome
dotnet run
```
