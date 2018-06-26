using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_TEST
{
 public static   class Shell_Sort
    {
        public static void ShellSort<T>(this IList<T> list) where T : IComparable<T>
        {
            int step = list.Count / 2;
            while (step >= 1)
            {

                /*
                 * 希尔排序是直接插入法的优化版本。
                 这种遍历后面的数据为第一层循环的方式是每一次的i就是有序和无序的分界线，因此每次都是把i前面的数据进行查找大小然后插入。
                 所以内层的j是j--；
                 这是挨个取得数据，然后根据step进行向前获取每一个数组中的元素。
                 */
                for (int i = step; i < list.Count; i++)
                {
                    T temp = list[i];
                    int j;
                    for (j = i-step ; j >= 0 && list[j].CompareTo(temp) >0; j =j- step)
                    {
                        list[j+step ] = list[j];
                    }
                    list[j + step] = temp;
                }
                step = step / 2;
            }
        }
        public static void ShellSort_1<T>(this IList<T> list) where T : IComparable<T>
        {
            int step = list.Count / 2;
            while (step >= 1)
            {
                /*
                 这种遍历以每一个step分割成了多少个数组为第一层。每次的i就是每个分组的第一个数据项。
                 在第二层中每次以step为步长先后查找所有的数组元素，一直查找到list.count。因此每一次获取到的j就是数组的无序和有序的分界线。
                第一层+第二层是所有的数据遍历，因此需要走完全，不能在循环条件中添加分界线的大小对比，
                对比需要放在第二层内，如果当前获取的值小于前一个，则向前查找该step分割数组，做直接插入。
                因此需要有第三层，进行向前查找所有的该分组内的元素，并且进行插入排序。
                 
                 */

                for (int i = 0; i < step; i++)
                {

                    for (int j = i + step; j < list.Count; j += step)
                    {
                        if (list[j - step].CompareTo(list[j]) > 0)
                        {


                            T temp = list[j];
                            int k;
                            for (k = j - step; k >= 0 && list[k].CompareTo(temp) > 0; k -= step)
                            {
                                list[k + step] = list[k];
                            }
                            list[k + step] = temp;
                        }
                    }
                }
                step = step / 2;
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

                Console.WriteLine("希尔排序");
                watch.Reset();
                watch.Start();
                list.ShellSort();
                watch.Stop();
                Console.WriteLine("希尔排序");

                Console.WriteLine("用时：{0},排序前10为：{1}", watch.ElapsedMilliseconds, string.Join(",", list.Take(10).ToList()));
                Console.WriteLine("希尔——1排序");
                watch.Reset();
                List<int> list1 = new List<int>();
                for (int j = 0; j < 20000; j++)
                {
                    list1.Add(random.Next(0, 100000));
                }
                watch.Start();
                list1.ShellSort_1();
                watch.Stop();
                Console.WriteLine("希尔——1排序");

                Console.WriteLine("用时：{0},排序前10为：{1}", watch.ElapsedMilliseconds, string.Join(",", list1.Take(10).ToList()));

            }
            Console.ReadKey();
        }
    }
}
