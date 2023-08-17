namespace LeetCodeTests;

public class TrappingRainWater
{
    private List<Range> _pools = new List<Range>();
    public int Trap(int[] height)
    {
        InnerIteration(height);
        return _pools.Count;
    }

    private void InnerIteration(int[] array)
    {
        var heighestIndex = -1;

        var leftMost = array;
        while (TryFindHighest(leftMost, ref heighestIndex))
        {
            var rightMost = SplitAt(ref leftMost, heighestIndex);

            SearchForPools(leftMost);
            SearchForPools(rightMost);

            InnerIteration(leftMost);
            InnerIteration(rightMost);
        }
    }

    private bool TryFindHighest(int[] array, ref int highestIndex)
    {
        if (array.Length < 3) { return false; }

        var maxi = int.MinValue;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > maxi)
            {
                maxi = array[i];
                highestIndex = i;
            }
        }

        return true;
    }

    private int[] SplitAt(ref int[] original, int pivot)
    {
        var p = pivot + 1;
        var tmp = original[p..];
        original = original[..pivot];
        return tmp;
    }

    private void SearchForPools(int[] array)
    {

    }
}
