namespace CodingPatterns.Coderbyte.Math.OtherProducts;

// Coderbyte — Other Products
// For each position, compute the product of all the OTHER numbers, then return
// the results joined by hyphens. e.g. [1,2,3,4,5] -> "120-60-40-30-24".
public class Solution
{
    // Prefix/suffix products: res[i] = (product of everything left of i) *
    // (product of everything right of i). Two passes, no division — so it also
    // works if the array contains a zero. O(n) time, O(n) space.
    public string OtherProducts(int[] arr)
    {
        int n = arr.Length;
        long[] result = new long[n];

        long prefix = 1;
        for (int i = 0; i < n; i++)
        {
            result[i] = prefix;      // product of arr[0..i-1]
            prefix *= arr[i];
        }

        long suffix = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            result[i] *= suffix;     // multiply in product of arr[i+1..n-1]
            suffix *= arr[i];
        }

        return string.Join("-", result);
    }
}
