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
        /// 10/07/2026. 
        /// 
        /// A method which reverses the singly linked list.
        /// </summary>
        /// <param name="partition"></param>
        public void DestructiveReverse(int partition = 0)
        {
            partition = (IndexInRange(partition)) ? partition : count;

            void Reverse(LinkedListNode<T> min, LinkedListNode<T> max)
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

            LinkedListNode<T> temp = this.head.next.next.next;
            Reverse(this.head, this.head.next.next.next);
            this.head.next.next.next = temp;
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
