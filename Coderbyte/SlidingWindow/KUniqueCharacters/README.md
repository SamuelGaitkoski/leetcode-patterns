# K Unique Characters

- **Source:** Coderbyte (Medium)
- **Pattern:** Sliding Window (secondary: HashMap)

## The problem in my own words

The first character is a number `k`. In the rest of the string, find the longest
substring containing at most `k` distinct characters; on a tie, return the first.
For `"2aabbacbaa"` the answer is `"aabba"`.

## Key insight that unlocked it

"Longest substring with at most k distinct characters" is a textbook variable-size
sliding window. A count map tells me how many distinct characters the window holds;
whenever that exceeds `k`, I shrink from the left until it's valid again.

## Approach

Expand `right`, incrementing the count of the new character. While the map has
more than `k` keys, decrement/evict from `left`. After each step, record the
window if it's the longest so far (strict `>` keeps the first tie).

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Sliding window | O(n) | O(k) |

The imported version generated every substring and counted distinct characters —
O(n²) or worse. The window does it in one pass.

## What tripped me up

- Evicting a character key from the map when its count hits zero — otherwise
  `counts.Count` overstates the distinct total and the window never grows back.
- The leading character is `k`, so the search string is `str.Substring(1)`.

## Run it

```bash
cd Coderbyte/SlidingWindow/KUniqueCharacters
dotnet run
```
