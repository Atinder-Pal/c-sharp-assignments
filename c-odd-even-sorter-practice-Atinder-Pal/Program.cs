using System;
using System.Linq;

namespace c_odd_even_sorter_practice_Atinder_Pal
{
    class Program
    {
      
        static void Main(string[] args)
        {
            /*
            Title: C# Odde/Even Sorter Practice
            Purpose: Given an array of maximum 10 numbers- application sorts odd numbers from lowest to highest and even numbers from lowest to highest and print them in the order:sorted odd numbers,sorted even numbers
            (example - [6, 4, 3, 7, 8] would become [3, 7, 4, 6, 8])

            Author: Atinder Pal
            Last Modified: Aug 13, 2020
            */
            welcomePrompt();
            int[] myNumbers = createArray();
            sortArray(myNumbers);           
            
        }

        static int[] createArray()
        {
            int updatedArrayLength = -1;
            int[] theArray = new int[10];
            
            System.Console.WriteLine("Create Array or type \"done\" to finish");
            for(int i=0;i<theArray.Length;i++)
            {
                try
                {
                System.Console.Write($"Enter integer #{i+1}: ");
                string userInput = Console.ReadLine();
                
                    if(userInput.ToLower() == "done" && i==0)
                    {
                        
                        throw new Exception("We need atleast one element, array can't be empty");
                        
                    }
                    else if(userInput.ToLower() == "done")
                    {
                        updatedArrayLength =i;
                        //get out of for loop
                        i = 10;
                        //ignore unfilled values by creating new array with filled values only
                        int[] newArray = new int[updatedArrayLength];
                        for(int j =0; j< updatedArrayLength;j++)
                        {
                            newArray[j] = theArray[j];
                        }
                        return newArray;
                        
                    }
                    else
                    {
                        theArray[i] = int.Parse(userInput);
                        updatedArrayLength = i;
                    }                
                }
                
                catch
                {
                    
                    Console.WriteLine("Please enter an integer or type \"done\" to finish");
                    i--;
                }
                
                
            }
            return theArray;
            
                //to ignore unfilled values in the array we create new array upto the filled values
                // int[] newArray = new int[updatedArrayLength];
                // for(int j =0; j< updatedArrayLength;j++)
                // {
                //     newArray[j] = theArray[j];
                // }
                // return newArray;
           
        }

        
        static void sortArray(int[] theArray)
        {
            //Citation
            //https://leetcode.com/problems/sort-an-array/discuss/709756/C-three-different-solutions-(97)
            //OrderBy method sorts this array in ascending order based on the key i which is integers in the array.

            theArray= theArray.OrderBy(i=>i).ToArray();

            //End Citation

            int[] oddValues = new int[]{};
            int[] evenValues = new int[]{};
            for(int i =0;i<theArray.Length;i++)
            {
                if(theArray[i] %2 !=0)
                {
                    oddValues = oddValues.Concat(new int[] {theArray[i]}).ToArray();
                }
                else
                {
                    evenValues = evenValues.Concat(new int[] {theArray[i]}).ToArray();
                }                
            }
            //concatenating sorted even values with sorted odd values
            theArray = oddValues.Concat(evenValues).ToArray();
            Console.WriteLine("\nYour Array is sorted!!");
            printArrayElements(theArray);
            
        }
        static void printArrayElements(int[] theArray)
        {
            foreach(int number in theArray)
            {
                System.Console.Write(number + " ");
            }
        }

        static void welcomePrompt()
        {
            Console.WriteLine("Welcome to Odd/Even Sorter.\nHere you can enter upto 10 numbers and we will sort the odd numbers and even numbers separately from lowest to highest\n");
        }
    }
}
