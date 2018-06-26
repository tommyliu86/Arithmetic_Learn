using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_TEST
{
  public static class Quick_Sort
    {
        /*
         快速排序相当于是二分法则，通过每次把关键值，进行二分，左边为小，右边为大，进行不断地移动位置，这样划分到left==right，则进行快速排序完成，
         因此他的时间为log(n),所以它的速度会很快
             */
        public static void Test()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("第{0}次测试",i);
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
              
                    Console.WriteLine("QuickSort排序开始");
                    watch.Reset();
                    watch.Start();
                QuickSort(list, 0, list.Count - 1);
                    watch.Stop();
                    Console.WriteLine("QuickSort排序结束");
                   
                    Console.WriteLine("用时：{0},排序前10为：{1}", watch.ElapsedMilliseconds, string.Join(",", list.Take(10).ToList()));
                Console.WriteLine("QuickSort_direct排序开始");
                watch.Reset();
                List<int> list1 = new List<int>();
                for (int j = 0; j < 20000; j++)
                {
                    list1.Add(random.Next(0, 100000));
                }
                watch.Start();
                list1.QuickSort_Direct( 0, list1.Count - 1);
                watch.Stop();
                Console.WriteLine("QuickSort_direct排序开始");

                Console.WriteLine("用时：{0},排序前10为：{1}", watch.ElapsedMilliseconds, string.Join(",", list1.Take(10).ToList()));
            }
            Console.ReadKey();
        }
        private static int Division<T>(IList<T> list, int left, int right)where T:IComparable<T>
        {
            while (left<right)
            {
                //first right move left
                while (left<right && list[left].CompareTo(list[right])<=0)
                {
                    right -= 1;
                }
                var temp = list[right];
                list[right] = list[left];
                list[left] = temp;
                
                while (left<right && list[left].CompareTo(list[right])<=0)
                {
                    left += 1;
                }
                var temp1 = list[right];
                list[right] = list[left];
                list[left] = temp1;
            }
            return left;
        }
        public static void QuickSort<T>(this IList<T> list) where T : IComparable<T>
        {
            int left = 0;int right = list.Count - 1;
            QuickSort(list, left, right);
        }
        private static void QuickSort<T>(IList<T> list,int left,int right) where T:IComparable<T>
        {
            if (left<right)
            {
                int temp = Division(list, left, right);
                QuickSort(list, left, temp - 1);
                QuickSort(list, temp + 1, right);
            }
        }
        public static void QuickSort_Direct<T>(this List<T> list, int left, int right) where T : IComparable<T>
        {
            int l = left;
            int r = right;
            if (left < right)
            {

                while (left < right)
                {
                    //first right move left
                    while (left < right && list[left].CompareTo(list[right]) <= 0)
                    {
                        right -= 1;
                    }
                    var temp = list[right];
                    list[right] = list[left];
                    list[left] = temp;

                    while (left < right && list[left].CompareTo(list[right]) <= 0)
                    {
                        left += 1;
                    }
                    var temp1 = list[right];
                    list[right] = list[left];
                    list[left] = temp1;
                }



                QuickSort_Direct(list, l, left - 1);
                QuickSort_Direct(list, left + 1, r);
            }
        }
    }
}
