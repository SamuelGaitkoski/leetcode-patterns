# Simple Adding

- **Source:** Coderbyte (Easy)
- **Pattern:** Math

## The problem in my own words

Add up every integer from 1 to `num` and return the total.

## Key insight that unlocked it

This is the triangular-number sum, which has a closed form: `num(num+1)/2`. That
turns an O(n) loop into a single O(1) expression.

## Approach

Return `num * (num + 1) / 2`. Since `num` and `num + 1` are consecutive, exactly
one is even, so the integer division by 2 is exact.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Loop | O(n) | O(1) |
| Closed form | O(1) | O(1) |

## What tripped me up

- For large `num`, `num * (num + 1)` can overflow before the division — fine for
  Coderbyte's small inputs, but worth widening to `long` if the range grew.

## Run it

```bash
cd Coderbyte/Math/SimpleAdding
dotnet run
```
