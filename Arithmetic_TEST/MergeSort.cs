using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Arithmetic_TEST
{
    public static class Mergesort
    {
        public static void Main_Test()
        {
            for (int i = 0; i < 5; i++)
            {
                Test();
               
            }
            Console.WriteLine("game over");
            Console.ReadKey();
        }
        public static void Test()
        {
            List<int> list = new List<int>();
            Random ran = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < 100000; i++)
            {
                list.Add(ran.Next(1000, 1000000));
            }
            Console.WriteLine("测试开始");
            Stopwatch watch = new Stopwatch();
            Console.WriteLine("---快速排序---");
            watch.Start();
            var result = list.OrderBy(s => s);
            watch.Stop();
            Console.WriteLine("用时：{0},前十个：{1}", watch.ElapsedMilliseconds, string.Join(",", result.Take(10)));
            watch.Reset();
            Console.WriteLine("---归并排序---");
            watch.Start();
            list.MergeSort();
            watch.Stop();
            Console.WriteLine("用时：{0},前十个：{1}", watch.ElapsedMilliseconds, string.Join(",", list.Take(10)));
            


        }

        public static void MergeArray<T>(IList<T> listleft, IList<T> listright,out IList<T> list) where T : IComparable<T>
        {
            list = new List<T>();

            int left = listleft.Count;
            int right = listright.Count;
            int ileft = 0;
            int iright = 0;
            int ilist = 0;
            while (ileft<left&&iright<right)
            {
                if (listleft[ileft].CompareTo(listright[iright])>0)
                {
                    list[ilist++] = list[iright++];
                }
                else
                {
                    list[ilist++] = list[ileft];
                }
            }
            while (ileft<left)
            {
                list[ilist++] = list[ileft++];
            }
            while (iright<left)
            {
                list[ilist++] = list[iright++];
            }

        }
        /*
         并归排序的原理是分治算法的思想，即，两个有序数列可以通过一个临时数列作为中间保存，实现从前向后以此插入到临时数列中从而实现排序
         那么一个无序的数列，可以通过递归不断划分，最后划分为最小一个数的时候，也就是相当于所有的数列都是有序的（只有一个数的数列肯定有序！）
         这时候，再通过有序数列的排序方法，在递归的最后向上返回时不断地排序，就可以实现数列的排序！
         可以参考快速排序，快速排序通过不断地寻找中间值，在寻找中间值的时候同时对左右进行交换，寻找到中间值的时候也实现了数列两边的大小分配
         所以是先排序后递归，最后left==right表示二分到了最小一个数，表示排序完毕。
         而并归则是先进行最小数列的切割，也是二分法的应用，在切割到left==right的时候，表明已经获取到最小数列（1个数的数列）,递归完成，向上返回的时候，进行在改方法中
         进行有序数列交替排序的计算，最后递归的最外层也就是把一个无序数列切割为两个有序数列的排序！
             */
        private static void MergeArray<T>(IList<T> list, int first, int mid, int last, IList<T> temp) where T : IComparable<T>
        {
            int i = first; int j = mid + 1;
            int m = mid;int n = last;
            int k = 0;
            while (i<=m&&j<=n)
            {
                if (list[i].CompareTo(list[j])>0)
                {
                    temp[k++] = list[j++];
                }
                else
                {
                    temp[k++] = list[i++];
                }
            }
            while (i<=m)
            {
                temp[k++] = list[i++];
            }
            while (j<=n)
            {
                temp[k++] = list[j++];
            }
            for (int o = 0; o < k; o++)
            {
                list[first + o] = temp[o];
            }
        }
        private static void MergeSort<T>(IList<T> list, int first,  int last, IList<T> temp) where T : IComparable<T>
        {
            if (first<last)
            {
                int mid = (first + last) / 2;
                MergeSort(list, first,  mid, temp);
                MergeSort(list, mid + 1, last, temp);
                MergeArray(list, first, mid, last, temp);
            }
        }
        public static void MergeSort<T>(this IList<T> list) where T : IComparable<T>
        {
            T[] temp = new T[list.Count];
            MergeSort(list, 0, list.Count-1, temp);
        }
    }
}
