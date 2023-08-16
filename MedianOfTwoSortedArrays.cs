namespace LeetCodeTests;

public class MedianOfTwoSortedArrays
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        MergeArrays(nums1, nums2, out var merged);
        return GetMedian(merged);
    }

    private static void MergeArrays(int[] arr1, int[] arr2, out int[] merged)
    {
        int i = 0, j = 0, k = 0, n1 = arr1.Length, n2 = arr2.Length;
        merged = new int[arr1.Length + arr2.Length];

        while (i < n1 && j < n2)
        {
            if (arr1[i] < arr2[j])
                merged[k++] = arr1[i++];
            else
                merged[k++] = arr2[j++];
        }

        while (i < n1)
            merged[k++] = arr1[i++];

        while (j < n2)
            merged[k++] = arr2[j++];
    }

    private static double GetMedian(int[] a)
    {
        var l = a.Length;

        if (l % 2 == 0)
        {
            var mid = l / 2;
            return (a[mid] + a[mid - 1])*0.5;
        }
        else
        {
            var mid = l / 2;
            return a[mid];
        }
    }
}
