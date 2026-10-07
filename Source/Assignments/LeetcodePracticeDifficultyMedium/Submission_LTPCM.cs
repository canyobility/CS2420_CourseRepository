using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Assignments.LeetcodePracticeDifficultyMedium
{
    public static class Submission_ITPCM
    {
        #region Program Orchestration.
        public static void Main(string[] args)
        {
            Console.WriteLine("Problem 1 [" + new string('=', Console.WindowWidth - 11));
            Problem1();
            
        }

        #endregion


        #region Program Implementation
        /// <summary>
        /// Implementation of problem 1.    
        /// </summary>
        /// <remarks>
        /// 
        /// Part 1 constraints
        /// Target Time: O(n) Target Space: O(1)
        /// <list type="bullet">
        ///     <item>1 &lt;= number of nodes &lt;= 10^5</item>
        ///     <item>1 &gt;= k &lt;= 10^5</item>
        ///     <item>-1000 &lt;= Node.val &gt;= 1000</item>
        /// </list>
        /// </remarks>
        private static void Problem1()
        {
            int[] example1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] example2 = new int[] { 1, 2, 3, 4, 5 };

            SinglyLinkedList<int> linkedList1 = new SinglyLinkedList<int>();
            SinglyLinkedList<int> linkedList2 = new SinglyLinkedList<int>();
            foreach (int n in example1)
                linkedList1.Append(n);

            foreach (int n in example2)
                linkedList2.Append(n);

            Console.WriteLine($"Linked List 1 contents: {linkedList1.ToString()}");
            Console.WriteLine($"Linked List 2 contents: {linkedList2.ToString()}");
            linkedList1.DestructiveReverse(3);
            linkedList2.DestructiveReverse(2);

            Console.WriteLine($"Linked List 1 contents (Reversed at k=3): {linkedList1.ToString()}");
            Console.WriteLine($"Linked List 2 contents (Reversed at k=2): {linkedList2.ToString()}");
        }
        #endregion
    }
}
