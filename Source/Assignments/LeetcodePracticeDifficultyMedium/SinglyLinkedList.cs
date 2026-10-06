using Source.Assignments.LeetcodePracticeDifficultyMedium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Source.Assignments.NewFolder
{
    /// <summary>
    /// Custom implimentation of a generic singly linked list class. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SinglyLinkedList<T>() : IEnumerable<SinglyLinkedListNode<T>>
    {
        #region Properties & Fields.
        public SinglyLinkedListNode<T> Head { get; private set; }
        public SinglyLinkedListNode<T> Tail { get; private set; }
        public int Count { get => this.count(); }
        public bool IsEmpty => Head == null || Tail == null;
        #endregion

        #region Adding & Removing
        /// <summary>
        /// Generic method used to add a value to the singly linked list. Optional index to insert the node at a 
        /// specific location in the linked list.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public SinglyLinkedListNode<T> Add(T value, int? index = null) 
        { 
            // Resolve the index
            index = index ?? this.Count;
          
            // Optimized varients when I do not need to add at a given index.
            // Goal is to hopefully keep this method fast.
            if (this.Count == 0)
            {
                return this.AddAtHead(value);
            }
            else if (index is null || index == this.Count)
            {
                return this.AddAtTail(value);
            }

            SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(value);

            // Find the new index to add to.
            int currentIndex = 0;
            SinglyLinkedListNode<T> foundLocation = this.Head;
            while (currentIndex < index - 1)
            {
                foundLocation = foundLocation.Right;
                currentIndex++;
            }

            return newNode;
        }


        /// <summary>
        /// Optimized method for inserting elements at the head of the list.
        /// </summary>
        /// <returns></returns>
        public SinglyLinkedListNode<T> AddAtHead(T value)
        {
            SinglyLinkedListNode<T> newHead = new SinglyLinkedListNode<T>(value);
            
            if (IsEmpty)
            {
                this.Head = newHead;
                this.Tail = newHead;
            }
            else
            {
                newHead.Right = this.Head;
                this.Head = newHead;
            }

            return newHead;
        }

        /// <summary>
        /// Optimized method for inserting elements at the list tail.
        /// </summary>
        /// <returns></returns>
        public SinglyLinkedListNode<T> AddAtTail(T value) 
        { 
            SinglyLinkedListNode<T> newTail = new SinglyLinkedListNode<T>(value);

            if (IsEmpty)
            {
                this.Tail = newTail;
                this.Head = newTail;
                return newTail;
            }

            if (this.Tail == this.Head)
            {
                this.Head.Right = newTail;
                this.Tail = newTail;
                return newTail;
            }

            this.Tail.Right = newTail;
            this.Tail = newTail;
            return newTail;
        }

        public void Remove() { throw new NotImplementedException(); }
        public void RemoveAtHead() { throw new NotImplementedException(); }
        public void RemoveAtTail() { throw new NotImplementedException(); }
        #endregion

        #region Getters
        public bool Contains() { throw new NotImplementedException(); }
        public void FindNode() { throw new NotImplementedException(); }
        public void GetAt() { throw new NotImplementedException(); }

        #endregion

        #region Misc
        // I added these methods to make life easier while programming. These are not directly related to the assignment.

        /// <summary>
        /// Very simple implimentation of the TortoiseAndHare algorithm to find the midpoint. Note that if you need the
        /// midpoint that you can also use (this.count / 2)
        /// </summary>
        /// <returns></returns>
        public (SinglyLinkedListNode<T> fast, SinglyLinkedListNode<T> slow, int midPoint) TortoiseAndHare()
        {
            SinglyLinkedListNode<T> fast = this.Head;
            SinglyLinkedListNode<T> slow = this.Head;
            int midPoint = 0;
            while (fast != null)
            {
                fast = fast.Right.Right;
                slow = slow.Right;
                midPoint++;
            }

            return (fast, slow, midPoint);
        }
        
        /// <summary>
        /// Counter method to sum the total nodes. 
        /// </summary>
        /// <returns></returns>
        private int count()
        {
            int count = 0;
            foreach (SinglyLinkedListNode<T> node in this) { count++; }
            return count;
        }

        /// <summary>
        /// Helper method to check if the index of a value is valid.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool IndexInRange(int index) => ((index > 0) && (index < this.Count)); 
        
        #endregion

        #region Conversion
        // Realize these are extra, though they are not very hard to add.
        public override string ToString() { throw new NotImplementedException(); }
        public T[] ToArray() { throw new NotImplementedException(); }
        public List<T> ToList() { throw new NotImplementedException(); }
        
        #endregion

        #region Interface Implimentation
        public IEnumerator<SinglyLinkedListNode<T>> GetEnumerator()
        {
            if (this.IsEmpty) { yield break; }

            SinglyLinkedListNode<T> current = (SinglyLinkedListNode<T>)this.Head;

            while (current != null)
            {
                yield return current;
                current = current.Right;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
