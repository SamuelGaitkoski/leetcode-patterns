# ArithGeo

- **Source:** Coderbyte (Easy)
- **Pattern:** Math (sequence analysis)

## The problem in my own words

Classify a numeric sequence as `"Arithmetic"` (constant difference between
consecutive terms), `"Geometric"` (constant ratio), or `"-1"` if it's neither.

## Key insight that unlocked it

Both patterns are "constant step" tests — one additive, one multiplicative. Fix
the step from the first two terms, then verify it holds for every adjacent pair.

## Approach

- **Arithmetic:** `diff = arr[1] - arr[0]`; check `arr[i] + diff == arr[i+1]`.
- **Geometric:** `ratio = arr[1] / arr[0]`; check `arr[i] * ratio == arr[i+1]`.

Test arithmetic first, then geometric, else `-1`.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Two linear scans | O(n) | O(1) |

## What tripped me up

- Checking the ratio with **multiplication** (`arr[i] * ratio == arr[i+1]`)
  instead of division avoids integer-truncation false positives.
- The guarantees (no zeros, not all-equal) are what make taking the step from the
  first pair safe.

## Run it

```bash
cd Coderbyte/Math/ArithGeo
dotnet run
```
