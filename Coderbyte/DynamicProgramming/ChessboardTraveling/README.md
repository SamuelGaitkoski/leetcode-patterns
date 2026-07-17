# Chessboard Traveling

- **Source:** Coderbyte (Hard)
- **Pattern:** Dynamic Programming (secondary: Math / combinatorics)

## The problem in my own words

Given a start `(x, y)` and destination `(a, b)` on a chessboard (with `a > x` and
`b > y`), count the paths from start to destination moving only **up** and **to
the right**. `"(1 1)(2 2)"` has `2` paths.

## Key insight that unlocked it

This is the classic grid-paths problem. The number of ways to reach a cell is the
sum of the ways to reach the cell directly below and the cell directly to the
left, because those are the only two moves that land on it. Cells on the bottom
edge or left edge have exactly one path (a straight line), which seeds the table.

## Approach

Build a `(rows+1) × (cols+1)` DP table where `rows = a - x` and `cols = b - y`.
Fill edges with 1 and interior cells with `dp[i-1][j] + dp[i][j-1]`; the answer is
the far corner.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| DP grid | O(rows · cols) | O(rows · cols) |
| Combinatorics `C(rows+cols, rows)` | O(rows) | O(1) |

The imported solution used the closed-form binomial coefficient — the DP table
here makes the "sum of two neighbours" structure explicit and is the pattern this
folder demonstrates.

## What tripped me up

- Working in **deltas**: only `a - x` and `b - y` matter, so the absolute board
  coordinates can be dropped once parsed.

## Run it

```bash
cd Coderbyte/DynamicProgramming/ChessboardTraveling
dotnet run
```
