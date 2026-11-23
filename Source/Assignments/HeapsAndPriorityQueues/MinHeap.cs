using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Assignments.HeapsAndPriorityQueues
{
    #region IHeap
    /// <summary>
    /// IHeap interface defines objects which are min/max heaps. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHeap<T>
    {
        // Properties
        public int Count { get; }
        public bool IsEmpty { get; }
        public HeapBucket<T>? Root { get;  }

        // Methods
        public HeapBucket<T> Push(T value, int priority);
        public HeapBucket<T> Pop();
        public HeapBucket<T>? Peek();
    }

    #endregion


    #region
    /// <summary>
    /// Class that stores the value and priority inserted to a heap seperately. Allows for 
    /// insertion of values that are not inerently type int.
    /// </summary>
    /// <typeparam name="T">Base type stored in the Value field.</typeparam>
    public class HeapBucket<T>
    { 
        public int Priority { get; set; }
        public T Value { get; set; }

        public HeapBucket(T value, int priority)
        {
            Priority = priority;
            Value = value;
        }


        public override string ToString()
        {
            return $"[Value: {Value}, Priority: {Priority}]";
        }
    }
    #endregion


    #region MinHeap
    /// <summary>
    /// Implimentation of a minimum heap
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class MinHeap<T> : IHeap<T>
    {
        internal HeapBucket<T>[] _array;
        private int _index; 
        public int Count => _index;
        public bool IsEmpty => Count == 0;
        public HeapBucket<T>? Root
        {
            get
            {
                return (IsEmpty) ? null : _array[0];
            }
        }

        public MinHeap(int size = 1)
        {
            _array = new HeapBucket<T>[size];
        }


        public HeapBucket<T>? Peek()
        {
            return Root;
        }


        #region Insertion
        public HeapBucket<T> Push(T Value, int Priority)
        {
            if (Count + 1 > _array.Length) ResizeArray();
            HeapBucket<T> bucket = new HeapBucket<T>(value: Value, 
                                                     priority: Priority );

            this._array[_index] = bucket;

            ShiftUp(_index);
            _index++;

            return bucket;
        }


        private void ShiftUp(int index)
        {
            while (index != 0)
            {
                int parentIndex = GetParentIndex(index);
                HeapBucket<T> current = _array[index];
                HeapBucket<T> parent = _array[parentIndex];

                if (current.Priority >= parent.Priority)
                    break;

                SwapIndexes(index, parentIndex);

                index = parentIndex;
            }
        }

        #endregion

        #region Utilities
        // Copied directly from assignment rubric.
        private int GetLeftChildIndex(int i) => (2 * i) + 1;
        private int GetRightChildIndex(int i) => (2 * i) + 2;
        private int GetParentIndex(int i) => ((i - 1) / 2);
        
        private void SwapIndexes(int IndexA, int IndexB)
        {
            ref HeapBucket<T> indexA =  ref _array[IndexA];
            ref HeapBucket<T> indexB = ref _array[IndexB];

            (indexB, indexA) = (indexA, indexB);
        }

        /// <summary>
        /// Doubles the length of the current heap array.
        /// </summary>
        private void ResizeArray()
        {
            HeapBucket<T>[] newArray = new HeapBucket<T>[_array.Length * 2];

            for (int i = 0; i < _array.Length; i++)
            {
                HeapBucket<T> current = _array[i];
                newArray[i] = current;
            }

            this._array = newArray;
        }


        /// <summary>
        /// Override of ToString for previewing
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string outp = string.Empty;

            foreach (HeapBucket<T> bucket in _array)
            {
                if (bucket is null)
                    break;
                outp += bucket.ToString() + "\n";                
            }

            return $"{outp}";
        }
        #endregion

        #region Deletion
        public HeapBucket<T> Pop()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    #endregion
}
