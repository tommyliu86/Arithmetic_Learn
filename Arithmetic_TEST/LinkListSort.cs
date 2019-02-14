using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_TEST
{
    public class ListNode
    {
        public int Data { get; set; }
        public ListNode Next { get; set; }
    }
  public  class LinkListSort
    {
        public static ListNode Reverse(ListNode list)
        {
            ListNode pre = null;
            ListNode next = null;

            while (list!=null)
            {
                //记录当前节点的下一个，链表交换涉及3个指针。前一个，当前，和后一个的位置
                next = list.Next;
                //change 链表的指向
                list.Next = pre;
                // 指针向前移动
                pre = list;
                //表示当前节点向前移动
                list = next;
            }
            return pre;
        }
        //LinkedList<int> list = new LinkedList<int>(new int[] { 1, 2, 3, 4 } );

        public static ListNode Rev(ListNode node)
        {
            if (node.Next==null)
            {
                return node;
            }
            /*单项链表的倒置，在递归中就是从第一个节点找到最后一个，
             从最后一个开始进行头插法交换单链表节点指向，
             因此递归用来先找到最后的节点，然后再开始从最后一个开始交换指针。
            */
            var Revdnode = Rev(node.Next);

            ListNode temp = node.Next;

            temp.Next = node;
            node.Next = null;

            return Revdnode;
        }

    }
}
