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

        // TODO: Ideally get this to work. 
        /// <inheritdoc cfref = "SinglyLinkedList.Insert(T Value)"/>
        public DoublyLinkedListNode<T> Append(T value)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value);

            if (count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                DoublyLinkedListNode<T> current = this.head;
                while (current.next is not null)
                    current = current.next;

                current.next = newNode;
                this.tail = newNode;
            }

            this.count++;
            return newNode;
        }
        
        
        /// <summary>
        /// Method which rotates the linked list.
        /// </summary>
        /// <param name="rotations"></param>
        public void Rotate(int rotations)
        {
            while (rotations > 0)
            {
                DoublyLinkedListNode<T> head = this.head;
                DoublyLinkedListNode<T> tail = this.tail;
                DoublyLinkedListNode<T> temp1 = head;

                tail.previous = head;
                tail.next = temp1;


                rotations--;
            }
        }


        public override string ToString()
        {
            string GetConnection(DoublyLinkedListNode<T> node)
            {
                // Note: 
                switch(node.ConnectionLeaning)
                {
                    case (Leaning.ConnectedLeft): return "<";
                    case (Leaning.ConnectedRight): return ">";
                    case (Leaning.Connected): return "<->";
                    default: return "!";
                }
            }


            string output = string.Empty;
            int maxRecursiveDepth = count + (count / 2); // Anything more than this generally would only occur from a circular loop.

            DoublyLinkedListNode<T> current = this.head;
            while (current is not null)
            {
                maxRecursiveDepth--;
                output = output + $"{current.Value} {GetConnection(current)} ";
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
