using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace c_assignment_crud_Atinder_Pal
{
    
    class Program
    {
        static int inputMenuChoice;
        static void Main(string[] args)
        {
             /*
                Title: C# Introduction Assignment – CRUD
                Purpose: Allow the user to input StudentID (int 1 to 999) of students in class and maintain the dataset and allow the user to manipulate the dataset - add, display, edit, import a file, export to a file.

                Author: Atinder Pal
                Last Modified: August 16, 2020
            */   

            //Declaring a list of initial capacity 10
            List<int> studentIdRecord = new List<int> (10);
            string userName="";
            bool toExit =false;
            
            Console.WriteLine("WELCOME TO STUDENTID RECORD MANAGER");
            Console.Write("Please enter your name:");
            userName = Console.ReadLine();

            while(!toExit)
            {                
                inputMenuChoice = (int)ValidateInput("======================================\nPlease choose from the following Menu:\n1: Add a studentId to StudentID Record\n2: Display the StudentID Record\n3: Edit the StudentID Record\n4: Delete studentID from the StudentID Record\n5: Import a File \n6: Export to a File\n7: Exit the application", 7);

                switch(inputMenuChoice)
                {
                    case 1:
                    {
                        AddStudentId(studentIdRecord);
                    }
                    break;

                    case 2:
                     {
                        DisplayStudentIdRecord(studentIdRecord);
                        
                    }
                    break;

                    case 3:
                    {
                        EditStudentIdRecord(studentIdRecord);
                        
                    }
                    break;

                    case 4:
                    {
                        DeleteStudentId(studentIdRecord);
                    }
                    break;

                    case 5:
                    {
                        ReadFromFile(ValidateFileName("Please enter the Filename(end with .txt) you want to import(read): or press '0' to go to main Menu"));
                    }
                    break;

                    case 6:
                    {                        
                        WriteToFile(ValidateFileName("Your StudentID record will be exported to a text file.\nPlease enter a Filename(end with .txt) you want to export to: or press '0' to go to main Menu"), studentIdRecord);
                    }
                    break;

                    case 7:
                    {
                        Console.WriteLine("Exiting the application");
                        Console.WriteLine($"===GoodBye {userName}!=== ");
                        Console.WriteLine("======================================");
                        toExit=true; 
                    }
                    break; 

                    default:
                    {
                        Console.WriteLine($"Your input should be between 1 and 7 inclusive");
                    }
                    break;                                                  
                }
            }            
        }

        //Method to add studentID to the list
        //Use this method if you want Dynamically sized list otherwise to store nly 10 elements- use the method commented below this method
        static void AddStudentId(List<int> theList)
        {
            //--------The commented code in this method was to not allow to exceed the list size from 10. but in challenge- list should be dynamically size//
            bool toContinue = true;
            while(toContinue)
            {                    
                int studentId = ValidateInput($"Please enter the StudentID #{theList.Count+1} or press '0' to go back to main Menu: ", 999);
                if(studentId == 0)
                {
                    toContinue = false;
                }
                else
                {
                    //if the studentId does not exist in the list- add it to list
                    if(!DuplicateCheck(studentId, theList))
                    {                            
                        theList.Add(studentId);
                        theList.Sort();
                    }                        
                }
            }               
        }

        //---------- Use this method if List should only contan upto 10 elements--------------
        // static void AddStudentId(List<int> theList)
        // {
        //     int specifiedListCapacity =10;  
        //     bool toContinue = true;

        //     //if there are already 10 records in list- Do not allow to add any more
        //     if(theList.Count== specifiedListCapacity)
        //     {
        //         Console.WriteLine("Sorry, You can not add more than 10 studentIDs!"); 
        //     }
                
        //     //Allow user to add studentID only if there are less than 10 records in the list
        //     else
        //     {
        //         while(toContinue && theList.Count < specifiedListCapacity)
        //         {                    
        //             int input = ValidateInput($"Please enter the StudentID #{theList.Count+1} or Press '0' to go back to previous Menu: ", 999);
        //             if(input == 0)
        //             {
        //                 toContinue = false;
        //             }
        //             else
        //             {
        //                 //if the studentId does not exist in the list- add it to list
        //                 if(!DuplicateCheck(input, theList))
        //                 {                            
        //                     theList.Add(input);
        //                     theList.Sort();
        //                 }                        
        //             }
        //         }                    
        //      }                                 
        // }

        // Method to Display the StudentID Record
        static void DisplayStudentIdRecord(List<int> theList)
        {
            if(theList.Count==0)
            {
                Console.WriteLine("The StudentID Record is empty. Nothing to display!");
            }
            else
            {
                Console.WriteLine("The StudentID Record is as :");
                for(int i=0;i<theList.Count;i++)
                {
                    Console.WriteLine($"{i+1}.  {theList[i]}");
                }
            }            
        }   
        // Method to Edit studentID in the StudentID Record
        static void EditStudentIdRecord(List<int> theList)
        {           
            int intOption = -1;
            bool isValid = false;

            if(theList.Count!=0)
            {                               
                intOption = ValidateInput("How would you like to edit studentID-\nPress- 1:By Index of studentID   2:By Value of studentID  or press '0' to go to main Menu", 2);           
                
                if( intOption != 0)
                {                                     
                    switch(intOption)
                    {
                        case 1:
                        {                           
                            int indexStudentId = ValidateInput("Please enter the \"index\" of the studentID you want to edit: or press '0' to go to main Menu", theList.Count);    
                            if(indexStudentId !=0)   
                            {
                                while(!isValid)
                                {
                                    int newStudentId = ValidateInput("Please enter the new studentID to replace the older with: or press '0' to go to main Menu", 999);  
                                    if(newStudentId !=0)
                                    {
                                        if(!DuplicateCheck(newStudentId, theList))
                                        {
                                            theList[indexStudentId-1] = newStudentId;
                                            theList.Sort();
                                            isValid=true;
                                        }    
                                    }
                                    else
                                    isValid =true;
                                                                                   
                                }         
                            }                           
                        }
                        break;         
                
                        case 2:
                        {   
                            while(!isValid)
                            {
                                int valueStudentId = ValidateInput("Please enter the studentID you want to edit: or press '0' to go to main Menu", 999);
                                if(valueStudentId !=0)
                                {
                                    if(theList.Contains(valueStudentId))  
                                    {
                                        while(!isValid)
                                        {
                                            int newStudentId = ValidateInput("Please enter the new studentID to replace the older with: or press '0' to go to main Menu", 999);
                                            if(!DuplicateCheck(newStudentId, theList))
                                            {
                                                theList[theList.IndexOf(valueStudentId)] = newStudentId;
                                                theList.Sort();
                                                isValid=true;
                                            }                                    
                                        }                                                                
                                    }  
                                    else
                                    Console.WriteLine($"StudentID: \'{valueStudentId}\' does not exist in the StudentID record.");   
                                }
                                else
                                isValid= true;                                          
                            }                 
                        }
                        break;
                    }                    
                }   
            } 
            else
            Console.WriteLine("StudentID record is empty.Please add something before you edit.");                  
        }
        // Method to delete studentID from the StudentID Record
        static void DeleteStudentId(List<int> theList)
        {            
            int intOption;
            if(theList.Count != 0)
            {
                intOption = ValidateInput("How would you like to delete studentID-\nPress- 1:By Index of studentID   2:By Value of studentID  or press '0' to go to main Menu", 2);
                if(intOption != 0)
                {
                    switch(intOption)
                    {
                        case 1:
                        {                   
                            int indexStudentId = (int)ValidateInput("Please enter the \"index\" of the studentID you want to delete: or press '0' to go to main Menu", theList.Count); 
                            if(indexStudentId !=0)
                            {
                                theList.RemoveAt(indexStudentId-1);
                            }                           
                        }                                              
                        break;

                        case 2:
                        {    
                            bool isValid = false;
                            while(!isValid)
                            {                      
                                int valueStudentId = ValidateInput("Please enter the studentID you want to delete: or press '0' to go to main Menu", 999);             
                                if(valueStudentId != 0)
                                {
                                    isValid= theList.Remove(valueStudentId);
                                    if(!isValid)
                                    {
                                        Console.WriteLine($"StudentID: \'{valueStudentId}\' does not exist in the StudentID record.");
                                    } 
                                } 
                                else
                                isValid = true;          
                            }                       
                        }
                        break;                    
                    }                
                }
                                 
            }
            else
            Console.WriteLine("StudentID record is empty.Please add something before you delete.");                      
        }

        static int ValidateInput(string Prompt, int largestChoice)
        {
            bool toExit =false;
            int userInputToInt=-1;

             //Citation for Sentinel value Loop
            // https://github.com/TECHCareers-by-Manpower/OddEvenSorter/blob/0e9c9e590a22d1059ed1bd75c440007d485606ac/Program.cs
            //Although I understand the logic and know the code to implement sentinel loop- I just used the above github repo by "James Grieve" for reference
            while(!toExit)
            {
                Console.WriteLine(Prompt);      
                                
                    try
                    {
                        //Trims leading and trailing whitespaces 
                        userInputToInt = int.Parse(Console.ReadLine().Trim());
                        //Validating int 0 as input as- '0' is sentinel value for that method
                        if(userInputToInt == 0)
                        {
                            toExit=true;
                        }     
                        //Prohibiting user to enter 0, negative int and more than the specified largestChoice
                        else if(userInputToInt < 1 || userInputToInt > largestChoice)
                        {
                            Console.WriteLine($"Your input should be between 1 and {largestChoice} inclusive");
                        }  
                        else
                        {
                            toExit = true;
                        }   
                    }
                    catch
                    {
                        Console.WriteLine("You entered invalid input, Please try again.");
                    }                
            }
            //End Citation
            return userInputToInt;
        } 

        static bool DuplicateCheck(int inputStudentId, List<int> theList) 
        {
            if(theList.Contains(inputStudentId))
            {
                Console.WriteLine($"StudentID: {inputStudentId} already exists in StudentID record. Please Enter a new StudentID");
                return true;
            }
            else 
                return false;                   
        } 
        //Citation
        //https://www.guru99.com/c-sharp-stream.html
        //I had to look at Stream Reader and writer tutorial from this site and followed the code in the same manne
        //Go to ReadMe.md for details on how this code works
        static void ReadFromFile(string pathToFile)
        {
            if(pathToFile != "0")
            {
                //String path = @"D:\Example.txt";
                if (File.Exists(pathToFile))
                {
                    using (StreamReader sr = File.OpenText(pathToFile))
                    {
                        String s = "";

                        while ((s = sr.ReadLine()) != null)
                        {
                        Console.WriteLine(s);
                        }
                    }
                    Console.ReadKey();
                }
                else
                Console.WriteLine($"{pathToFile} does not exist");
            }            
        }      

        static void WriteToFile(String pathToFile, List<int> theList)  
        {
            if(pathToFile != "0")
            {
                if(theList.Count != 0)
                {
                    if (File.Exists(pathToFile))
                    {
                        int intOption = ValidateInput("Filename already exists.\n Press 1:Append to the file  2:Overwrite the file", 2);
                        if (intOption == 2)
                        {
                            File.Delete(pathToFile);
                        }            
                    }
                    using (StreamWriter sr = File.AppendText(pathToFile))
                        {
                            for(int i=0;i<theList.Count;i++)
                            {
                                sr.WriteLine(theList[i]);                        
                            }    
                            sr.Close();                     
                        }
                    Console.WriteLine($"StudentID record contents have been exported to {pathToFile}");                    
                }
                else
                Console.WriteLine("StudentID record is empty. There is nothing to export.Please add something before you export.");  
            }                      
        }    
        //End Citation      

        static string ValidateFileName(String Prompt)
        {
            string filename= "";
            bool toExit = false;
            while(!toExit)
            {
                Console.WriteLine(Prompt);
                filename = Console.ReadLine().Trim();

                if(filename == "0")
                {
                    toExit=true;
                }
                else if(String.IsNullOrWhiteSpace(filename) || String.IsNullOrEmpty(filename) || !filename.ToLower().EndsWith(".txt") )
                {
                    Console.WriteLine("It's not a valid Text Filename");                    
                }  
                else
                toExit=true;          
            }
            return filename;
        }
    }
}
