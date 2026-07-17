namespace CodingPatterns.Coderbyte.Tree.SymmetricTree;

// Coderbyte — Symmetric Tree
// The array encodes a binary tree in heap order (children of i at 2i+1 / 2i+2,
// "#" for null). Return "true" if the tree is a mirror image of itself.
// e.g. ["1","2","2","3","#","#","3"] -> "true".
public class Solution
{
    // A tree is symmetric when the root's left subtree mirrors its right subtree.
    // Compare them in lockstep: outer-left against outer-right and inner-left
    // against inner-right. O(n) time, O(h) recursion depth.
    public string SymmetricTree(string[] tree)
    {
        bool symmetric = tree.Length == 0 || IsMirror(tree, 1, 2);
        return symmetric ? "true" : "false";
    }

    private static bool IsMirror(string[] t, int i, int j)
    {
        bool iNull = i >= t.Length || t[i] == "#";
        bool jNull = j >= t.Length || t[j] == "#";

        if (iNull && jNull)
            return true;                    // both empty -> still mirrored
        if (iNull || jNull)
            return false;                   // one empty, one not -> asymmetric
        if (t[i] != t[j])
            return false;                   // values differ

        // Mirror: left-of-i pairs with right-of-j, and right-of-i with left-of-j.
        return IsMirror(t, 2 * i + 1, 2 * j + 2)
            && IsMirror(t, 2 * i + 2, 2 * j + 1);
    }
}
