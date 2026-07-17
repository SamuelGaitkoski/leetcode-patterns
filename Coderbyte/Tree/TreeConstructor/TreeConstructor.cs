namespace CodingPatterns.Coderbyte.Tree.TreeConstructor;

using System.Collections.Generic;

// Coderbyte — Tree Constructor
// The array holds "(child,parent)" pairs. Return "true" if they form a valid
// binary tree: no node has more than 2 children, no node has more than 1 parent,
// and there is exactly one root. e.g. ["(1,2)","(2,4)","(5,7)","(7,2)","(9,5)"]
// -> "true".
public class Solution
{
    // Build parent/child maps from the pairs, then check the three tree rules.
    // O(n) time, O(n) space.
    public string TreeConstructor(string[] pairs)
    {
        var parentsOf = new Dictionary<int, HashSet<int>>();  // child -> its parents
        var children = new Dictionary<int, List<int>>();      // parent -> its children
        var nodes = new HashSet<int>();

        foreach (string pair in pairs)
        {
            var (child, parent) = Parse(pair);
            nodes.Add(child);
            nodes.Add(parent);

            if (!parentsOf.TryGetValue(child, out var set))
            {
                set = new HashSet<int>();
                parentsOf[child] = set;
            }
            set.Add(parent);

            if (!children.TryGetValue(parent, out var kids))
            {
                kids = new List<int>();
                children[parent] = kids;
            }
            kids.Add(child);
        }

        // Rule: no child may have more than one parent.
        foreach (var set in parentsOf.Values)
            if (set.Count > 1)
                return "false";

        // Rule: no parent may have more than two children.
        foreach (var kids in children.Values)
            if (kids.Count > 2)
                return "false";

        // Rule: exactly one root (a node that is never a child).
        int root = int.MinValue, roots = 0;
        foreach (int node in nodes)
        {
            if (!parentsOf.ContainsKey(node))
            {
                root = node;
                roots++;
            }
        }
        if (roots != 1)
            return "false";

        // Rule: every node must be reachable from that root — otherwise a
        // separate component (e.g. a disconnected cycle) would slip through even
        // though the degree checks above pass.
        var reached = new HashSet<int> { root };
        var queue = new Queue<int>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            if (children.TryGetValue(node, out var kids))
            {
                foreach (int kid in kids)
                    if (reached.Add(kid))
                        queue.Enqueue(kid);
            }
        }

        return reached.Count == nodes.Count ? "true" : "false";
    }

    // "(1,2)" -> (child: 1, parent: 2).
    private static (int Child, int Parent) Parse(string pair)
    {
        string[] parts = pair.Trim('(', ')').Split(',');
        return (int.Parse(parts[0].Trim()), int.Parse(parts[1].Trim()));
    }
}
