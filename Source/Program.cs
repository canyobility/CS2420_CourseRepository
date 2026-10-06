using Source.Assignments.LeetcodePracticeDifficultyMedium;
using Source.Assignments.NewFolder;

public class Program
{
    private static void LeetCodePracticeDifficultyMedium()
    {
        SinglyLinkedList<int> list = new SinglyLinkedList<int>();

        // Suppliment for proper unit tests.
        void Debug()
        {
            Console.WriteLine($"Inserting 1: {list.Add(1)}");
            Console.WriteLine($"Inserting 2: {list.Add(2)}");
            Console.WriteLine($"Inserting 3: {list.Add(3)}");
            Console.WriteLine($"Inserting 5 at head: {list.AddAtHead(5)}");
            Console.WriteLine($"Inserting 10 at Tail: {list.AddAtTail(10)}");

            Console.WriteLine("Results: ");
            foreach (SinglyLinkedListNode<int> node in list)
            {
                Console.Write($"{node.Value}, ");
            }

            SinglyLinkedListNode<int> five;
            bool found = list.TryFindFirstNodeOfValue(5, out five);

            Console.WriteLine($"Found node of value 5: {found}. Allocation: {five.ToString()}");
            Console.WriteLine($"Contains 15? {list.Contains(15)}");
        }

        Debug();
    }


    public static void Main()
    {
        LeetCodePracticeDifficultyMedium();
    }
}