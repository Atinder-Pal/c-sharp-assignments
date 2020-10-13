# C# Introduction Assignment- CRUD

Purpose: Allow the user to input StudentID (int 1 to 999) of students in class and maintain the dataset and allow the user to manipulate the dataset - add, display, edit, import a file, export to a file.

Author: Atinder Pal
Last Modified: August 16, 2020

Link to Trello Board: https://trello.com/b/HtoupB7v/c-introduction-assignment-crud


/*Citation Summary
1. Citation for Sentinel value Loop
https://github.com/TECHCareers-by-Manpower/OddEvenSorter/blob/0e9c9e590a22d1059ed1bd75c440007d485606ac/Program.cs
Although I understand the logic and wrote the code to implement sentinel value loop, but applying sentinel value loop can sometimes get confusing.
So,I just used the above github repo by "James Grieve" for reference.

2. Citation for Import from and Export to a file
https://www.guru99.com/c-sharp-stream.html
I had looked up the tutorials on the above website to understand the Stream Reader and Stream Writer

a) In Import from File method:
We create Stream Reader instance and pass it path to file
using (StreamReader sr = File.OpenText(pathToFile))
using keyword will help in closing the stream after we are done reading the file
File.OpenText will open the file for Read only
String s = "";

while ((s = sr.ReadLine()) != null)
{
Console.WriteLine(s);
}
Here we initialise a string s and ReadLine() will read each line in the file and feed it to string s via the Stream Reader sr
We will then print contents of string s on Console.
We will keep on reading each line in file until the whole file is done which will return null in that case.

b) In Export to File method:
We create a Stream Writer instance sr and pass it path to File
File.AppendText opens the file to write to a new file or append to existing file
using (StreamWriter sr = File.AppendText(pathToFile))

We then take one element of list at a time and then write to a new line in the file until there is no element left to write from the list
for(int i=0;i<theList.Count;i++)
{
    sr.WriteLine(theList[i]);                        
}   

then we close the Stream Writer instance
sr.Close(); 
*/