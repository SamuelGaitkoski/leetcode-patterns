# Product Digits

- **Source:** Coderbyte (Easy)
- **Pattern:** Math (factorization)

## The problem in my own words

Find the smallest total number of digits across two factors whose product is
`num`. For `24`, `8 * 3` uses 2 digits; for `90`, the best is `10 * 9` = 3 digits.

## Key insight that unlocked it

Only the factor pairs of `num` matter, and every pair `(i, num/i)` is captured by
scanning `i` up to `√num`. The "digit cost" of a pair is just the digit counts of
its two factors, so I minimize that over all divisors.

## Approach

Start with the fallback `num * 1`. For each divisor `i ≤ √num`, measure
`digits(i) + digits(num/i)` and keep the minimum.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Scan divisors to √num | O(√num) | O(1) |

## What tripped me up

- The two factors don't have to be single digits — for `90`, no two single-digit
  numbers multiply to 90, so the answer is 3 (`10 * 9`).
- Using `i * i <= num` instead of `Math.Sqrt` keeps the loop bound in integer
  arithmetic (no floating-point edge cases).

## Run it

```bash
cd Coderbyte/Math/ProductDigits
dotnet run
```
