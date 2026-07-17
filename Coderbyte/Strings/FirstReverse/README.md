# First Reverse

- **Source:** Coderbyte (Easy)
- **Pattern:** Strings

## The problem in my own words

Return the string with its characters in reverse order. Spaces are just
characters and get reversed along with everything else.

## Key insight that unlocked it

Reversal is a built-in operation on arrays. Because C# strings are immutable, I
reverse a `char[]` copy and construct a new string from it.

## Approach

`Array.Reverse` on the char buffer, then `new string(chars)`.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Reverse char buffer | O(n) | O(n) |

## What tripped me up

- Doing it by hand with two pointers (swap ends moving inward) is the same idea
  and also O(n) — the library call just hides the loop.

## Run it

```bash
cd Coderbyte/Strings/FirstReverse
dotnet run
```
