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
    public class SinglyLinkedListNode<T>
    {
        public T Value { get; set; }
        private SinglyLinkedListNode<T> right;
        public SinglyLinkedListNode<T> Right 
        {
            get { return this.right;  }
            set { connect(value); } 
        }
        public bool Connected => (this.right is not null);
        public Guid NodeID { get; init; }

        public SinglyLinkedListNode(T value)
        {
            NodeID = Guid.NewGuid();
            Value = value;
        }

        /// <summary>
        /// Connects a node to another node. 
        /// 
        /// Added this as a safeguard to help prevent the code from getting stuck in a circular loop. 
        /// </summary>
        /// <param name="nodeToConnect"></param>
        /// <exception cref="RecursiveNodeConnectionException"></exception>
        private void connect(SinglyLinkedListNode<T> nodeToConnect)
        { 
            if (nodeToConnect.NodeID == this.NodeID)
            {
                throw new RecursiveNodeConnectionException($"Attempted to connect node this to itself. ID: {this.NodeID} ");
            }

            this.right = nodeToConnect;
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
