# Prime Mover

- **Source:** Coderbyte (Medium)
- **Pattern:** Math

## The problem in my own words

Return the `num`-th prime number, counting `2` as the 1st prime.

## Key insight that unlocked it

Walk candidate integers upward, testing each for primality and counting the hits
until the count reaches `num`. Trial division only needs to go up to
`√candidate`: if a number has a factor larger than its square root, it must also
have the paired factor below it.

## Approach

Increment `candidate` from 2; whenever `IsPrime(candidate)` holds, bump a counter;
stop when the counter equals `num`.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Trial division per candidate | O(num · √p) | O(1) |

A sieve would be faster for many queries; trial division is simplest for a single
lookup.

## What tripped me up

- The `i * i <= n` loop bound (instead of `Math.Sqrt`) keeps the primality test
  in exact integer arithmetic.

## Run it

```bash
cd Coderbyte/Math/PrimeMover
dotnet run
```
