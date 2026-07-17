# Kaprekar's Constant

- **Source:** Coderbyte (Hard)
- **Pattern:** Math (digit manipulation)

## The problem in my own words

Take a 4-digit number with at least two distinct digits. Repeatedly subtract the
ascending-digit arrangement from the descending-digit arrangement. This always
converges to **6174** (Kaprekar's constant). Return the number of iterations
required. `3524` takes `3` steps.

## Key insight that unlocked it

The routine is a fixed-point iteration: 6174 maps to itself (`7641 - 1467 =
6174`), and every valid 4-digit input reaches it within 7 steps. So I just loop
until I hit 6174, counting steps — no cleverness needed beyond arranging digits.

## Approach

Each step: format the number as 4 digits, sort the digits ascending and
descending, subtract, and increment the counter. Stop at 6174.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Iterate to the fixed point | O(1) (≤ 7 steps) | O(1) |

## What tripped me up

- **Zero-padding**: after a subtraction like `8730 - 0378`, intermediate values can
  have fewer than 4 significant digits. Formatting with `"D4"` keeps the leading
  zeros so the ascending arrangement (e.g. `0378`) is correct.

## Run it

```bash
cd Coderbyte/Math/KaprekarsConstant
dotnet run
```
