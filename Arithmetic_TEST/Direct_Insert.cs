using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_TEST
{
  public static   class Direct_Insert
    {
        /*
         直接插入法：原理为从前向后，依次拿当前的数和前面的所有数从后向前做对比，找到当前数的位置后直接插入进去，类似于理牌，：
          最左一张牌是3，第二张牌是5，第三张牌又是3，赶紧插到第一张牌后面去，第四张牌又是3，大喜，赶紧插到第二张后面去，
            第五张牌又是3，狂喜，哈哈，一门炮就这样产生了。
            在该过程中主要涉及到所有的大于当前数的数都需要做向右的偏移，也就是插入的话需要移位！
             */
        public static void DirectInsert<T>(this IList<T> list) where T:IComparable<T>
        {
            for (int i = 1; i < list.Count; i++)
            {
                var temp = list[i];
                int j;
                for ( j = i-1; j >=0&&list[j].CompareTo(temp)>0; j--)
                {
                   
                        list[j + 1] = list[j];
                    
                }
                list[j+1] = temp;
            }
        }
        public static void DirectInsert_1<T>(this IList<T> list) where T : IComparable<T>
        {
            for (int i = 1; i < list.Count; i++)
            {
                var temp = list[i];
                
                for (int j = i - 1; j >= 0 ; j--)
                {
                    if (list[j].CompareTo(temp)>0)
                    {
                        list[j + 1] = list[j];
                    }
                    else
                    {
                        list[j + 1] = temp;
                        break;
                    }
                    if (j==0)
                    {
                        list[j] = temp;
                    }

                }
                
            }
        }
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

                Console.WriteLine("直接插入排序开始");
                watch.Reset();
                watch.Start();
                list.DirectInsert();
                watch.Stop();
                Console.WriteLine("直接插入排序结束");

                Console.WriteLine("用时：{0},排序前10为：{1}", watch.ElapsedMilliseconds, string.Join(",", list.Take(10).ToList()));
                Console.WriteLine("直接插入排序_1开始");
                watch.Reset();
                List<int> list1 = new List<int>();
                for (int j = 0; j < 20000; j++)
                {
                    list1.Add(random.Next(0, 100000));
                }
                watch.Start();
                list1.DirectInsert_1();
                watch.Stop();
                Console.WriteLine("直接插入排序_1结束");

                Console.WriteLine("用时：{0},排序前10为：{1}", watch.ElapsedMilliseconds, string.Join(",", list1.Take(10).ToList()));

            }
            Console.ReadKey();
        }
    }
}
