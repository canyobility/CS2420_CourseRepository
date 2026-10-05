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
    public class SinglyLinkedList<T>() : IEnumerable<T>
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
            if (index is null || index == this.Count)
            {
                return this.AddAtTail();
            }
            else if (this.Count == 0)
            {
                return this.AddAtHead();
            }

            SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(value);
            return newNode;
        }
        public SinglyLinkedListNode<T> AddAtHead() { throw new NotImplementedException(); }
        public SinglyLinkedListNode<T> AddAtTail() { throw new NotImplementedException(); }

        public void Remove() { throw new NotImplementedException(); }
        public void RemoveAtHead() { throw new NotImplementedException(); }
        public void RemoveAtTail() { throw new NotImplementedException(); }
        #endregion

        #region Getters
        public bool Contains() { throw new NotImplementedException(); }
        public void FindNode() { throw new NotImplementedException(); }

        #endregion

        #region Misc
        public void GetAt() { throw new NotImplementedException(); }
        public void TourtisAndHair() { throw new NotImplementedException(); }
        private int count() { throw new NotImplementedException(); }
        private void IndexInRange(int index) { throw new NotImplementedException(); }
        #endregion

        #region Conversion
        // Realize these are extra, though they are not very hard to add.
        public override string ToString() { throw new NotImplementedException(); }
        public T[] ToArray() { throw new NotImplementedException(); }
        public List<T> ToList() { throw new NotImplementedException(); }
        
        #endregion

        #region Interface Implimentation
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
