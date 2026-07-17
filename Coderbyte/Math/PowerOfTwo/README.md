# Power of 2

- **Source:** Coderbyte (Easy)
- **Pattern:** Math (bit manipulation)

## The problem in my own words

Return `"true"` if the number is a power of two, otherwise `"false"`.

## Key insight that unlocked it

A power of two has exactly one bit set in binary (`1000`, `0100`, …). Subtracting
1 flips that bit to 0 and sets all lower bits, so `num & (num - 1)` erases the
only set bit and gives 0 — a one-line test.

## Approach

`num > 0 && (num & (num - 1)) == 0`.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Bit trick | O(1) | O(1) |

## What tripped me up

- `0` sneaks through `(num & (num - 1)) == 0` (0 & -1 == 0), so the explicit
  `num > 0` guard is essential — and it also rejects negatives.
- The imported version used `Math.Log`, which drags floating-point rounding into
  what is really an integer question; the bit test is exact.

## Run it

```bash
cd Coderbyte/Math/PowerOfTwo
dotnet run
```
