# Moving Median

- **Source:** Coderbyte (Easy)
- **Pattern:** Sliding Window (secondary: Sorting)

## The problem in my own words

The first array element is a window size `k`. Streaming through the remaining
elements, report the median of the current window after each element — the window
grows until it holds `k` values, then slides forward one at a time. Join the
medians with commas.

## Key insight that unlocked it

This is a sliding window: each step adds one element and, once the window is full,
drops the oldest. The only per-step work is recomputing the median of the (small)
window.

## Approach

Maintain a `List<int>` window. Add the new element; if it exceeds `k`, remove the
front. Take the median by sorting a copy — averaging the two middle values for an
even count.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Sort each window | O(n · k log k) | O(k) |

A two-heap (max-heap / min-heap) structure could track the median in O(log k) per
step; for the small windows here, re-sorting is simpler and fast enough.

## What tripped me up

- The window **grows** before it slides — the first few outputs come from partial
  windows, not the full `k`.
- Even-sized windows use integer division on the two middle values, matching the
  imported solution's behaviour.

## Run it

```bash
cd Coderbyte/SlidingWindow/MovingMedian
dotnet run
```
