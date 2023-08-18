namespace LeetCodeTests;

public class TrappingRainWater
{
    private readonly List<int[]> _pools = new();

    public int Trap(int[] height)
    {
        InnerIteration(height);
        return ResultCalc();
    }

    private void InnerIteration(int[] array)
    {
        var heighestIndex = -1;

        //if (IsPlateu(array)) return;

        while (TryFindHighest(array, ref heighestIndex))
        {
            var rightIndex = heighestIndex + 1;
            var foundPool = false;
            while (rightIndex < array.Length)
            {
                if (IsPool(array, heighestIndex, rightIndex))
                {
                    foundPool = true;
                    break;
                }
                rightIndex++;
            }

            if (foundPool)
            {
                SplitAt(ref array, heighestIndex, rightIndex, out var middle, out var rightMost);
                _pools.Add(middle);

                InnerIteration(array);
                InnerIteration(rightMost);
                break;

            }
            else
            {
                if (array[heighestIndex] == 0) return;
                array[heighestIndex]--;
            }
        }

    }

    private static bool TryFindHighest(int[] array, ref int highestIndex)
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

    private static void SplitAt(ref int[] original, int splitStart, int splitEnd, out int[] middleArray, out int[] rightArray)
    {
        var s = splitStart + 1;
        var e = splitEnd + 1;

        middleArray = original[splitStart..e];
        rightArray = original[splitEnd..];
        original = original[..s];
    }

    private static bool IsPool(int[] array, int startIndex, int endIndex)
    {
        if (endIndex - startIndex < 2) return false;

        if (array[startIndex] != array[endIndex]) return false;

        for (var i = startIndex + 1; i < endIndex; i++)
        {
            if (array[i] >= array[startIndex]) return false;
        }

        return true;
    }

    //private static bool IsPlateu(int[] array)
    //{
    //    if (array.Length < 2) return true;

    //    var first = array[0];
    //    for (int i = 1; i < array.Length; i++)
    //    {
    //        if (array[i] != first) return false;
    //    }
    //    return true;
    //}

    private static int PoolDepth(int[] array)
    {
        var result = 0;
        var maxi = array[0];
        for (int i = 1; i < array.Length - 1; i++)
        {
            result += maxi - array[i];
        }
        return result;
    }

    private int ResultCalc()
    {
        var result = 0;
        foreach (var i in _pools)
        {
            result += PoolDepth(i);
        }
        return result;
    }
}
