# Check Numbers

- **Source:** Coderbyte (Easy)
- **Pattern:** Math

## The problem in my own words

Compare two numbers and return a word: `"true"` if the second is larger,
`"false"` if it's smaller, and `"-1"` if they're equal.

## Key insight that unlocked it

It's a plain three-way comparison — the only subtlety is that the challenge wants
string outputs, including the sentinel `"-1"` for the equal case.

## Approach

Two `if`s (greater, less) with the equal case as the fall-through.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Compare | O(1) | O(1) |

## What tripped me up

- Returning the literal strings, not a boolean or an integer.

## Run it

```bash
cd Coderbyte/Math/CheckNumbers
dotnet run
```
