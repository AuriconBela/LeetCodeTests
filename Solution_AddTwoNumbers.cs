using System.Text;

namespace LeetCodeTests;

public class Solution_AddTwoNumbers
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var act1 = l1;
        var act2 = l2;
        var result = new ListNode();
        var pointer = result;
        var rem = 0;

        while (true)
        {
            if (act1 is not null && act2 is not null)
            {
                pointer.val = act1.val + act2.val + rem;

                if (pointer.val > 9)
                {
                    pointer.val -= 10;
                    rem = 1;
                }
                else
                {
                    rem = 0;
                }
                act1 = act1.next; 
                act2 = act2.next;
                if (act1 is null && act2 is null)
                {
                    if (rem == 1)
                    {
                        pointer.next = new ListNode(1);
                    }
                    break;
                }
            }
            else
            if (act1 is not null)
            {
                pointer.val = act1.val + rem;

                if (pointer.val > 9)
                {
                    pointer.val -= 10;
                    rem = 1;
                }
                else
                {
                    rem = 0;
                }

                act1 = act1.next; 
                if (act1 is null)
                {
                    if (rem == 1)
                    {
                        pointer.next = new ListNode(1);
                    }
                    break;
                }
            }
            else
            if (act2 is not null)
            {
                pointer.val = act2.val + rem; 

                if (pointer.val > 9)
                {
                    pointer.val -= 10;
                    rem = 1;
                }
                else
                {
                    rem = 0;
                }

                act2 = act2.next;
                if (act2 is null)
                {
                    if (rem == 1)
                    {
                        pointer.next = new ListNode(1);
                    }
                    break;
                }
            }

            pointer.next = new ListNode();
            pointer = pointer.next;
        }

        return result;
    }
}


public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null!)
    {
        this.val = val;
        this.next = next;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var act = this;

        sb.Append('[');
        while (act != null)
        {
            sb.Append(act.val.ToString());

            act = act.next;

            if (act is not null)
            {
                sb.Append(',');
            }
        }
        sb.Append(']');
        return sb.ToString();
    }

    public static ListNode FromString(string s)
    {
        var tmp = new ListNode();

        var a = s.Split(',');
        var pointer = tmp;

        for (int i = 0; i < a.Length; i++)
        {

            pointer.val = int.Parse(a[i]);
            if (i == a.Length - 1)  break;

            pointer.next = new ListNode();
            pointer = pointer.next;
        }

        return tmp;
    }
}

