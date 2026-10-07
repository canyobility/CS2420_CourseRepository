using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Assignments.LeetcodePracticeDifficultyMedium.LinkedLists
{
    public abstract class LinkedListShared
    {
        public int count { get; protected set; }
        protected bool IndexInRange(int index) => (index > 0) && (index < count);
    }
}
