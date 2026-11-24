using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Source.Assignments.HeapsAndPriorityQueues
{
    // PriQueue instead of PriorityQueue to get around the built-in PriorityQueue type.
    /// <summary>
    /// Generic priority queue base class for both mininimum and maximum heaps. 
    /// </summary>
    /// 
    /// <remarks>
    /// Note: The implimentation of this priority queue (and min-heap) differs from the rubric, the
    /// primary purpose of this abstraction was to decouple the heap from the queue. 
    /// This implimentation additionally: 
    /// 
    /// <list type="bullet">
    ///     <item>A priority queue can store any type.</item> 
    ///     <item>The value and its priority act astwo seperate fields. A set of extention methods
    ///           exists for numeric types where the value is the priority, preventing the need to
    ///           re-enter the same information twice. </item> 
    ///     <item>Although not implimented, the heap used theoretically can be any object which 
    ///           impliments the IHeap interface. This theoretically supports more specialized heap
    ///           varients, such as a D-ary heap, granted said variations do not require additional
    ///           methods beyond insertions/removal to work as intended.
    /// </item> 
    /// </list>
    /// 
    /// Our current plan for this class's final project required a priority queue with those 
    /// primary requirements. While researching implimentation, I also felt it was most intuitive 
    /// to seperate the heap from the queue, as a priority queue employs a "has-a" relationship.
    /// 
    /// <para>
    /// RUBRIC: 
    /// This submission should still loosely follow all requirements in the rubric. Attached are 
    /// the locations for all requirements as specifieid in B1
    /// 
    /// <list type="bullet">
    ///     <item> void Insert(int priority): MinHeap.cs, line 142 </item>
    ///     <item> int Peek(): MinHeap, Line 83</item>
    ///     <item> int RemoveMin(): MinHeap.cs, Line 142</item>
    ///     <item> int Count: MinHeap.cs, Line 63</item>
    ///     <item> bool IsEmpty: MinHeap.cs, Line 64</item>
    ///     <item>Peek throws InvalidOperationException: MinHeap.cs: 84</item>
    ///     <item>RemoveMin throws InvalidOperationException: MinHeap.cs: 145</item>
    /// </list>
    /// 
    /// Note: There is no direct RemoveMin() function, as insertions/removals needed the same names
    /// between the min and max heaps for the priority queue class to communicate with both. The
    /// Pop() method stores all logic for removing the minimum/root. 
    /// 
    /// </para>
    ///</remarks>
    /// <typeparam name="T"></typeparam>
    public class PriQueue<T>
    {
        internal readonly IHeap<T> _heap;

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
                                                                                                                                           