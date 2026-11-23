using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Assignments.HeapsAndPriorityQueues
{

    public enum HeapType
    {
        min,
        max,
    }

    public class PriorityQueue<T>
    {
        public readonly IHeap<T> _heap;


        public PriorityQueue(IHeap<T> heap)
        {
            if (_heap is not IHeap<T>)
            {
                throw new ArgumentException($"Heap must impliment the IHeap interface.");
            }

        }
    }

}
