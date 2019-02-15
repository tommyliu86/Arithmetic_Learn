using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_TEST
{
    class RabbitInterview
    {
        /*
            兔子算法：
            设一对兔子在3个月大之后可以每个月生一对兔子，
            则有一对兔子，12个月之后有多少对兔子。
            计算：
            1月：1，
            2月：1，
            3月：2
            4月：3
            5月：5，
            总结公式为：fn=fn-1+fn-2，
            或假设 n月时为fn，则可以知道。fn=fn-1+这个月出生的兔子。而这个月出生的兔子=
            所有大于2月大的兔子。也就是n-2之前出生的兔子，
            这些兔子的数量为fn-2，得出fn=fn-1+fn-2！
            递归计算：Fn=Fn-1+Fn-2，
            递推计算：first=1，second=1.count=0；
            for(int i=3,i<=n;i++)
            {
            count=first+second;
            first=second;
            second=count;
            }
            return  count;
            算法中的思路比较重要，简单的面试算法都是递推或者递归思想的应用，遇到没有见过的，
            如果感觉是属于这样的题目，可以直接应用推导公式推导下看看是不是。
         */

    }
}
