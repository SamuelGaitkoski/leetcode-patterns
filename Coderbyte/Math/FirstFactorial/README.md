# First Factorial

- **Source:** Coderbyte (Easy)
- **Pattern:** Math (secondary: Recursion)

## The problem in my own words

Return `num!` = `num * (num-1) * … * 1`. Inputs range from 1 to 18.

## Key insight that unlocked it

`18!` is about `6.4 × 10^15`, which overflows a 32-bit `int`. The return type has
to be a 64-bit `long` (it still fits comfortably).

## Approach

Multiply `2 * 3 * … * num` in a loop. The recursive definition
`n! = n * (n-1)!` is equally valid — the iterative form just avoids the call
stack.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Iterative product | O(n) | O(1) |
| Recursive | O(n) | O(n) call stack |

## What tripped me up

- The overflow: forgetting to widen to `long` silently wraps around for inputs
  past 12 (`13!` already exceeds `int.MaxValue`).

## Run it

```bash
cd Coderbyte/Math/FirstFactorial
dotnet run
```
