using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_TEST
{
    /// <summary>
    /// 台阶算法
    /// </summary>
    public class StepAlgorithm
    {
        /*
         上台阶，每次走一或者二阶，求n阶的所有可能路径
         */
        /*
         设n阶台阶，用递归思想，递归一般从n向前进行推导，则在n阶时，只可能是从n-1和n-2台阶走上来，
         也就是在n阶的时候，是到达n-1阶的时候的所有可能性+到达n-2阶时候的所有可能性。则设到n为f（n），
         则f（n）=f（n-1）+f（n-2），而n=1阶时f（1）=1，n=2时f（n）=2
            */
        public static int Recurse(int n)
        {
           
            if (n <= 2)
            {
                return n;
            }
            else
            {
                return Recurse(n - 1) + Recurse(n - 2);
            }
            
        }
        /*
         * 第一类数学归纳方法  设n=1时成立，则假设 n=k时成立，推导n=k+1时成立的话，则命题成立
         * 第二类数学归纳方法：
         递推思想：设
         n=1，f1=1，
         n=2,f2=2,
         n=3,f3=3,
         n=4,f4=5,
         n=5,f5=8,
         n=6,f6=13,
         则假设该计算为fn=fn-1+fn-2，
         计算  设 fk时，fk=fk-1+fk-2,则fk+1=fk+fk-1 

             */
        public static int SequenceFebnaqi(int n)
        {
            int first = 1;
            int second = 2;
            int count = 0;
            if (n==1)
            {
                return first;
            }
            if (n==2)
            {
                return second;
            }
            
            for (int i = 3; i <= n; i++)
            {
                count = first + second;
                first = second;
                second = count;
            }
            return count;

        }

        public static void test()
        {
            Console.WriteLine("test for febonaqi ---");
            
            string input ="";
            while (input.ToLower()!="quit")
            {
                Console.WriteLine("请输入一个数值n:  输入quit结束");
                input = Console.ReadLine();
                int n = int.Parse(input);
                Stopwatch watch = new Stopwatch();
                watch.Start();
                int f = 0;
                watch.Stop();
                Console.WriteLine($"递归花费时间：{watch.ElapsedMilliseconds}");
                watch.Reset();
                watch.Start();
                int s= SequenceFebnaqi(n);
                watch.Stop();
                Console.WriteLine($"sequence花费时间：{watch.ElapsedMilliseconds}");
                Console.WriteLine($"递归计算为：{f},sequence计算为：{s}");
                 input = "";
            }
            Console.WriteLine("结束计算！");
            

        }
    }
}
