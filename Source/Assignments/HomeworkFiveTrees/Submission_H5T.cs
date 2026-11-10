// Homework 5: Trees  (starter code)
// 1. Finish every method marked TODO. Use loops, not recursion.
// 2. Write your answers for Questions 1 to 5 in the comment box at the bottom of this file.
// Do not change the tests in Main. Run with: dotnet run
using System;

public class Submission_H5T
{
    public static void Main(string[] args)
    {
        // ======================= TESTS (do not change) =======================
        var empty = new BinarySearchTree();
        var one = new BinarySearchTree();
        one.Insert(7);
        var t1 = new BinarySearchTree();
        foreach (int v in new[] { 50, 30, 70, 20, 40, 80, 35, 45 }) t1.Insert(v);
        var line = new BinarySearchTree();
        foreach (int v in new[] { 10, 20, 30, 40, 50 }) line.Insert(v);

        Console.WriteLine("== Min ==");
        Console.WriteLine(t1.Min());
        Console.WriteLine(line.Min());
        Console.WriteLine(one.Min());
        Console.WriteLine();

        Console.WriteLine("== Max ==");
        Console.WriteLine(t1.Max());
        Console.WriteLine(line.Max());
        Console.WriteLine(one.Max());
        Console.WriteLine();

        Console.WriteLine("== Depth ==");
        Console.WriteLine(t1.Depth(50));
        Console.WriteLine(t1.Depth(70));
        Console.WriteLine(t1.Depth(35));
        Console.WriteLine(t1.Depth(99));
        Console.WriteLine(line.Depth(50));
        Console.WriteLine(empty.Depth(5));
        Console.WriteLine();
    }
}

// ======================= CLASSES =======================
public class Node
{
    public int Value;
    public Node? Left;
    public Node? Right;
    public Node(int value) { Value = value; }
}

public class BinarySearchTree
{
    private Node? root;
    public Node? Root => root;

    public bool Insert(int value)
    {
        Node newNode = new Node(value);
        if (root == null) { root = newNode; return true; }
        Node temp = root;
        while (true)
        {
            if (newNode.Value == temp.Value) return false;
            if (newNode.Value < temp.Value)
            {
                if (temp.Left == null) { temp.Left = newNode; return true; }
                temp = temp.Left;
            }
            else
            {
                if (temp.Right == null) { temp.Right = newNode; return true; }
                temp = temp.Right;
            }
        }
    }

    public bool Contains(int value)
    {
        Node? temp = root;
        while (temp != null)
        {
            if (value < temp.Value) temp = temp.Left;
            else if (value > temp.Value) temp = temp.Right;
            else return true;
        }
        return false;
    }


    /// <summary>
    /// Finds and returns the smallest value saved in the tree. 
    /// </summary>
    /// <returns>Int: Smallest Value.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public int Min()
    {
        Node temp = root;

        if (temp is null)
        {
            throw new ArgumentOutOfRangeException();
        }

        while (temp.Left != null)
        {
            temp = temp.Left;
        }

        return temp.Value;
    }


    /// <summary>
    /// Finds and returns the largest value saved in the tree. 
    /// </summary>
    /// <returns>Int: Largest value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the root node is null.</exception>
    public int Max()
    {
        Node temp = root;

        if (temp is null)
        {
            throw new ArgumentOutOfRangeException();
        }

        while (temp.Right != null)
        {
            temp = temp.Right;
        }

        return temp.Value;
    }


    /// <summary>
    /// Computes the depth of a specified node. If that node is not present in the
    /// tree, -1 will be returned. 
    /// </summary>
    /// <param name="value">Node to search for.</param>
    /// <returns>Found depth.</returns>
    public int Depth(int value)
    {
        int foundDepth = 0;
        Node temp = root;
        while (temp != null)
        {
            if (temp.Value == value) { return  foundDepth; }
            foundDepth++;

            if (value < temp.Value) temp = temp.Left;
            else if (value > temp.Value) temp = temp.Right;
            

        }

        return -1;
    }
}

/* ======================= WRITTEN ANSWERS (Questions 1 to 5) =======================
   Type your answers here. Draw trees with spaces and slashes, like the trees on the
   assignment page.

   ---- Question 1 ----
   a) root: 50
   b) leaves: 35, 45
   c) internal nodes: 30, 40, 70
   d) parent of 35: 40 
      sibling of 20: 40 
   e) depth of 35: 3
      height of node 30: 1
   f) height of tree: 3          
      size: 8
   g) degree of 70: 1
   h) valid BST? why: Yes, all right children nodes are greater than the left children. 

   ---- Question 2 ----   (Yes / No)
   Tree A:                  
       Full? Yes
       Perfect? No
       Complete? Yes
       Reasons for each No:

    Tree B:                  
       Full? Yes
       Perfect? Yes
       Complete? Yes
       Reasons for each No:

    Tree C:                  
       Full? Yes
       Perfect? No
       Complete? Yes
       Reasons for each No:

   ---- Question 3 ----
   Note: the trees for Questions three and four were generated with Visual Studio using the draw.io extention. I 
         used Visual Studio for the remainder of this submission as my primary IDE.

   a) tree: Refer to drawmBstQ3.png for the final drawing: Source\Assignments\HomeworkFiveTrees\drawnBstQ3.png

   b) height: 3                  number of leaves: 5
   c) Contains(32) visits: 4              returns: True
      Contains(60) visits: 3              returns: False

   ---- Question 4 ----
   a) tree: Refer to drawmBstQ4.png for the final drawing: Source\Assignments\HomeworkFiveTrees\drawnBstQ4.png

      height: 4
   b) nodes visited by Contains(50): 4     
        Big O: n       
        acts like: Singly linked list 

   ---- Question 5 ----
   a) tree: Refer to drawmBstQ5.png for the final drawing: Source\Assignments\HomeworkFiveTrees\drawnBstQ5.png

   b) children of 70 (show math):
        Left: 2(1) + 1 = (i: 3, v: 40)
        Left: 2(1) + 2 = (i: 4, v: 65)

   c) parent of 35 (show math):
        Index: 8
        Parent: (8 - 1) / 2 => 
                (7 / 2) => 
                Floor(3.5) 
                = (i: 3, v: 30)

   d) why 65 is a leaf (show math):
        Total Nodes: 8
        Index: 4
        Proof: 2(4) + 1 => 
               8 + 1 =>
               9 =>
               9 < 8 = False
*/
