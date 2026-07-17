# Minimum Window Substring

- **Source:** Coderbyte (Medium)
- **Pattern:** Sliding Window (secondary: HashMap)

## The problem in my own words

Given two strings `N` and `K`, find the shortest substring of `N` that contains
every character of `K`, counting duplicates. For `["aaabaaddae", "aed"]` the
answer is `"dae"`.

## Key insight that unlocked it

This is the canonical minimum-window problem. Keep a count of what `K` still
needs and a count of what the current window holds. Grow the window on the right
until every required character is satisfied, then greedily shrink from the left,
recording the smallest window that stays valid.

## Approach

`need` = character counts of `K`; `formed` tracks how many distinct requirements
the window currently meets. Expand `right`; whenever `formed == required`,
contract `left` while updating the best window, dropping below a requirement to
stop.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Imported (all substrings) | O(n³) | O(n) |
| Sliding window | O(\|N\| + \|K\|) | O(\|K\|) |

## What tripped me up

- Tracking counts, not just presence: a window needs enough copies of a repeated
  character (`"aad"` needs two `a`s), so `formed` only increments when a count
  **reaches** the required amount.

## Run it

```bash
cd Coderbyte/SlidingWindow/MinimumWindowSubstring
dotnet run
```
