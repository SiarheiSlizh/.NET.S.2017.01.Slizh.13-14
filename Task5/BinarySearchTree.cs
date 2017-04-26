using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    /// Generic data structure - binary tree
    /// </summary>
    /// <typeparam name="T">type which Node saves</typeparam>
    public class BinarySearchTree<T>
    {
        #region fields;
        private Node root;
        private int count;
        private IComparer<T> comparer;
        #endregion

        #region prop
        /// <summary>
        /// amount of nodes in tree
        /// </summary>
        public int Count
        {
            get { return count; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                count = value;
            }
        }
        #endregion

        #region ctor
        /// <summary>
        /// creates tree with default comparer
        /// </summary>
        public BinarySearchTree():this(Comparer<T>.Default)
        {
        }

        /// <summary>
        /// creates tree with default comparer and root
        /// </summary>
        /// <param name="item">specified root</param>
        public BinarySearchTree(T item):this(item,Comparer<T>.Default)
        {
        }

        /// <summary>
        /// creates tree with specified comparer
        /// </summary>
        /// <param name="comparer">specified comparer</param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparer = comparer;
            Count = 0;
        }

        /// <summary>
        /// creates tree with specified comparer and root
        /// </summary>
        /// <param name="item">specified root</param>
        /// <param name="comparer">specified comparer</param>
        public BinarySearchTree(T item, IComparer<T> comparer)
        {
            this.comparer = comparer;
            this.root = new Node(item);
            Count = 1;
        }
        #endregion

        #region API
        /// <summary>
        /// add node to tree
        /// </summary>
        /// <param name="item">element which is saved in node</param>
        public void Add(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException(nameof(item));

            Count++;

            if (ReferenceEquals(root, null))
            {
                root = new Node(item);
                return;
            }

            Node current = root;
            Node parent = null;

            while (!ReferenceEquals(current, null))
            {
                parent = current;
                if (comparer.Compare(current.Item, item) > 0)
                    current = current.Left;
                else
                    current = current.Right;
            }
            
            if (comparer.Compare(parent.Item, item) > 0)
                parent.Left = new Node(item);
            else
                parent.Right = new Node(item);
        }

        /// <summary>
        /// remove node from tree
        /// </summary>
        /// <param name="item">element which is removed from tree</param>
        /// <returns>true in case existing of specified element else false</returns>
        public bool Remove(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException(nameof(item));

            if (!Contains(item))
                return false;

            Count--;
            if (comparer.Compare(root.Item, item) == 0)
                RemoveRoot(root, item);
            else
                RemoveAt(root, item);
            return true;
        }

        /// <summary>
        /// finds element in tree
        /// </summary>
        /// <param name="item">element which is found</param>
        /// <returns>true in case existing element in treee else false</returns>
        public bool Contains(T item)
        {
            if (ReferenceEquals(item, null) || ReferenceEquals(root, null))
                throw new ArgumentNullException();

            Node current = root;

            while(!ReferenceEquals(current, null))
            {
                if (comparer.Compare(current.Item, item) == 0)
                    return true;
                else {
                    if (comparer.Compare(current.Item, item) > 0)
                        current = current.Left;
                    else
                        current = current.Right;
                }
            }

            return false;
        }      

        /// <summary>
        /// Traverse (root - left - right)
        /// </summary>
        /// <returns>sequence</returns>
        public IEnumerable<T> PreOrder() => PreOrder(root);

        /// <summary>
        /// Traverse (left - root right)
        /// </summary>
        /// <returns>sequence</returns>
        public IEnumerable<T> InOrder() => InOrder(root);

        /// <summary>
        /// Traverse (left - right - root)
        /// </summary>
        /// <returns>sequence</returns>
        public IEnumerable<T> PostOrder() => PostOrder(root);
        #endregion

        #region Private 
        private class Node
        {
            private T item;

            public T Item => item;
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(T item)
            {
                this.item = item;
            }
        }

        private void RemoveRoot(Node current, T item)
        {
            if (ReferenceEquals(current.Right, null) && ReferenceEquals(current.Left, null))
                root = null;
            else if (ReferenceEquals(current.Left, null))
            {
                root = current.Right;
                current = null;
            }
            else if (ReferenceEquals(current.Right, null))
            {
                root = current.Left;
                current = null;
            }
            else
            {
                current = current.Right;
                if (ReferenceEquals(current.Left, null))
                {
                    root = current;
                    return;
                }

                Node prevCurrent = root;
                while (!ReferenceEquals(current.Left, null))
                {
                    prevCurrent = current;
                    current = current.Left;
                }
                prevCurrent.Left = current.Right;
                current.Right = root.Right;
                current.Left = root.Left;
                root = current;
            }
        }

        private void RemoveAt(Node current, T item)
        {
            Node parent = null;
            while (comparer.Compare(current.Item, item) != 0)
            {
                parent = current;
                if (comparer.Compare(current.Item, item) > 0)
                    current = current.Left;
                else
                    current = current.Right;
            }

            //no childs
            if (ReferenceEquals(current.Right, null) && ReferenceEquals(current.Left, null))
            {
                if (comparer.Compare(parent.Item, current.Item) > 0)
                    parent.Left = null;
                else
                    parent.Right = null;
            }
            //no left child
            else if (ReferenceEquals(current.Left, null))
            {
                if (comparer.Compare(parent.Item, current.Item) > 0)
                    parent.Left = current.Right;
                else
                    parent.Right = current.Right;
            }
            //no right child
            else if (ReferenceEquals(current.Right, null))
            {
                if (comparer.Compare(parent.Item, current.Item) > 0)
                    parent.Left = current.Left;
                else
                    parent.Right = current.Left;
            }
            //both childs
            else
            {
                Node prevCurrent = current;
                Node temp = current;
                current = current.Right;

                //list
                if (ReferenceEquals(current.Left, null))
                {
                    if (comparer.Compare(parent.Item, current.Item) > 0)
                        parent.Left = current;
                    else
                        parent.Right = current;
                    current.Left = prevCurrent.Left;
                    current.Right = null;
                    return;
                }

                while (!ReferenceEquals(current.Left, null))
                {
                    prevCurrent = current;
                    current = current.Left;
                }
                //all
                if (comparer.Compare(parent.Item, current.Item) > 0)
                    parent.Left = current;
                else
                    parent.Right = current;
                current.Left = temp.Left;
                prevCurrent.Left = prevCurrent.Left.Right;
                current.Right = temp.Right;
            }
        }

        private IEnumerable<T> PreOrder(Node node)
        {
            if (ReferenceEquals(node, null))
                yield break;

            yield return node.Item;

            foreach (var item in PreOrder(node.Left))
                yield return item;

            foreach (var item in PreOrder(node.Right))
                yield return item;
        }

        private IEnumerable<T> InOrder(Node node)
        {
            if (ReferenceEquals(node, null))
                yield break;
            
            foreach (var item in InOrder(node.Left))
                yield return item;

            yield return node.Item;

            foreach (var item in InOrder(node.Right))
                yield return item;
        }

        private IEnumerable<T> PostOrder(Node node)
        {
            if (ReferenceEquals(node, null))
                yield break;

            foreach (var item in PostOrder(node.Left))
                yield return item;

            foreach (var item in PostOrder(node.Right))
                yield return item;

            yield return node.Item;
        }
        #endregion
    }
}
