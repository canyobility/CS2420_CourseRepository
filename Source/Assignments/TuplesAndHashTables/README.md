Algorithms & Datastructures 11/02/2026

Would like to apologize for getting this submission in a day or two late. 

# Output: 

		Executing command for submission tht
		== A2 Summarize ==
		62 98 81.8
		50 50 50

		== B2 HashTable ==
		True
		False
		True 0
		False 0

		== B3 MostFrequentWord ==
		(the, 3)
		(red, 3)

		== B3 CommonNames ==
		Leo, Sam


# A1: 
	
	/* ======================= A1: PREDICT THE OUTPUT =======================
	   Write what each line prints BEFORE you run the code.

	   Line 1: 77
	   Line 2: 88
	   Line 3: true
	   Line 4: "lab"
	   Line 5: 2

	   Why do Line 4 and Line 5 act differently? (2 or 3 sentences)
   
	   Line 4 writes d.tag, which is a string, while line 5 prints an int value, being the 
	   number of elements in list Scores.  
    
		var d = Tag: "Lab" => string("lab")
				Scores: new List<int> { 70, 80 } => int (list.Count())

		I suspect I may be misunderstanding this question, please let me know if this answer is
		incorrect / not what your looking for. 
	*/

	/* ======================= B1: HASH TABLE BY HAND =======================
	   (a) Chaining. Example: 3: apple -> plum -> null

	   0: null
	   1: null
	   2: null
	   3: null
	   4: null
	   5: null
	   6: null

	   Insert("apple")
	   0: null
	   1: null
	   2: null
	   3: "Apple"
	   4: null
	   5: null
	   6: null

	   Insert("plum")
	   0: null
	   1: null
	   2: null
	   3: Tree (Red/black or AVL) (apple => plum)
	   4: null
	   5: null
	   6: null

	   Insert(null)
	   0: null
	   1: null
	   2: null
	   3: Tree (Red/black or AVL) (apple => plum)
	   4: null
	   5: null
	   6: null

	   (b) Linear probing. Write the key in each slot, or "empty".

	   slot 0: "empty"
	   slot 1: "empty"
	   slot 2: "empty"
	   slot 3: "empty"
	   slot 4: "empty"
	   slot 5: "empty"
	   slot 6: "empty"

	   Insert("apple")
	   slot 0: "empty"
	   slot 1: "empty"
	   slot 2: "empty"
	   slot 3: "apple"
	   slot 4: "empty"
	   slot 5: "empty"
	   slot 6: "empty"

	   Insert("plum")
	   slot 0: "empty"
	   slot 1: "empty"
	   slot 2: "empty"
	   slot 3: "apple"
	   slot 4: "plum"
	   slot 5: "empty"
	   slot 6: "empty"

	   Insert(null) // Nothing to insert. 
	   slot 0: "empty"
	   slot 1: "empty"
	   slot 2: "empty"
	   slot 3: "apple"
	   slot 4: "plum"
	   slot 5: "empty"
	   slot 6: "empty"
	*/
