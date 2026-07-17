# String Periods

- **Source:** Coderbyte (Easy)
- **Pattern:** Strings

## The problem in my own words

Find the longest substring `K` such that repeating `K` some number of times
`N > 1` reproduces the whole input exactly. Return `K`, or `"-1"` when no such
block exists (a single character has no valid period).

## Key insight that unlocked it

Two constraints shrink the search dramatically:

1. `K` has to **tile** the string exactly, so its length must divide `str.Length`.
2. Because it repeats *more than once*, `K` can be at most half the length.

Only prefix lengths that divide the string are worth testing, and trying them in
increasing order means the last one that works is automatically the longest.

## Approach

For each divisor length `len` up to `n/2`, take the length-`len` prefix and check
whether repeating it rebuilds the string. Keep the longest that does.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Test each divisor length | O(n²) | O(n) |

## What tripped me up

- Only a **prefix** can be the period — if the string is periodic, the repeating
  block always starts at index 0.
- The divisibility check is what makes `"abababababab"` return `"ababab"` (len 6)
  and not stop at `"ab"`.

## Run it

```bash
cd Coderbyte/Strings/StringPeriods
dotnet run
```
