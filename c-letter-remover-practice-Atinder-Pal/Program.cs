using System;

namespace c_letter_remover_practice_Atinder_Pal
{
    class Program
    {
        
        static void Main(string[] args)
        {
            /*
            Title: C# Letter Remover Practice
            Purpose: To remove a letter(s) from a string
            Author: Atinder Pal
            Last Modified Date: Aug 13, 2020
            */
            string enteredString, outputString;
            const string prompt= "Press 'esc' to exit!!";
            string lettersToRemove,lettersNotFound,lettersNotFound1;
            bool toExit = false;
            ConsoleKeyInfo cK;

            Console.WriteLine("This application removes letter(s) of your choice from the string you provide");
            
            do
            {
                outputString="";
                lettersNotFound="";
                lettersNotFound1="";
                
                Console.WriteLine("\nPlease enter a string or "+ prompt);
               
                    
                    cK = Console.ReadKey();
                    if(cK.Key.Equals(ConsoleKey.Escape))
                    {                        
                        toExit=true;
                        
                    } 
                    if(!toExit)
                    {

                    
                    enteredString = cK.KeyChar+Console.ReadLine();
                    Console.WriteLine($"\nPlease enter the char(s)/letter(s) you want to remove from '{enteredString}'");
                    lettersToRemove= Console.ReadLine().ToLower();                                      

                    foreach(char d in lettersToRemove)
                    {
                        if(!enteredString.ToLower().Contains(d))
                        {
                            lettersNotFound=lettersNotFound + d+" ";
                            lettersNotFound1= lettersNotFound1+d;
                        }
                    }

                    if(lettersNotFound1 != "")
                    {
                        Console.WriteLine($"The letters {lettersNotFound} were not found in your string '{enteredString}'");
                        
                    }
                    if(lettersToRemove == lettersNotFound1)
                    {
                        Console.WriteLine($"Your string remains same as: '{enteredString.Trim()}'");
                    }
                    else
                    {
                        foreach(char c in enteredString)
                        {
                        if(!lettersToRemove.Contains(char.ToLower(c)))
                        {
                            outputString = outputString + c;
                        }
                        }   
                    
                    Console.WriteLine($"String after removing the letter(s) '{lettersToRemove}' is as:  '{outputString.Trim()}'"); 
                    }  
                    }
                    
                           
                        
                
            }while(!toExit);
                
        }
    }
}
