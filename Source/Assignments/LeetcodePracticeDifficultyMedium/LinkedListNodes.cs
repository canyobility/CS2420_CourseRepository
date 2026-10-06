using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Assignments.LeetcodePracticeDifficultyMedium
{
    /// <summary>
    /// Generic linked list node. Not intended to be instanciated directly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Linked list node for use in singly linked lists. The value which is stored in this node is generic, and must be 
    /// provided upon instanciation.
    /// </para> 
    /// 
    /// <para>
    /// The next node is represented with this.right
    /// </para>
    /// 
    /// <para>A dedicated ID is provided for cases which differenciation is important. For instance, targetting a specific 
    /// node of value 5 instead of searching for the first child of value T.
    /// </para>
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// 

    public abstract class LinkedListNode<T> : IEquatable<LinkedListNode<T>>
    {
        public T Value { get; set; }
        public Guid NodeID { get; init; }

        public LinkedListNode(T value)
        {
            NodeID = Guid.NewGuid();
            Value = value;
        }



        // Attempt to resolve inequality operations
        // This is my first time overloading the equality operators, and although I have read through the doucmentation extensively, 
        // I do want to note this may not be the "best" way to approach this problem. Or, if this is a good design.
        public bool Equals(T var) => this.Value.Equals(var);
        public bool Equals(LinkedListNode<T>? other) => (this.Value.Equals(other.Value));
    }

    public class SinglyLinkedListNode<T> : LinkedListNode<T>
    {
        private SinglyLinkedListNode<T> right;
        public SinglyLinkedListNode<T> Right
        {
            get { return this.right; }
            set
            {
                connect(value);
            }
        }
        public bool Connected => (this.right is not null);

        public SinglyLinkedListNode(T value) : base(value) 
        {    }


        /// <summary>
        /// Connects a node to another node. 
        /// 
        /// Added this as a safeguard to help prevent the code from getting stuck in a circular loop. 
        /// </summary>
        /// <param name="nodeToConnect"></param>
        /// <exception cref="RecursiveNodeConnectionException"></exception>
        private void connect(LinkedListNode<T> nodeToConnect)
        {
            if (nodeToConnect is null)
            {
                this.right = null;
                return;
            }
            else if (nodeToConnect is not SinglyLinkedListNode<T>)
            {
                throw new ArgumentException("Attempted to connect this, SinglyLinkedListNode<T> to a non singlyLinkedListNode<T> type.");
            }

            if (nodeToConnect.NodeID == this.NodeID)
            {
                throw new RecursiveNodeConnectionException($"Attempted to connect node this to itself. ID: {this.NodeID} ");
            }


            this.right = (SinglyLinkedListNode<T>)nodeToConnect;
        }

    }

    [Serializable]
    public class RecursiveNodeConnectionException : Exception
    {
        public RecursiveNodeConnectionException() { }
        public RecursiveNodeConnectionException(string message) : base(message) { }
        public RecursiveNodeConnectionException(string message, Exception inner) : base(message, inner) { }
        protected RecursiveNodeConnectionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
