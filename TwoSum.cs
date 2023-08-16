namespace LeetCodeTests;

public class Solution_TwoSum
{
    public int[] TwoSum(int[] nums, int target)
    {
        var result = new int[2];
        //var withIndices = nums.Select((item, i) => new { number = item, index = i }).ToArray();
        //var substracted = withIndices.Select(x => new { number = target - x.number, index = x.index}).ToArray();

        var withIndices = nums.Select((item, i) => new { number = item, index = i });
        var substracted = withIndices.Select(x => new { number = target - x.number, index = x.index});        

        foreach (var item in withIndices)
        {
            var found = -1;

            foreach (var x in substracted){
             if(x.number == item.number && x.index != item.index){
                found = x.index;
                break;
             }   
            }

            if (found > -1)
            {
                result[0] = item.index;
                result[1] = found;
                break;
            }
        }
/*
        for (int i = 0; i < withIndices.Length; i++)
        {
            var found = -1;

            foreach (var x in substracted){
             if(x.number == withIndices[i].number && x.index != withIndices[i].index){
                found = x.index;
                break;
             }   
            }

            if (found > -1)
            {
                result[0] = withIndices[i].index;
                result[1] = found;
                break;
            }
        }*/
        return result;
    }
}
