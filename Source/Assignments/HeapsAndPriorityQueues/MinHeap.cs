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


        /// <summary>
        /// Returns the current root bucket. Implimented to satisfy the B1 Rubric. 
        /// </summary>
        /// <returns></returns>
        public HeapBucket<T>? Peek()
        {
            if (IsEmpty) throw new InvalidOperationException();
            return Root;
        }


        #region Insertion
        /// <summary>
        /// Inserts a new value to the end of the queue, then shifts it up until the min-heap 
        /// condition is satisfied. Will resize the array if an insertion out of bounds is reached. 
        /// </summary>
        /// <param name="Value">Value to insert. </param>
        /// <param name="Priority">Attached Priority. </param>
        /// <returns></returns>
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


        #region Deletion
        /// <summary>
        /// Acts as the RemoveMin() method in a standard Min-Heap implimentation.
        /// 
        /// Removes the current root item, and propigates the futhermost left element until the 
        /// min-heap condition is satisfied, then returns the popped value. 
        /// </summary>
        /// <returns>HeapBucket<T>: The value currently stored to the queue root.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
        public HeapBucket<T> Pop()
        {
            if (IsEmpty || _array is null)
                throw new InvalidOperationException("Attempt to dequeue empty heap.");

            HeapBucket<T> target = this.Root;
            T capturedVal = target.Value;

            if (Count == 1)
            {
                _array[0] = null;
                _index--;
                return target;
            }

            _index--;
            SwapIndexes(0, _index);
            this._array[_index] = null;

            SiftDown(0);

            return target;
        }


        /// <summary>
        /// Method to correct the min-heap condition from the removal operation.
        /// </summary>
        /// <param name="index">The root index which the operation should start. </param>
        private void SiftDown(int index)
        {
            bool leftChildExists() => GetLeftChildIndex(index) < _index;
            bool rightChildExists() => GetRightChildIndex(index) < _index;

            while (leftChildExists() || rightChildExists())
            {
                int lowestIndex = index;
                HeapBucket<T> current = _array[index];

                if (leftChildExists() && 
                    _array[GetLeftChildIndex(index)].Priority < current.Priority )
                {
                    lowestIndex = GetLeftChildIndex(index);
                    current = _array[lowestIndex];
                }
                if (rightChildExists() &&
                     _array[GetRightChildIndex(index)].Priority < _array[lowestIndex].Priority)
                {
                    lowestIndex = GetRightChildIndex(index);
                }
                if (lowestIndex == index)
                {
                    break;
                }

                SwapIndexes(index, lowestIndex);
                index = lowestIndex;
            }
        }

        #endregion


        #region Utilities
        // Copied directly from assignment rubric.
        private int GetLeftChildIndex(int i) => (2 * i) + 1;
        private int GetRightChildIndex(int i) => (2 * i) + 2;
        private int GetParentIndex(int i) => ((i - 1) / 2);
        

        /// <summary>
        /// Takes the position of two indexes on self._array, and swaps them using tuple 
        /// deconstruction.
        /// </summary>
        /// <param name="IndexA">Index A. </param>
        /// <param name="IndexB">Index B. </param>
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
    }
    #endregion
}
