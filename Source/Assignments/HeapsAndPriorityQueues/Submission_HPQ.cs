/*
 Part A: Trace by hand (write answers as comments)

A1. Start with an empty max heap. Insert these values one at a time:
	15, 40, 25, 50, 10, 45

	[15]
	[15, 40]: 45: > 15. 1 swap.
	[40, 15, 25]: 35 < 50. 1 swap.
	[40, 15, 25, 50]: 50 > 15, 50 > 40. 3 Swaps.
	[50, 40, 25, 15, 10]: 10 < 40. 4 Swaps.
	[50, 40, 25, 15, 10, 45]: 45 > 25. 5 Swaps. 
	[50, 40, 45, 15, 10, 25]


Write the array after each insert. For each insert, say how many swaps happened while the new item moved up.

A2. Use your final heap from A1. Call RemoveMax() two times. For each call, write the value that is returned and the array after the call.
	Starting Max heap: [50, 40, 45, 15, 10, 25]
	
	RemoveMax() => 50. 
	Returned Max Heap: [45, 40, 25, 15, 10]

	RemoveMax() => 45.
	Returned Max Heap: [40, 15, 25, 10]
	
	

A3. Run BuildMaxHeap on this array:

[5, 12, 3, 20, 8, 15, 1]

Write the index where the first Heapify call starts and why. Then write the array after each Heapify call.

A4. Use your final array from A3. Do the first two rounds of heap sort (swap the top with the last heap item, then Heapify the top with the smaller heap size). Write the array after each round, and mark which part is already sorted.

A5. Start with an empty min heap. Insert the same values as A1: 15, 40, 25, 50, 10, 45. Write the final array.

A6. Fill in this table with the Big O of each operation, then explain in 2 or 3 sentences why a binary heap is the usual choice for a priority queue.
Way to build it 	Insert 	Peek 	RemoveMax
Unsorted list 			
Sorted list 			
Binary heap 			

A7. Give two real-life examples where a priority queue is a good fit. For each one, say what the items are and what the priority is.
 */


using System.Collections;
using System.Runtime.InteropServices.Marshalling;

public class MinPriorityQueue : IEnumerable<int>
{
	private List<int> queue;
    public int Count => queue.Count;
    public bool IsEmpty { get; set; }

	/// <summary>
	/// method of insertion to the priority queue. 
	/// </summary>
	/// <param name="priority"></param>
	public void Insert(int priority) 
	{
		queue.Add(priority);

		int current = this.Count - 1;
		int parent(int i) => (i - 1) / 2;

        while (current > 0 && queue[current] > queue[parent(this.Count)])
		{
			current = (this.Count - 1) / 2;
			(queue[current], queue[parent(this.Count)]) = (queue[parent(this.Count)], queue[current]);
		}
	
    }

    public int? Peek() => (IsEmpty) ? null : queue[0];
	public int RemoveMin() => throw new NotImplementedException();

	// Note: This method exists for internal display purposes. 
    public IEnumerator<int> GetEnumerator()
    {
        foreach (var item in queue) yield return item;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public MinPriorityQueue()
	{
		queue = new List<int>();
	}
}


public class Submission_HPQ
{
	public static void FillHeap(MinPriorityQueue queue, int[] numbers)
	{
		foreach (int priority in numbers)
		{
			queue.Insert(priority);
		}

		return;
	}

	public static void Main(string[] args)
	{
		MinPriorityQueue queue = new MinPriorityQueue();
		string displaySpacer = new string('=', Console.WindowWidth);
		int[] numbers = [10, 40, 25, 50, 10, 45];
        FillHeap(queue, numbers);

		Console.WriteLine($"Built min heap in order [{string.Join(", ", numbers)}]");
		Console.WriteLine("Queue Contents: ");
		foreach (int priority in queue)
		{
			Console.WriteLine($"	- {priority}");
		}

		Console.WriteLine(displaySpacer);

		Console.WriteLine("RemoveMin");
		while (!queue.IsEmpty)
		{
			int removedRoot = queue.RemoveMin();
			Console.WriteLine($"Removed root node of value: {removedRoot}");
		}
    }
}