# Find Intersection

- **Source:** Coderbyte (Easy)
- **Pattern:** Two Pointers (secondary: HashMap)

## The problem in my own words

Two comma-separated lists of numbers arrive as strings, each already sorted
ascending. Return the values that appear in **both**, sorted and comma-joined, or
`"false"` if there's no overlap.

## Key insight that unlocked it

The lists are **already sorted**, which is the setup for a two-pointer merge:
walk both at once and advance whichever value is smaller. Equal values are matches.
That's one linear pass instead of comparing every pair.

## Approach

Parse each list to `int[]`. Run pointers `i, j`: on equality record and advance
both; otherwise advance the pointer at the smaller value. Empty result → `"false"`.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Imported (nested loops) | O(n · m) | O(n) |
| Two-pointer merge | O(n + m) | O(1)\* |

\* Beyond the output list.

## What tripped me up

- The lists come with a space after each comma (`"1, 3, 4"`), so parsing has to
  `Trim` before `int.Parse`.
- A HashSet of one list would also work in O(n + m); two pointers exploits the
  sortedness to avoid the extra set.

## Run it

```bash
cd Coderbyte/TwoPointers/FindIntersection
dotnet run
```
