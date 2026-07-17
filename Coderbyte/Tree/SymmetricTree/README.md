# Symmetric Tree

- **Source:** Coderbyte (Medium)
- **Pattern:** Tree

> Split out of the source repo's shared `TreeGraphs.cs`, alongside
> [Preorder Traversal](../PreorderTraversal/) and [Tree Constructor](../TreeConstructor/).

## The problem in my own words

The array encodes a binary tree in heap order (`"#"` = null). Decide whether the
tree is a mirror image of itself and return `"true"`/`"false"`.

## Key insight that unlocked it

Symmetry is a property of **two** subtrees, not one: the left subtree of the root
must mirror the right subtree. Two subtrees mirror when their roots match and,
crucially, the *outer* children pair up and the *inner* children pair up —
left-of-A with right-of-B, right-of-A with left-of-B.

## Approach

Recurse on index pairs `(i, j)` starting from the root's two children `(1, 2)`.
Both null → mirrored; exactly one null or unequal values → not; otherwise recurse
crosswise: `(2i+1, 2j+2)` and `(2i+2, 2j+1)`.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Paired recursion | O(n) | O(h) stack |

## What tripped me up

- The **cross** pairing is the whole trick — comparing left-with-left would test
  for *identical* subtrees, not *mirrored* ones.

## Run it

```bash
cd Coderbyte/Tree/SymmetricTree
dotnet run
```
