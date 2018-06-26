using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_TEST
{
  static  class Select_Sort
    {
        /*
         直接排序是从前向后，每次取到第i个值，把i后面的所有数中的最小值找到，然后交换位置，这样就可以保证把数依次排列了。
         注意最好是用记录下标的方法，然后在寻找到i后的值之后，再进行交换，这样可以减少交换次数。直接交换和一次交换的耗时刚好差2倍
             */
        public static void Test()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("第{0}次测试", i);
                Stopwatch watch = new Stopwatch();
                Random random = new Random((int)DateTime.Now.Ticks);
                List<int> list = new List<int>();
                for (int j = 0; j < 20000; j++)
                {
                    list.Add(random.Next(0, 100000));
                }
                watch.Start();
                Console.WriteLine("系统排序开始");
                var result1 = list.OrderBy(s => s).ToList();
                watch.Stop();
                Console.WriteLine("系统排序结束");
                Console.WriteLine("用时：{0},排序前10为：{1}", watch.ElapsedMilliseconds, string.Join(",", result1.Take(10).ToList()));

                Console.WriteLine("Select_SortMult排序开始");
                watch.Reset();
                watch.Start();
                list.select_sort_Mult();
                watch.Stop();
                Console.WriteLine("Select_SortMult排序结束");

                Console.WriteLine("用时：{0},排序前10为：{1}", watch.ElapsedMilliseconds, string.Join(",", list.Take(10).ToList()));
                Console.WriteLine("Select_Sort_one排序开始");
                watch.Reset();
                List<int> list1 = new List<int>();
                for (int j = 0; j < 20000; j++)
                {
                    list1.Add(random.Next(0, 100000));
                }
                watch.Start();
                list1.Select_Sort_one();
                watch.Stop();
                Console.WriteLine("Select_Sort_one排序结束");

                Console.WriteLine("用时：{0},排序前10为：{1}", watch.ElapsedMilliseconds, string.Join(",", list1.Take(10).ToList()));
            }
            Console.ReadKey();
        }
        public static void select_sort_Mult<T>(this IList<T> Ts) where T:IComparable<T>
        {
            for (int i = 0; i < Ts.Count-1; i++)
            {
                for (int j = i; j < Ts.Count-1; j++)
                {
                    if (Ts[i].CompareTo(Ts[j])>0)
                    {
                        var temp = Ts[i];
                        Ts[i] = Ts[j];
                        Ts[j] = temp;
                    }
                }
            }
        }
        public static void Select_Sort_one<T>(this IList<T> t) where T : IComparable<T>
        {
            for (int i = 0; i < t.Count-1; i++)
            {
                int temindex = i;
                for (int j = i; j < t.Count; j++)
                {
                    if (t[temindex].CompareTo(t[j])>0)
                    {
                        temindex = j;
                    }
                }
                T temp = t[i];
                t[i] = t[temindex];
                t[temindex] = temp;
            }
        }
    }
}
