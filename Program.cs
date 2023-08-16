namespace LeetCodeTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var solver = new Solution_TwoSum();
            //var result = solver.TwoSum(new int[] { -3,4,3,90},0);

            //Console.WriteLine(result.ToString());
            //var solver = new Solution_AddTwoNumbers();
            //var l1 = ListNode.FromString("2,4,3");
            //var l2 = ListNode.FromString("5,6,4");
            //var result = solver.AddTwoNumbers(l1,l2);
            //var solver = new LongestSubstring();
            //var result = solver.LengthOfLongestSubstringSpan("LengthOfLongestSubstringSpan");
            //var solver = new MedianOfTwoSortedArrays();
            //var result = solver.FindMedianSortedArrays(new int[] { 1,2 },new int[] { 3,4 });
            var solver = new TrappingRainWater();
            var result = solver.Trap(new int[] { 0,1,0,2,1,0,1,3,2,1,2,1 });

            Console.WriteLine($" {result}");
        }
    }
}