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
 - Doctors office managing patients, especally in the emergency room. 
 - Render farms, where some animated sequences have a higher immediate priority than others. 
 - 
 */


using Source.Assignments.HeapsAndPriorityQueues;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;


public class Submission_HPQ
{
    #region Logic
    // Note: I am not using the implimented IHeap interface to keep this portion of the assignment 
    //		 identical to the rubric. 
    /// <summary>
    /// Checks if an array of passed intagers follow the max-heap condition.
    /// </summary>
    /// <param name="arr">Array to check.</param>
    /// <returns></returns>
    public static bool IsMaxHeap(int[] arr)
	{
		// Copied directly from Minheap.cs, & Assignment Rubric.
		int GetLeftChildIndex(int i) => (2 * i) + 1;
		int GetRightChildIndex(int i) => (2 * i) + 2;
		int GetParentIndex(int i) => ((i - 1) / 2);

		bool LeftChildExists(int index) => GetLeftChildIndex(index) < arr.Length;
		bool RightChildExists(int index) => GetRightChildIndex(index) < arr.Length;

        for (int i = 0; i < arr.Length; i++)
		{
			if (LeftChildExists(i) && arr[i] < arr[GetLeftChildIndex(i)])
				return false;

            if (RightChildExists(i) && arr[i] < arr[GetRightChildIndex(i)])
                return false;

        }

        return true;
	}

    /*
      I have Copied high-level psudocode from a google search to work with C#. 
      The inital Psudocode is attached below.  
	
	  function heapSort(array):
			n = length(array)

			// 1. Build a max-heap from the unsorted array
			for i from floor(n / 2) - 1 down to 0:
				heapify(array, n, i)

			// 2. Repeatedly extract the maximum element and rebuild the heap
			for end from n - 1 down to 1:
				swap array[0] and array[end]
				heapify(array, end, 0)

	   function heapify(array, heapSize, rootIndex):
			largest = rootIndex
			left = 2 * rootIndex + 1
			right = 2 * rootIndex + 2

			// Check if left child exists and is greater than current largest
			if left < heapSize and array[left] > array[largest]:
				largest = left

			// Check if right child exists and is greater than current largest
			if right < heapSize and array[right] > array[largest]:
				largest = right

			// If the largest element is not the root, swap and continue sifting down
			if largest != rootIndex:
				swap array[rootIndex] and array[largest]
				heapify(array, heapSize, largest)
	 */


	/// <summary>
	/// Implimentation of HeapSort. 
	/// </summary>
	/// <param name="arr">Array to sort. </param>
    public static void HeapSort(int[] arr)
	{
		int length = arr.Length;

		Heapify(arr);

		for (int i = length - 1; i > 0; i--)
		{
			(arr[0], arr[i]) = (arr[i], arr[0]);
			Heapify(arr, i, 0);
		}
	}


	/// <summary>
	/// Helper method to convert an unsorted array into a heap. 
	/// </summary>
	/// <param name="arr"></param>
	/// <param name="n"></param>
	/// <param name="i"></param>
    private static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left] > arr[largest])
            largest = left;

        if (right < n && arr[right] > arr[largest])
            largest = right;

        if (largest != i)
        {
            (arr[largest], arr[i]) = (arr[i], arr[largest]);
            Heapify(arr, n, largest);
        }
    }


	/// <summary>
	/// "Heapifies" an array, by converting the unsorted array to a max-heap. 
	/// </summary>
	/// <param name="arr">Intager array to transorm into a max-heap</param>
    public static void Heapify(int[] arr)
    {
        int n = arr.Length;

        for (int i = (n / 2) - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }
    }

	
	/// <summary>
	/// Returns an int array of the top K scores given an int array in format of an array of 
	/// numbers.
	/// 
	/// Note: While this solution can technically produce the expected output, I am not conifdent
	///		  this implimentation is the "correct" and or expected way to solve this problem. 
	/// </summary>
	/// <param name="array">Array to trim the top-k results.</param>
	/// <param name="amountToSave">Length of the output array. Higher = more scores.</param>
	/// <returns></returns>
	public static int[] GetTopKScores(int[] array, int amountToSave = 3)
	{
		PriorityQueue<int, int> scoreQueue = new PriorityQueue<int, int>();
		foreach (int i in array)
		{
			scoreQueue.Enqueue(i, i);
		}

		int scoresToFilter = Math.Clamp((scoreQueue.Count - amountToSave), 0, scoreQueue.Count);

		for (int e = scoresToFilter; e > 0; e--)
			scoreQueue.Dequeue();

		int[] outputArray = new int[amountToSave];
		int indexer = amountToSave - 1;
		while (scoreQueue.Count > 0)
		{
			outputArray[indexer] = scoreQueue.Dequeue();
			indexer--;
		}

		return outputArray;
	}


    #endregion
    #region Runtime
    public static void Main(string[] args)
	{
		MinHeap<int> heap1 = new MinHeap<int>();
		MinHeap<int> heap2 = new MinHeap<int>();
		PriQueue<int> queue1 = new PriQueue<int>(heap1);
		PriQueue<int> queue2 = new PriQueue<int>(heap2);

		int[] numbers = [10, 40, 25, 50, 10, 45];
		string horizontalBand = new string('=', Console.WindowWidth);

		Console.WriteLine("B1: Program a min-heap Qriority Queue. ");
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
		Console.WriteLine("B1: IsMaxHeap()");

		testCase[] Cases = new testCase[5];
		Cases[0] = new testCase(input: new int[] { 90, 70, 80, 30, 60, 50 },
									  shouldSucceed: true);
		Cases[1] = new testCase(input: new int[] { 50, 40, 30, 45, 10 },
								  shouldSucceed: true);
		Cases[2] = new testCase(input: new int[] { 10, 20, 30 },
							  shouldSucceed: false);
		Cases[3] = new testCase(input: new int[] { 7 },
							  shouldSucceed: true);
		Cases[4] = new testCase(input: new int[] { },
							  shouldSucceed: true);

		for (int i = 0; i < Cases.Length; i++)
		{
			testCase testCase = Cases[i];
			Console.WriteLine($"Case {i + 1}");
			Console.WriteLine($"Array: [ {string.Join(", ", testCase.input)} ]");
			Console.WriteLine($"         Is Max-Heap: {((IsMaxHeap(testCase.input)) ? "Yes" : "No")}");
		}

		Console.WriteLine(horizontalBand);
		Console.WriteLine("Part 3: Heapsort. ");
		int[] arrayToSort = new int[] { 5, 12, 3, 20, 8, 15, 1 };
		Console.WriteLine($"Array Unsorted:             [ {string.Join(", ", arrayToSort)} ]");

		Heapify(arrayToSort);
		Console.WriteLine($"Array Heapified (Max-Heap): [ {string.Join(", ", arrayToSort)} ]");
		Console.WriteLine($"Array is Max-Heap:	    {((IsMaxHeap(arrayToSort)) ? "Yes" : "No") }");

		HeapSort(arrayToSort);
		Console.WriteLine($"Array Sorted:               [ {string.Join(", ", arrayToSort)} ]");

		Console.WriteLine(horizontalBand);
		Console.WriteLine("B4: TopK.");

		int[] totalScores = new int[] { 42, 17, 99, 63, 8, 75, 31 };
		int[] topScores = GetTopKScores(totalScores);
		Console.WriteLine($"Current Total Scores: { string.Join(", ", totalScores)}");
		Console.WriteLine($"Current Top Scores: { string.Join(", ", topScores)}");
    }

	record testCase(int[] input, bool shouldSucceed);

    #endregion
}