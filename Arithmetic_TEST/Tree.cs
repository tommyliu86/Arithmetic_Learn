using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_TEST
{
    public class BinaryTree<T> where T:IComparable<T>
    {
        public BinaryTree<T> LeftChild { get; set; }
        public BinaryTree<T> RightChild { get; set; }
        private T _Value;
        public T Value { get { return _Value; } }

        public BinaryTree(T value)
        {
            this._Value = value;
        }
        public void AddNode(T nodeValue)
        {
            if (nodeValue.CompareTo(this._Value)>0)
            {
                if (RightChild!=null)
                {
                    RightChild.AddNode(nodeValue);
                }
                else
                {
                    RightChild = new BinaryTree<T>(nodeValue);
                }
            }
            else
            {
                if (LeftChild!=null)
                {
                    LeftChild.AddNode(nodeValue);
                }
                else
                {
                    LeftChild = new BinaryTree<T>(nodeValue);
                }
            }
        }
        public static BinaryTree<T> CreateBinaryTree(IList<T> list)
        {
            BinaryTree<T> tree = new BinaryTree<T>(list[0]);
            for (int i = 1; i < list.Count; i++)
            {
                tree.AddNode(list[i]);
            }
            return tree;
        }


        public static void Test()
        {
            IList<int> list = new List<int>();
            Random ran = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < 20000; i++)
            {
                list.Add(ran.Next(0, 20000));
            }
            BinaryTree<int> tree = BinaryTree<int>.CreateBinaryTree(list);
            List<int> midlist = tree.MiddleSort();
            Console.WriteLine("list.count:{0}", midlist.Count);
            Console.WriteLine("前20：{0}", string.Join(",", midlist.Take(20)));
            Console.WriteLine("leafcount:{0}", tree.LeafCount(tree));
            Console.WriteLine("NodeCount:{0}", tree.NodeCount(tree));

            Console.ReadKey();
        }
        public List<T> MiddleSort()
        {
            List<T> list = new List<T>();
            MiddleSort(this, list);
            return list;
        }
        private void MiddleSort(BinaryTree<T> node,IList<T> list)
        {
            if (node.LeftChild!=null)
            {
                MiddleSort(node.LeftChild, list);
            }
            list.Add(node.Value);
            if (node.RightChild!=null)
            {
                MiddleSort(node.RightChild, list);
            }
        }
        public List<T> PreSort()
        {
            List<T> list = new List<T>();
            PreSort(this, list);
            return list;
        }
        private void PreSort(BinaryTree<T> node, IList<T> list)
        {
            list.Add(node.Value);
            if (node.LeftChild!=null)
            {
                PreSort(node.LeftChild, list);
            }
            if (node.RightChild!=null)
            {
                PreSort(node.RightChild, list);
            }
        }
        public List<T> AfterSort()
        {
            List<T> list = new List<T>();
            AfterSort(this, list);
            return list;
        }
        private void AfterSort(BinaryTree<T> node, IList<T> list)
        {
            if (node.LeftChild!=null)
            {
                AfterSort(node.LeftChild, list);
            }
            if (node.RightChild != null)
            {
                AfterSort(node.RightChild, list);
            }
            list.Add(node.Value);
            
        }
        public int LeafCount(BinaryTree<T> node)
        {
            if (node==null)
            {
                return 0;
            }
            else if(node.LeftChild==null&&node.RightChild==null
                )
            {
                return 1;
            }
            else
            {
                return LeafCount(node.LeftChild) + LeafCount(node.RightChild);
            }
        }
        public int NodeCount(BinaryTree<T> node)
        {
            if (node==null)
            {
                return 0;

            }
            else
            {
                return NodeCount(node.LeftChild) + NodeCount(node.RightChild) + 1;
            }
        }
    }
}
