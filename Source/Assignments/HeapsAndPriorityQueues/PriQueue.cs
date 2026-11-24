using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Source.Assignments.HeapsAndPriorityQueues
{
    // PriQueue instead of PriorityQueue to get around the built-in PriorityQueue type.
    public class PriQueue<T>
    {
        public readonly IHeap<T> _heap;

        public PriQueue(IHeap<T> heap)
        {
            if (heap is not IHeap<T>)
            {
                throw new ArgumentException($"Heap must impliment the IHeap interface.");
            }

            this._heap = heap;
        }
        public HeapBucket<T>? Peek() => _heap.Peek(); 
        public int Count => _heap.Count;
        public bool IsEmpty => _heap.IsEmpty;


        public T Enqueue(T value, int priority)
        {
            if (_heap == null)
                throw new InvalidOperationException("Queue missing heap base.");

            _heap.Push(value, priority);
            return value;
        }

        public T Dequeue()
        {
            T capturedValue = _heap.Peek().Value;
            
            if (capturedValue is null)
                throw new InvalidOperationException("Queue missing heap base.");


            _heap.Pop();

            return capturedValue;
        }
    }


    /// <summary>
    /// Set of extention methods for the PriQueue class to allow for shorthands on numeric types.
    /// </summary>
    /// 
    /// <remarks>
    /// The extention methods act as shorthands to make it easier to work with the PriQueue class
    /// when working with numeric values, where that the value 
    /// 
    /// Without these extention method, if you need to enqueue a value to the prioirty queue which
    /// should have the same priority as its value, you would need to mark both manually. 
    /// 
    /// <code>
    /// PriQueue&lt;int&gt; queue = new PriQueue&lt;int&gt;(new MinHeap&lt;int&gt;());
    /// queue.Enqueue(55, 55);
    /// </code>
    /// 
    /// These extention methods allow for the following syntax. 
    /// <code>
    /// PriQueue&lt;int&gt; queue = new PriQueue&lt;int&gt;(new MinHeap&lt;int&gt;());
    /// queue.Enqueue(55);
    /// </code>
    /// 
    /// These are marked as extention methods as so the numeric constraint can be applied without 
    /// restricting the generic type in the PriQueue&lt;T&gt; class. 
    /// </remarks>
    public static class NumericPriQueueExtentionShorthands
    {
        /// <summary>
        /// This extention 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queue"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Enqueue<T>(this PriQueue<T> queue, T value) where T : INumber<T>
        {
            int priority = int.CreateChecked(value);
            return queue.Enqueue(value, priority);
        }
    }

}
                                                                                                                                           