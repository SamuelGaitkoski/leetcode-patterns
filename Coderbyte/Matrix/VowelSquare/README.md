# Vowel Square

- **Source:** Coderbyte (Easy)
- **Pattern:** Matrix (secondary: Strings)

## The problem in my own words

The input is a grid of equal-length strings. Find a 2×2 square where all four
letters are vowels and return the top-left cell as `"row-col"`, scanning top to
bottom, left to right. Return `"not found"` if none exists.

## Key insight that unlocked it

A 2×2 block is defined by its top-left corner `(r, c)`, so I only need to slide
that corner over the grid (stopping one short of the last row and column) and test
the four cells. The first hit in row-major order is the answer.

## Approach

Double loop over valid top-left corners; check `(r,c)`, `(r,c+1)`, `(r+1,c)`,
`(r+1,c+1)` are all vowels.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Slide 2×2 window | O(rows · cols) | O(1) |

## What tripped me up

- Bounding the loops at `r + 1 < rows` and `c + 1 < cols` so the `+1` lookups
  never run off the grid.
- Vowels are `a, e, i, o, u` — I did **not** treat `y` as a vowel (the imported
  version did; the standard challenge doesn't).

## Run it

```bash
cd Coderbyte/Matrix/VowelSquare
dotnet run
```
