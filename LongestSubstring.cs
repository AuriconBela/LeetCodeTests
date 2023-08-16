using System.Text;

namespace LeetCodeTests;

public class LongestSubstring
{
    public int LengthOfLongestSubstring(string s, out string foundString)
    {

        var act = 0;
        var maxLength = -1;
        var foundDict = new Dictionary<char, int>();
        foundString = string.Empty;

        while (act < s.Length)
        {
            var c = s[act++];

            if (!foundDict.TryGetValue(c,out var found))
            {
                foundDict[c] = act;               
            }
            else
            {
                if (foundDict.Keys.Count >= maxLength)
                {
                    maxLength = foundDict.Keys.Count;
                    foundString = FoundToString(foundDict);
                }
                    
                foundDict.Clear();
                act = found;
            }
        }

        return maxLength;
    }

    public int LengthOfLongestSubstringSpan(string s)
    {

        var act = 0;
        var maxLength = -1;
        var foundDict = new Dictionary<char, int>();

        var span = s.AsSpan();

        while (act < span.Length)
        {
            var c = span[act++];

            if (!foundDict.TryGetValue(c, out var found))
            {
                foundDict[c] = act;

                if (foundDict.Keys.Count > maxLength) maxLength = foundDict.Keys.Count;
            }
            else
            {
                foundDict.Clear();
                act = found;
            }
        }

        return maxLength;
    }

    private string FoundToString(Dictionary<char, int> dict)
    {
        var sb = new StringBuilder();
        foreach (var key in dict.Keys)
        {
            sb.Append(key);
        }
        return sb.ToString();
    }
}
