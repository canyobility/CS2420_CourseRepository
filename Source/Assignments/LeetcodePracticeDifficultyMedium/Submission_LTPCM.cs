using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Assignments.LeetcodePracticeDifficultyMedium
{
    public static class Submission_ITPCM
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Problem 1 [" + new string('=', Console.WindowWidth - 11));
            int[] example1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] example2 = new int[] { 1, 2, 3, 4, 5 };

            SinglyLinkedList<int> linkedList1 = new SinglyLinkedList<int>();
            foreach (int n in example1)
            {
                linkedList1.Append(n);
            }

            Console.WriteLine($"Linked List 1 contents: {linkedList1.ToString()}");
            linkedList1.DestructiveReverse(3);
            Console.WriteLine($"Linked List 1 contents (Reversed): {linkedList1.ToString()}");
            
        }
    }
}
