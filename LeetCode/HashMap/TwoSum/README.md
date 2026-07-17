# 1. Two Sum

- **Link:** <https://leetcode.com/problems/two-sum/>
- **Difficulty:** Easy
- **Pattern:** HashMap

## The problem in my own words

Given an array of integers `nums` and an integer `target`, find the two
elements that add up to `target` and return their **indices**. There is exactly
one valid answer, and I can't reuse the same element twice.

## First-attempt notes

The natural first instinct is "check every pair": pick a number, then look at
every other number to see if they sum to the target. That works, but it means
for each of the `n` numbers I re-scan up to `n` others — a lot of repeated work.
The thing I kept missing at first is that I don't actually need to *search* for
the partner each time; I can *remember* what I've already seen.

## Key insight that unlocked it

For any current number, its required partner is completely determined:

```
complement = target - current
```

So instead of asking "does a matching pair exist somewhere?", I ask the much
cheaper question "have I **already seen** the exact number I still need?" A hash
map answers that in O(1). That single reframing turns the nested-loop search
into one linear pass.

## Approach(es)

### Brute force — `TwoSumBruteForce`

Two nested loops. The outer loop fixes the first element; the inner loop (which
starts at `i + 1`) tries every later element as the partner. Starting the inner
loop at `i + 1` avoids pairing an element with itself and avoids testing the
same pair twice. Correct and simple, but quadratic.

### Optimal — `TwoSumHashMap`

Keep a `Dictionary<int, int>` mapping **value → index**. The direction matters:
given the current number I want to look something up *by value* (the complement)
and get back an *index* to return.

For each element:

1. Compute `complement = target - nums[i]`.
2. **Check** whether the complement is already in the map. If so, return
   `[storedIndex, i]`.
3. Otherwise **store** `nums[i] → i` and continue.

### Why "check before insert" makes `[3, 3]` work

The order of steps 2 and 3 is the whole trick for duplicates:

| i | nums[i] | complement | map before          | action                              |
|---|---------|------------|---------------------|-------------------------------------|
| 0 | 3       | 3          | `{}`                | not found → store `{3: 0}`          |
| 1 | 3       | 3          | `{3: 0}`            | **found at 0** → return `[0, 1]`    |

Because I check *before* inserting, the first `3` is already recorded by the
time I process the second `3`, so the two indices are guaranteed to be
**distinct** (the match is always against an earlier element). If I inserted
first, the second `3` would overwrite the first one's index, and I'd risk
"finding" a number that is actually the element I'm currently standing on —
matching it with itself.

## Complexity

| Approach    | Time   | Space |
| ----------- | ------ | ----- |
| Brute force | O(n²)  | O(1)  |
| Optimal     | O(n)   | O(n)  |

The hash map trades O(n) space for the dramatic speedup — a classic
space-for-time deal, which is the defining move of the HashMap pattern.

## What tripped me up

- **Returning values vs. indices.** The problem wants *indices*, which is why
  the map stores value → index rather than the other way around.
- **The duplicate case `[3, 3]`.** It's tempting to build the whole map first
  and then scan — but that breaks self-pairing and duplicates. Checking before
  inserting is what keeps the two indices distinct.
- Remembering that the inner brute-force loop must start at `i + 1`, not `0`,
  to avoid using one element twice.

## Run it

```bash
cd HashMap/TwoSum
dotnet run
```
