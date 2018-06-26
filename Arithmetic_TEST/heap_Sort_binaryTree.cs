using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_TEST
{
    /*
     * 堆排序，或者说是二叉树构建进行排序
     主要的思路是使用二叉树，和二叉树一起学
         */
   public static   class heap_Sort_binaryTree
    {
        public class BinaryTree<T> where T : IComparable<T>
        {
            private T _Value;
            private BinaryTree<T> _LeftNode;
            private BinaryTree<T> _RightNode;
            public BinaryTree(T nodeValue)
            {
                _LeftNode = _RightNode = null;
                this._Value = nodeValue;
            }
            public void Add(T nodeValue)
            {
                if (nodeValue.CompareTo(this._Value)>0)
                {
                    if (this._RightNode==null)
                    {
                        this._RightNode = new BinaryTree<T>(nodeValue);
                    }
                    else
                    {
                        this._RightNode.Add(nodeValue);
                    }
                }
                else
                {
                    if (this._LeftNode==null)
                    {
                        this._LeftNode = new BinaryTree<T>(nodeValue);
                    }
                    else
                    {
                        this._LeftNode.Add(nodeValue);
                    }
                }
            }
            public static BinaryTree<T> AddRange(IList<T> list)
            {
                if (list==null||list.Count<=0)
                {
                    return null;

                }
                else
                {
                    BinaryTree<T> root = new BinaryTree<T>(list[0]);
                    for (int i = 1; i < list.Count; i++)
                    {
                        root.Add(list[i]);
                    }
                    return root;
                }
            }
            public void MidOrder( BinaryTree<T> node,IList<T> list)
            {
                if (node!=null)
                {
                    if (node._LeftNode != null)
                    {
                        MidOrder(node._LeftNode, list);
                    }
                    list.Add(node._Value);
                    if (node._RightNode != null)
                    {
                        MidOrder(node._RightNode, list);
                    }
                }
                
            }
        }
    }
}
