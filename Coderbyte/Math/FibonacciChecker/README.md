# Fibonacci Checker

- **Source:** Coderbyte (Easy)
- **Pattern:** Math

## The problem in my own words

Decide whether a number appears in the Fibonacci sequence
(0, 1, 1, 2, 3, 5, 8, 13, …) and return `"yes"` or `"no"`.

## Key insight that unlocked it

Fibonacci numbers grow exponentially, so I only need to generate terms until I
reach or overshoot `num` — a handful of iterations even for large inputs. If the
term I stop on equals `num`, it's a Fibonacci number.

## Approach

Roll two variables `a, b` forward (`a` is the smaller). Stop once `a >= num`;
answer `"yes"` iff `a == num`.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Generate until ≥ num | O(log num) | O(1) |

## What tripped me up

- Getting the base cases right: `0` and `1` are both Fibonacci numbers, and the
  loop's `a < num` condition handles them without special-casing.

## Run it

```bash
cd Coderbyte/Math/FibonacciChecker
dotnet run
```
