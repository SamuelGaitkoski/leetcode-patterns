# Consecutive

- **Source:** Coderbyte (Medium)
- **Pattern:** Sorting (secondary: Math)

## The problem in my own words

Given an array, how many integers must be added so the values form an unbroken
run from the smallest to the largest? For `[4, 8, 6]` the answer is `2` (the
missing `5` and `7`).

## Key insight that unlocked it

Once the array is **sorted**, the missing numbers all live in the gaps between
neighbouring values. A pair `(x, y)` with `y > x` hides `y - x - 1` missing
integers, so summing that over adjacent pairs gives the total.

## Approach

Sort a copy, then accumulate `sorted[i+1] - sorted[i] - 1` across the array.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Sort + gap sum | O(n log n) | O(n) |

An O(n) alternative computes `(max - min + 1) - n` directly, but the sort-and-sum
version makes the "count the gaps" idea visible and handles duplicates gracefully.

## What tripped me up

- Cloning before sorting so the caller's array isn't reordered as a side effect.

## Run it

```bash
cd Coderbyte/Sorting/Consecutive
dotnet run
```
