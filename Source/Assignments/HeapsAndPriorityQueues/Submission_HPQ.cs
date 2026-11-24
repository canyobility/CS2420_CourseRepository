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


using Source.Assignments.HeapsAndPriorityQueues;
using System.Collections;
using System.Runtime.InteropServices.Marshalling;


public class Submission_HPQ
{
	// Note: I am not using the implimented IHeap interface to keep this portion of the assignment 
	//		 identical to the rubric. 
	public static bool IsMaxHeap(int[] arr)
	{
		return false;
	}

	public static void Main(string[] args)
	{
		MinHeap<int> heap1 = new MinHeap<int>();
		MinHeap<int> heap2 = new MinHeap<int>();
        PriQueue<int> queue1 = new PriQueue<int>(heap1);
        PriQueue<int> queue2 = new PriQueue<int>(heap2);
		
		int[] numbers = [10, 40, 25, 50, 10, 45];
		string horizontalBand = new string('=', Console.WindowWidth);

		Console.WriteLine("Instanciated Priority Queue 1");
		Console.WriteLine("Instanciated Priority Queue 2");

        Console.WriteLine(horizontalBand);

        Console.WriteLine("Empty Priority Queue:");
		Console.WriteLine("Root for Queue 2 (null expected): " + ((queue2._heap.Root is null) ? "null" : queue2._heap.Root.ToString()));
		Console.WriteLine("Calling Dequeue() on Queue 2 [RemoveMin()]. Fail expected. ");

		try
		{
			queue2.Dequeue();
		}
		catch (Exception e)
		{
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Insertion Failed: " + e.Message);
			Console.ResetColor();
		}

        Console.WriteLine(horizontalBand);
		
        foreach (int priority in numbers)
		{
			Console.WriteLine($"Inserting value to Queue1: {priority}");
			queue1.Enqueue(priority);
		}

		Console.WriteLine();
        Console.WriteLine("Resulting Min-Heap (priority Queue 1): ");
        Console.WriteLine(queue1._heap.ToString());
		Console.WriteLine(horizontalBand);
	
		foreach (int priority in numbers)
		{
			int capturedPri = queue1.Dequeue();
            Console.WriteLine($"Dequeue head from Priority Queue 1: {capturedPri}");
			Console.WriteLine("Result: ");
            Console.WriteLine(queue1._heap.ToString());
        }

        Console.WriteLine(horizontalBand);
		Console.WriteLine("Part B:");

		testCase[] Cases = new testCase[5];
		Cases[0] = new testCase(input: new int[] { 90, 70, 80, 30, 60, 50}, 
									  shouldSucceed: true);
        Cases[1] = new testCase(input: new int[] { 50, 40, 30, 45, 10},
                                  shouldSucceed: true);
        Cases[2] = new testCase(input: new int[] { 10, 20, 30},
                              shouldSucceed: false);
        Cases[3] = new testCase(input: new int[] { 7},
                              shouldSucceed: true);
        Cases[4] = new testCase(input: new int[] { },
                              shouldSucceed: true);

		for (int i = 0; i < Cases.Length; i++)
		{
			testCase testCase = Cases[i];
			Console.WriteLine($"Case {i + 1}");
			Console.WriteLine($"Array: [ {string.Join(", ", testCase.input)} ]");
			Console.WriteLine($"         Is Max-Heap: {((IsMaxHeap(testCase.input)) ? "Yes" : "No" )}");
		}
    }

	record testCase(int[] input, bool shouldSucceed);
}