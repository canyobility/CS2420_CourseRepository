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

            if (head is null)
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


        public override string ToString()
        {
            string output = string.Empty;

            LinkedListNode<T> current = this.head;
            while (current is not null)
            {
                output = $"{current.Value}, ";
            }

            return $"({output.Substring(0, output.Length - 2)})";
        }
    }
}
