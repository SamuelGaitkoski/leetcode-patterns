namespace CodingPatterns.Coderbyte.Tree.PreorderTraversal;

using System.Text;

// Coderbyte — Preorder Traversal
// The array encodes a binary tree in heap order: the children of index i live at
// 2i+1 (left) and 2i+2 (right), and "#" marks a null node. Return the pre-order
// traversal (node, left, right) with values separated by a space.
public class Solution
{
    // Pre-order recursion straight over the heap-indexed array: visit the node,
    // recurse left, recurse right, skipping out-of-range and "#" slots.
    // O(n) time, O(h) recursion depth.
    public string PreorderTraversal(string[] tree)
    {
        var sb = new StringBuilder();
        Visit(tree, 0, sb);
        return sb.ToString().TrimEnd();
    }

    private static void Visit(string[] tree, int i, StringBuilder sb)
    {
        if (i >= tree.Length || tree[i] == "#")
            return;

        sb.Append(tree[i]).Append(' ');   // node
        Visit(tree, 2 * i + 1, sb);        // left subtree
        Visit(tree, 2 * i + 2, sb);        // right subtree
    }
}
