using Source.Assignments.LeetcodePracticeDifficultyMedium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Source.Assignments.NewFolder
{
    /// <summary>
    /// Simple Singly Linked List implimentation.
    /// </summary>
    /// 
    /// <remarks>
    /// Much simplified version of my planned SinglyLinkedList class for this submission, rewritten in ~6 or so hours.
    /// 
    /// <para>
    /// I attached some additional logic to the base linked list to either make this easier to work with, or be more or
    /// less useful as a proper datastructure. This includes the implimentation of the IENumerable interface, conversion
    /// methods, and the TortoiseAndHare algorithm.
    /// </para>
    /// 
    /// <para>
    /// Few things to note with this implimentation: 
    /// - Count is not a stored value. It is computed on the fly, with each computation taking a time complexity of O(n).
    /// - I have not tested a large amount of this file. There may be some bugs. 
    /// </para>
    /// </remarks>
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
            if (this.IsEmpty)
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

        /// <summary>
        /// Removes the first appearance of a value from the linked list, in the order it was first found.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="KeyNotFoundException">Thrown when T value could not be foudn in the array.</exception>
        public void RemoveFirst(T value) 
        {
            if (this.Head is not null && this.Head.Value!.Equals(value))
            {
                this.RemoveAtHead();
                return;
            } 

            SinglyLinkedListNode<T>? Node;
            int? index;
            bool nodeFound = this.TryFindFirstNodeOfValue(value, out Node, out index);
            if (nodeFound == false) { throw new KeyNotFoundException($"Cannot find a node of value {value}."); }
            
            // Less optimized than the insertion. I cannot guarantee the tail is the first appearance of a value without
            // walking through the list beforehand.
            if (Node.Value.Equals(this.Tail.Value))
            {
                this.RemoveAtTail();
                return;
            }

            if (index is null)
            { throw new Exception("This should never be reached. If it is, something significant has broke."); }

            int currentPosition = 0;
            SinglyLinkedListNode<T> current = this.Head;
            while (currentPosition != index - 1)
            {
                currentPosition++;
                current = current.Right;
            }

            SinglyLinkedListNode<T> leftNode = current;
            SinglyLinkedListNode<T> nodeToRemove = current.Right;
            SinglyLinkedListNode<T> rightNode= current.Right.Right;

            leftNode.Right = rightNode;
        }


        /// <summary>
        /// Removes the current head, replacing head with head.Right.
        /// </summary>
        public void RemoveAtHead()
        {
            SinglyLinkedListNode<T> newHead = this.Head.Right;
            this.Head = null; // Would possibly want to impliment IDisposable on the nodes for removal.
            this.Head = newHead;
        }


        /// <summary>
        /// Trims the tail back one node node. Replaces the current tail with the previous node. 
        /// 
        /// <para>
        /// Note: Due to the nature of a singly linked list, this method will always take O(n) time, and is not light.
        /// </para>
        /// </summary>
        public void RemoveAtTail()
        {
            SinglyLinkedListNode<T> current = this.Head;

            while (current.Right.Right is not null)
            {
                current = current.Right;
            }

            current.Right = null;
            this.Tail = current;
        }
        #endregion

        #region Getters        
        /// <summary>
        /// This method is used to try to find the first node in the list which shares a specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool TryFindFirstNodeOfValue(T value, out SinglyLinkedListNode<T>? nodeOut, out int? index) 
        {
            SinglyLinkedListNode<T> current = this.Head;
            int counter = 0;
            while (current is not null)
            { 
                // https://stackoverflow.com/questions/8982645/how-to-solve-operator-cannot-be-applied-to-operands-of-type-t-and-t
                if (current.Value!.Equals(value))
                {
                    nodeOut = current;
                    index = counter;
                    return true;
                }

                current = current.Right;
                counter++;
            }

            nodeOut = null;
            index = null;
            return false;
        }

        /// <summary>
        /// TODO: This is probably not the proper way to do this. At the very least revisit the docstring.
        /// 
        /// <para>
        /// Overload of the TryFindFirstNodeOfValue(T value<T>? nodeOut) method which does not need to return the found
        /// node.
        /// </para>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            SinglyLinkedListNode<T> tempNode = null;
            int? tempIndex = null;
            return this.TryFindFirstNodeOfValue(value, out tempNode, out tempIndex);
        }

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
        // Realize these are extra, though, I figure they are very useful for keeping this class easy to use in the
        // future. If, I use them in the future, anyway.


        // Visual Studio previews classes as their string representation while debugging; this makes that easier to
        // quickly preview changes.
        public override string ToString() 
        {
            string stringOut = string.Empty;

            foreach (SinglyLinkedListNode<T> node in this)
            {
                stringOut += $"{node.Value}, ";
            }

            return $"({stringOut.Substring(0, stringOut.Length - 2)})";
        }

        /// <summary>
        /// Converts the linked list to an array format.
        /// </summary>
        /// <returns></returns>
        public T[] ToArray() 
        {
            int countCache = this.Count;
            SinglyLinkedListNode<T> current = this.Head;
            T[] array = new T[countCache];
            for (int i = 0; i < countCache; i++)
            {
                array[i] = current.Value;
                current = current.Right;
            }

            return array;
        }


        /// <summary>
        /// Converts the linked list to the C# built-in list format.
        /// </summary>
        /// <returns></returns>
        public List<T> ToList()
        {
            SinglyLinkedListNode<T> current = this.Head;
            List<T> listOut = new List<T>();

            foreach (SinglyLinkedListNode<T> node in this)
            {
                listOut.Add(node.Value);
            }

            return listOut;
        }
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
