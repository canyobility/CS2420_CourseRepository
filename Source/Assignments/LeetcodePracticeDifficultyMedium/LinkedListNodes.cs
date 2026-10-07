using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Assignments.LeetcodePracticeDifficultyMedium
{
    /// <summary>
    /// Node base class. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Node<T>
    {
        public T Value { get; set; }
        public Node(T value)
        {
            Value = value;
        }
    }


    /// <summary>
    /// Linked list node with one connection (forward).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedListNode<T> : Node<T>
    {
        public LinkedListNode<T>? next { get; set; }
        public bool Connected => (next is null);
        public LinkedListNode(T value) : base(value) { }

    }


    /// <summary>
    /// Linked list node with two connectsion (front & back)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoublyLinkedListNode<T> : Node<T>
    {
        public LinkedListNode<T>? next { get; private set; }
        public LinkedListNode<T>? previous { get; private set; }

        /// <summary>
        /// A readonly property which indicates the current connectivity status of a given node>
        /// </summary>
        /// 
        /// <remarks>
        /// This system is my primaary compensation for the additional states that come with the nature of a doubly-linked
        /// connection. It works in place of the Connected property from the SinglyLinkedListNode implimentation.
        /// </remarks>
        /// 
        /// <returns>
        /// An <see cref="Leaning"/> value. Refer to the enum definition to view all provided options.
        /// </returns>
        public Leaning ConnectionLeaning
        {
            get
            {
                if (next is not null && previous is not null) { return Leaning.Connected; }
                else if (next is null && previous is not null) { return Leaning.ConnectedRight; }
                else if (next is not null && previous is null) { return Leaning.ConnectedLeft; }
                else { return Leaning.NotConnected; }
            }
        }

        /// <summary>
        /// Represents all possible connection states of a doubly linked list node.
        /// </summary>
        public enum Leaning 
        {
            /// <summary> Node is not connected. </summary>
            NotConnected,
            /// <summary> Node is connected on the left, and right.</summary>
            Connected,
            /// <summary> Node.Left is connected. Node.Right is null.</summary>
            ConnectedLeft,
            /// <summary> Node.Left is null. Node.Right is connected.</summary>
            ConnectedRight,
        }
        public DoublyLinkedListNode(T value) : base(value) { }
    }

}
