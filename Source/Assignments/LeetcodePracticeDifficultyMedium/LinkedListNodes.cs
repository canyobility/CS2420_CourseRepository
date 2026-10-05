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
        public SinglyLinkedListNode<T> right { get; set; }
        public bool Connected => (this.right is not null);
        public Guid NodeID { get; init; }

        public SinglyLinkedListNode(T value)
        {
            NodeID = Guid.NewGuid();
            Value = value;
        }

    }
}
