using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_TEST_Sort

{
    public static   class Arithmetic_TEST_Sort
    {
        /*
         冒泡排序是通过相邻两个数进行比较，通过2^n次循环把每一个数字都进行遍历从而排序，在排序中有顺序和逆序两种方法，时间效率一样。

             */
        public static void Test(params  Func<IList<int>,IList<int>>[] method)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("第{0}次测试", i);
                List<int> list = new List<int>();
                Random random = new Random((int)DateTime.Now.Ticks);
                for (int j = 0; j < 20000; j++)
                {
                    list.Add(random.Next(0, 100000));
                }
                Stopwatch watch = new Stopwatch();
                watch.Start();
                Console.WriteLine("系统排序开始");
                var result1 = list.OrderBy(s => s).ToList();
                watch.Stop();
                Console.WriteLine("系统排序结束");
                Console.WriteLine("用时：{0},排序前10为：{1}", watch.ElapsedMilliseconds, string.Join(",", result1.Take(10).ToList()));
                foreach (var item in method)
                {
                    List<int> list1 = new List<int>();
                   
                    for (int j = 0; j < 20000; j++)
                    {
                        list1.Add(random.Next(0, 100000));
                    }
                    Console.WriteLine("{0}排序开始",item.Method.Name);
                    watch.Reset();
                    watch.Start();
                    var result2 = item(list1);
                    watch.Stop();
                    Console.WriteLine("{0}排序结束",item.Method.Name);
                   
                    Console.WriteLine("用时：{0},排序前10为：{1}", watch.ElapsedMilliseconds, string.Join(",", result2.Take(10).ToList()));
                }
            }
            Console.ReadKey();
        }
       
        public static IList<T> Bubbling_Sequence<T>(this IList<T> list) where T : IComparable<T>
        {
            for (int i = 0; i < list.Count-1; i++)
            {
                for (int j =0; j < list.Count-i-1; j++)
                {
                   
                    if (list[j].CompareTo(list[j+1])>0)
                    {
                        T temp = list[j];
                        list[j ] = list[j+1];
                        list[j + 1] = temp;
                    }
                }
            }
            return list;
        }
        public static IList<T> Bubbling_flashBack<T>(this IList<T> list) where T : IComparable<T>
        {
            for (int i = 0; i < list.Count-1; i++)
            {
                for (int j = list.Count-1; j > i; j--)
                {
                   
                    if (list[j].CompareTo(list[j-1])<0)
                    {
                        T temp = list[j];
                        list[j] = list[j - 1];
                        list[j - 1] = temp;

                    }
                }
            }
            return list;
        }
    }
}
