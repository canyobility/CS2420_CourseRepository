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


        public void DestructiveReverse(int partition = 0)
        {
            partition = (IndexInRange(partition)) ? partition : count;

            LinkedListNode<T>? previous = null;
            LinkedListNode<T> current = this.head;

            while (current is not null)
            {
                LinkedListNode<T> temp = current.next;

                current.next = previous;
                previous = current;
                current = temp;
            }

            this.head = previous;
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
