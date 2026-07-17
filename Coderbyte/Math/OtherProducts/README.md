# Other Products

- **Source:** Coderbyte (Easy)
- **Pattern:** Math (prefix/suffix products)

## The problem in my own words

Build a new array where each element is the product of **all the other** elements
of the input, then return it as a hyphen-joined string. For `[1,2,3,4,5]` the
result is `"120-60-40-30-24"`.

## Key insight that unlocked it

The product of everything except position `i` is (product of everything to its
left) × (product of everything to its right). Precomputing those running products
in two passes replaces the naive "for each i, multiply the rest" (O(n²)) with an
O(n) solution — and because it never divides, a zero in the array causes no
trouble.

## Approach

1. Left-to-right pass: `result[i] = product of arr[0..i-1]`.
2. Right-to-left pass: multiply in `product of arr[i+1..n-1]`.
3. Join with `-`.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Imported (nested loops) | O(n²) | O(n) |
| Prefix/suffix products | O(n) | O(n) |

## What tripped me up

- The "product of no other elements" for a single-element array is the empty
  product, `1`.
- Using `long` for the accumulators to avoid overflow on longer arrays.

## Run it

```bash
cd Coderbyte/Math/OtherProducts
dotnet run
```
