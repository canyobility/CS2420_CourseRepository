using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Assignments.HeapsAndPriorityQueues
{

    /// <summary>
    /// IHeap interface defines objects which are min/max heaps. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHeap<T>
    {
        public T Push() => throw new NotImplementedException();
        public T Pop() => throw new NotImplementedException();
        public T Peek() => throw new NotImplementedException();
        public int Count { get; }
        public bool IsEmpty { get; }
    }

    internal class MinHeap<T> : IHeap<T>
    {
        private readonly List<T>_heap;
        public int Count => _heap.Count();
        public bool IsEmpty => Count == 0;
    }
}
