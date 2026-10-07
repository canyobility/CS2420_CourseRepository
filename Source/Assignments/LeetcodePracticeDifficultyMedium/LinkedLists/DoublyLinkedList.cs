using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Assignments.LeetcodePracticeDifficultyMedium.LinkedLists
{
    public class DoublyLinkedList<T> : LinkedListShared
    {
        DoublyLinkedListNode<T> head;
        DoublyLinkedListNode<T> tail;
        int count;

        public void Append(T value) => throw new NotImplementedException();
        public void Rotate(int rotations) => throw new NotImplementedException();

        public DoublyLinkedListNode<T> GetAtIndex() {  return head; }
        public override string ToString() => throw new NotImplementedException();
        
    }
}
