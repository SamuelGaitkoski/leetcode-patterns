# 14. Longest Common Prefix

- **Link:** <https://leetcode.com/problems/longest-common-prefix/>
- **Difficulty:** Easy
- **Pattern:** Strings

## The problem in my own words

Given an array of strings, return the longest string that is a prefix of *every*
one of them. If they share no starting characters, return `""`. Constraints:
1–200 strings, each 0–200 lowercase letters (a string can be empty).

## First-attempt notes

My instinct was a nested loop, but I had the loops backwards: my outer loop walked
whole strings and the inner loop walked characters, and I left a comment on line 7
trying to describe "compare that a letter is present in all strings." That comment
is actually the vertical-scanning idea — I just needed to flip the loops so the
**outer loop walks character positions** and the **inner loop walks the other
strings**, checking that one position across all of them.

## Key insight that unlocked it

A prefix has to match at *every* position in *every* string. So instead of hunting
for characters "in common" somewhere inside the strings, I fix a position (taking
the first string as the reference) and verify all the other strings have the same
character there. The first position that fails in any string is where the common
prefix ends — everything before it is the answer.

## Approach(es)

### Vertical scanning (mine)
Loop over positions of `strs[0]`. At each position, compare that character against
the same position in every other string. Stop and return `strs[0].Substring(0, pos)`
the moment a string is too short or differs. If nothing ever mismatches, the whole
first string is the prefix. The "too short" guard also handles the empty-string case
for free (length 0 stops us immediately at position 0 → `""`).

### Horizontal scanning
Assume the whole first string is the prefix, then shrink it against each next string
until that string `StartsWith` the running prefix. Bail out early if the prefix
shrinks to `""`.

### Sort trick
Sort the array alphabetically; the two most-different strings end up first and last,
so the common prefix of all strings equals the common prefix of just those two.

### Divide and conquer
`LCP(a..b) = LCP( LCP(a..mid), LCP(mid+1..b) )`. Recurse to single strings, then
merge the pairwise prefixes back up.

### Binary search on prefix length
The answer length is in `[0, shortest length]`, and "all strings share a prefix of
length L" is monotone (true for L implies true for every shorter length). Binary
search for the largest working L.

## Complexity

Let `S` = total characters across all strings, `n` = number of strings,
`m` = length of the longest string.

| Approach            | Time         | Space       |
| ------------------- | ------------ | ----------- |
| Vertical scanning   | O(S)         | O(1)        |
| Horizontal scanning | O(S)         | O(1)        |
| Sort trick          | O(n·log n·m) | O(1)        |
| Divide and conquer  | O(S)         | O(m·log n)  |
| Binary search       | O(S·log m)   | O(1)        |

## What tripped me up

- **The loops were inside out.** Walking whole strings on the outside felt natural
  but made the "is this char common to all?" check awkward. Positions on the outside
  is the whole trick.
- **Reading past the end of a shorter string.** Without the `pos >= strs[i].Length`
  guard, `strs[i][pos]` throws `IndexOutOfRangeException` as soon as one string is
  shorter than the reference. That same guard is what makes the empty-string case
  (`[""]`, `["", "b"]`) work without a special branch.
- **Binary search midpoint.** Rounding the midpoint down can stall the loop when
  `hi == lo + 1`; rounding **up** (`lo + (hi - lo + 1) / 2`) guarantees progress.
- **The sort approach reorders the input.** Fine for correctness (the prefix is
  order-independent), but the test harness hands each approach its own array copy so
  one approach's sort doesn't disturb the next.
