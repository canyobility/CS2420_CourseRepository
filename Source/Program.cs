using Source.Assignments.LeetcodePracticeDifficultyMedium;
using Source.Assignments.LeetcodePracticeDifficultyMedium.V1;

public class Program
{
    private static void LeetCodePracticeDifficultyMedium()
    {
        SinglyLinkedList<int> list = new SinglyLinkedList<int>();
        DoublyLinkedList<int> list2 = new DoublyLinkedList<int>();

        // Suppliment for proper unit tests.
        void SinglyLinked()
        {
            Console.WriteLine();
            //Console.WriteLine($"Inserting 1: {list.Add(1)}");
            //Console.WriteLine($"Inserting 2: {list.Add(2)}");
            //Console.WriteLine($"Inserting 3: {list.Add(3)}");
            //Console.WriteLine($"Inserting 5 at head: {list.AddAtHead(5)}");
            //Console.WriteLine($"Inserting 10 at Tail: {list.AddAtTail(10)}");
            //Console.WriteLine($"Results: {list.ToString()}");

            //SinglyLinkedListNode<int> five;
            //bool found = list.TryFindFirstNodeOfValue(5, out five, out int? foundIndex);
            //Console.WriteLine($"Found node of value 5: {found}. Allocation: {five.ToString()}");
            //Console.WriteLine($"Contains 15? {list.Contains(15)}");

            //list.RemoveAtHead();
            //list.RemoveAtTail();
            //list.RemoveFirst(2);

            //Console.WriteLine($"Trimmed List: {list.ToString()}");
        }

        void DoublyLinked()
        {
            Console.WriteLine($"Inserting 1: {list2.Add(1)}");
            Console.WriteLine($"Inserting 2: {list2.Add(2)}");
            Console.WriteLine($"Inserting 3: {list2.Add(3)}");
            Console.WriteLine($"Inserting 5 at head: {list2.AddAtHead(5)}");
            Console.WriteLine($"Inserting 10 at Tail: {list2.AddAtTail(10)}");
            Console.WriteLine($"Results: {list2.ToString()}");
        }

        DoublyLinked();
    }


    public static void Main()
    {
        LeetCodePracticeDifficultyMedium();
    }
}