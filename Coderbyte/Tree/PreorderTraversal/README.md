# Preorder Traversal

- **Source:** Coderbyte (Medium)
- **Pattern:** Tree

> Split out of the source repo's shared `TreeGraphs.cs`, alongside
> [Symmetric Tree](../SymmetricTree/) and [Tree Constructor](../TreeConstructor/).

## The problem in my own words

The array represents a binary tree in **heap order** — the children of index `i`
are at `2i+1` and `2i+2`, and `"#"` is a null node. Return the pre-order
traversal (node → left → right), space-separated.

## Key insight that unlocked it

With heap indexing I don't need to build an actual tree of `Node` objects. The
child positions are pure arithmetic, so a recursion over indices *is* the tree
walk — skipping any index that's out of range or `"#"`.

## Approach

Recurse from index 0: append the value, recurse into `2i+1`, then `2i+2`, bailing
on null/out-of-range slots. Trim the trailing space at the end.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Index recursion | O(n) | O(h) stack |

## What tripped me up

- Both bounds matter: a child index can run past the array end *or* land on a
  `"#"`, and either one means "no node".

## Run it

```bash
cd Coderbyte/Tree/PreorderTraversal
dotnet run
```
