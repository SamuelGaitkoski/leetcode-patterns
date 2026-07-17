# Matrix Determinant

- **Source:** Coderbyte (Hard)
- **Pattern:** Matrix (secondary: Recursion)

## The problem in my own words

The input is a flat array of integer strings with `"<>"` markers separating rows.
Rebuild the matrix and return its determinant; if the matrix isn't square, return
`-1`. Sizes go up to 6×6.

## Key insight that unlocked it

The determinant has a naturally recursive definition — **Laplace (cofactor)
expansion**: pick the first row, and for each entry multiply it by the determinant
of the submatrix that remains after deleting its row and column, with alternating
signs. The recursion bottoms out at the 1×1 (`the value`) and 2×2 (`ad − bc`)
cases.

## Approach

1. Parse rows by splitting on `"<>"`.
2. If any row's length ≠ the row count, it's not square → `-1`.
3. Recurse: expand along row 0, summing `(-1)^col · m[0][col] · det(minor)`.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Cofactor expansion | O(n!) | O(n²) |

Cofactor expansion is exponential, but the 6×6 cap keeps it well within budget.
(Gaussian elimination would be O(n³) but needs fraction/rounding care to stay
exact on integers.)

## What tripped me up

- The **alternating sign** across the first row (`+ − + − …`) — dropping it gives
  the permanent, not the determinant.
- Building each minor by skipping row 0 and the pivot column, then recursing.
- The last row of the input has no trailing `"<>"`, so it must be flushed after
  the parse loop.

## Run it

```bash
cd Coderbyte/Matrix/MatrixDeterminant
dotnet run
```
