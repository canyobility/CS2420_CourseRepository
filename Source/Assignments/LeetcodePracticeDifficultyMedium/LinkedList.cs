using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Assignments.LeetcodePracticeDifficultyMedium
{
    public class SinglyLinkedList<T>
    {
        public LinkedListNode<T> head;
        public int count { get; private set; }


        public LinkedListNode<T> Append(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);

            if (count == 0)
            {
                this.head = newNode;
            }   
            else
            {
                LinkedListNode<T> current = this.head;
                while (current.next is not null) 
                    current = current.next;

                current.next = newNode;
            }

            this.count++;
            return newNode;
        }


        /// <summary>
        /// A method which reverses the singly linked list, from the head up to a partition value.
        /// If no partition is specified, the length of the list will be assumed.
        /// </summary>
        /// <param name="partition"></param>
        public void DestructiveReverse(int partition = 0)
        {
            // Helper method to reverse a linked list.
            void SinglyReverse(LinkedListNode<T> min, LinkedListNode<T> max)
            {
                LinkedListNode<T>? previous = null;
                LinkedListNode<T> current = min;

                while (current != max)
                {
                    LinkedListNode<T> temp = current.next;

                    current.next = previous;
                    previous = current;
                    current = temp;
                }

                this.head = previous;
            }

            partition = (partition is 0) ? count : partition;
            LinkedListNode<T> temp = GetAtIndex(partition);
            SinglyReverse(this.head, temp);

            GetAtIndex(partition - 1).next = temp;
        }



        /// <summary>
        /// Method for accessing the nth element in the linked list.
        /// </summary>
        /// <param name="index">The position n which you would need to return.</param>
        /// <returns>Linked list node.</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public LinkedListNode<T>? GetAtIndex(int index)
        {
            if (IndexInRange(index) is false)
            {
                throw new IndexOutOfRangeException();
            }

            LinkedListNode<T> current = this.head;
            for (int i = 0; i < index; i++)
                current = current.next;

            return current;
        }


        #region Utilitys
        protected bool IndexInRange(int index) => (index > 0) && (index < count);
        public override string ToString()
        {
            string output = string.Empty;
            int maxRecursiveDepth = count + (count / 2); // Anything more than this generally would only occur from a circular loop.

            LinkedListNode<T> current = this.head;
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

            return $"({output.Substring(0, output.Length - 2)})";
        }
        #endregion
    }
}
