using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Class works with set of certain reference type
    /// </summary>
    /// <typeparam name="T">type of elements in set</typeparam>
    public class Set<T>: IEnumerable<T> where T : class
    {
        #region fields
        /// <summary>
        /// Array of reference type
        /// </summary>
        private T[] items;
        
        /// <summary>
        /// Current size of set
        /// </summary>
        private int size;

        /// <summary>
        /// Comparer which helps to equal elements by different ways
        /// </summary>
        private IEqualityComparer<T> comparer;
        #endregion

        #region prop
        /// <summary>
        /// return and set current size of set
        /// </summary>
        public int Count
        {
            get { return size; }
            private set { size = value; }
        }

        /// <summary>
        /// return current capacity of set
        /// </summary>
        public int Capacity => items.Length;
        #endregion

        #region ctor
        /// <summary>
        /// Creates set with default comparer and capacity - 2
        /// </summary>
        public Set():this(2)
        {
        }

        /// <summary>
        /// Creates set with default comparer and specified capacity
        /// </summary>
        /// <param name="capacity">default capacity of set</param>
        public Set(int capacity)
        {
            items = new T[capacity];
            comparer = EqualityComparer<T>.Default;
        }

        /// <summary>
        /// Creates set with default capacity - 2 and specified comparer
        /// </summary>
        /// <param name="eq">comparer which is used for equality two elements</param>
        public Set(IEqualityComparer<T> eq):this(2,eq)
        {
        }

        /// <summary>
        /// Created set with specified capacity and comparer
        /// </summary>
        /// <param name="capacity">default capacity of set</param>
        /// <param name="eq">comparer which is used for equality two elements </param>
        public Set(int capacity, IEqualityComparer<T> eq)
        {
            items = new T[capacity];
            comparer = eq;
        }
        #endregion

        #region API
        /// <summary>
        /// Add element to set if it doesn't exist there
        /// </summary>
        /// <param name="item">element</param>
        /// <returns>true in case adding element into set else false</returns>
        public bool Add(T item)
        {
            if (this.Contains(item))
                return false;

            if (Count == Capacity)
                SetCapacity(Capacity * 2);

            items[Count++] = item;
            return true;
        }

        /// <summary>
        /// Clear the set
        /// </summary>
        public void Clear() => Array.Clear(items, 0, Count);

        /// <summary>
        /// Checks if element is a part of set 
        /// </summary>
        /// <param name="item">element</param>
        /// <returns>true in case existing of element in set</returns>
        public bool Contains(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException(nameof(item));

            int size = Count;
            while (size-- > 0)
            {
                if (comparer.Equals(item, items[size]))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Copy set into array starting from specified index
        /// </summary>
        /// <param name="array">array in which elements of set are copied into</param>
        /// <param name="arrayIndex">start index of array</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException(nameof(array));

            if (arrayIndex < 0 || arrayIndex >= array.Length || array.Length - arrayIndex < Count)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            Array.ConstrainedCopy(items, 0, array, arrayIndex, Count);
        }

        /// <summary>
        /// makes set which contains all elements from current set without elements in specified sequence
        /// </summary>
        /// <param name="other">sequence</param>
        public void ExceptWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            SetCapacity(Count);
            items = items.Except(other, comparer).ToArray();
            Count = Capacity;
        }
        
        /// <summary>
        /// makes set which contains intersaction of two sets 
        /// </summary>
        /// <param name="other">sequence</param>
        public void IntersectWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            SetCapacity(Count);
            items = items.Intersect(other, comparer).ToArray();
            Count = Capacity;
        }

        /// <summary>
        /// defines if current set is subset of specified sequence
        /// </summary>
        /// <param name="other">sequence</param>
        /// <returns>true in case all elements in current set are part of specified sequence else false</returns>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            SetCapacity(Count);
            foreach (var element in items)
                if (!other.Contains(element, comparer))
                    return false;
            return true;
        }

        /// <summary>
        /// defines if current set is superset of specified sequence
        /// </summary>
        /// <param name="other">sequence</param>
        /// <returns>true in case all elements in specified sequence are part of current set else false</returns>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            SetCapacity(Count);
            foreach (var element in other)
                if (!items.Contains(element, comparer))
                    return false;
            return true;
        }

        /// <summary>
        /// defines if specified sequence is subset of current set 
        /// </summary>
        /// <param name="other">sequence</param>
        /// <returns>true in case all elements in specified sequence are part of current set else false</returns>
        public bool IsSubsetOf(IEnumerable<T> other) => !IsProperSubsetOf(other);

        /// <summary>
        /// defines if specified sequence is superset of current set
        /// </summary>
        /// <param name="other">sequence</param>
        /// <returns>true in case all elements in current set are part of specified sequence else false</returns>
        public bool IsSupersetOf(IEnumerable<T> other) => !IsProperSupersetOf(other);

        /// <summary>
        /// checks two sequences
        /// </summary>
        /// <param name="other">sequence</param>
        /// <returns>true in case existing the intersaction of two sequences else false</returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null))
                new ArgumentNullException(nameof(other));

            foreach (var element in other)
                if (this.Contains(element, comparer))
                    return true;
            return false;
        }

        /// <summary>
        /// Remove element from set
        /// </summary>
        /// <param name="item">element which is removed</param>
        /// <returns>true in case removint element from set</returns>
        public bool Remove(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException(nameof(item));

            for (int i = 0; i < Count; i++)
                if (comparer.Equals(items[i],item))
                {
                    Array.ConstrainedCopy(items, i + 1, items, i, Count - i - 1);
                    Count--;
                    return true;
                }
            return false;
        }

        /// <summary>
        /// Compares two sequences
        /// </summary>
        /// <param name="other">sequence</param>
        /// <returns>true in case equality of two sequances else false</returns>
        public bool SetEquals(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            SetCapacity(Count);
            return items.SequenceEqual(other, comparer);
        }

        /// <summary>
        /// creates set which contains elements which are part of current set or speified sequence, but doesn't contain elements which are part of two sequences simultaneously
        /// </summary>
        /// <param name="other">sequence</param>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            SetCapacity(Count);
            items = items.Union(other, comparer).Except(items.Intersect(other, comparer)).ToArray();
            Count = Capacity;
        }

        /// <summary>
        /// creates set which contains union of two sequences of non-repeating elements
        /// </summary>
        /// <param name="other">sequence</param>
        public void UnionWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            SetCapacity(Count);
            items = items.Union(other, comparer).ToArray();
            Count = Capacity;
        }

        /// <summary>
        /// State machine which allows to enumerate the set
        /// </summary>
        /// <returns>sequence of set</returns>
        public IEnumerator<T> GetEnumerator()
        {
            Array.Resize(ref items, Count);
            foreach (var element in items)
                yield return element;
        }
        #endregion

        #region private methods
        /// <summary>
        /// establish capacity of set
        /// </summary>
        /// <param name="capacity">capacity</param>
        private void SetCapacity(int capacity) => Array.Resize(ref items, capacity);

        /// <summary>
        /// allows to enumerate the set
        /// </summary>
        /// <returns>enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        #endregion
    }
}