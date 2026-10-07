using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Assignments.LeetcodePracticeDifficultyMedium.LinkedLists
{
    /// <summary>
    /// NOTE: Majority of this class was sloppily copied from the LinkedList.cs file. As, that is what came first. 
    /// 
    /// <para>
    /// Ideally I should have designed this system substancially different as to prevent this amount of code duplication.
    /// I did not for this submission in the intrest of time. Sorry for my mess.
    /// </para> 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoublyLinkedList<T> : LinkedListShared
    {
        DoublyLinkedListNode<T> head;
        DoublyLinkedListNode<T> tail;
        int count;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DoublyLinkedListNode<T> Append(T value)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value);

            if (count == 0)
            {
                this.head = newNode;
            }
            else
            {
                DoublyLinkedListNode<T> current = this.head;
                while (current.next is not null)
                    current = current.next;

                current.next = newNode;
            }

            this.count++;
            return newNode;
        }
        public void Rotate(int rotations) => throw new NotImplementedException();


        public override string ToString()
        {
            string output = string.Empty;
            int maxRecursiveDepth = count + (count / 2); // Anything more than this generally would only occur from a circular loop.

            DoublyLinkedListNode<T> current = this.head;
            while (current is not null)
            {
                maxRecursiveDepth--;
                output = output + $"{current.Value}, ";
                current = current.next;

                if (maxRecursiveDepth == 0)
                {
                    break;
                }
            }

            return $"D({output.Substring(0, output.Length - 2)})";
        }

    }
}
