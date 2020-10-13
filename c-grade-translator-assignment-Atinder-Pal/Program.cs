using System;

namespace c_grade_translator_assignment_Atinder_Pal
{
    class Program
    {
        static void Main(string[] args)
        {
            double numericGrades;
            string letterGrade="unassessable";
            bool toExit= false;
            string grades="";

            Console.WriteLine("\n--------Welcome to the Grade Translator App--------"); 
            Console.WriteLine("Here we will tell you your Letter Grade based on your scores/marks");

            while(!toExit)
            
            {
                            
                Console.WriteLine("\nPlease enter your Numeric Grades (Marks)");
                string value = Console.ReadLine();
                
                //Citation
                //https://stackoverflow.com/questions/14304591/check-if-user-input-is-a-number
                //Reason to borrow code- I din't know TryParse's function and upon googling- I found it can test if the user's input is of the same type as we expect in the program
                //Here double.TryParse() will work like normal double.parse and try to change the value to a double and store the outcome in numericGrades and returns true if the conversion succeeded else will return false.
                //https://docs.microsoft.com/en-us/dotnet/api/system.double.tryparse?view=netcore-3.1
                
                if(  ! double.TryParse(value, out numericGrades) )
                //End Citation
                {
                    System.Console.WriteLine("Please try again.Enter a numeric score.");
                    letterGrade="unassessable";
                }
                
                else if(numericGrades>100 || numericGrades<0)
                {
                    System.Console.WriteLine("Please try again.Your marks/scores should be in the range 0 to 100");
                    letterGrade="unassessable";
                }

                else if (numericGrades>=97 && numericGrades<=100)
                {
                letterGrade ="A+";
                }
                
                else if(numericGrades>=90)
                {
                    letterGrade ="A";
                }
                
                else if(numericGrades>=85)
                {
                    letterGrade ="A-";
                }
                
                else if(numericGrades>=80)
                {
                    letterGrade ="B+";
                }
            
                else if(numericGrades>=75)
                {
                    letterGrade ="B";
                }
                
                else if(numericGrades>=70)
                {
                    letterGrade ="B-";
                }
                
                else if(numericGrades>=65)
                {
                    letterGrade ="C+";
                }
                
                else if(numericGrades>=60)
                {
                    letterGrade ="C";
                }
            
                else if(numericGrades>= 55)
                {
                    letterGrade ="C-";
                }
                
                else if(numericGrades>=50)
                {
                    letterGrade ="D";
                }
                
                else if(numericGrades>=0)
                {
                    letterGrade ="F";
                }
                
                Console.WriteLine($"Your grade is {letterGrade}               (Press 'q' to quit or any other key to ocntinue)");
                
                if(letterGrade != "unassessable")
                {
                    if(grades=="" )
                    {
                        
                        grades= numericGrades.ToString()+":"+letterGrade;
                    }
                    else
                    {
                     grades= grades + ",   "+ numericGrades.ToString()+":"+letterGrade;
                    }                                 

                }
                //Console.WriteLine("-------Press 'q' to exit, else press any key to continue-------");
                
                //Citation
                //https://docs.microsoft.com/en-us/dotnet/api/system.console.readkey?view=netcore-3.1
                if (Console.ReadKey().Key.ToString().ToLower().Equals("q"))
                //End Citation
                {
                    toExit= true;
                }
                
                
            }   
            Console.WriteLine($"\nHistory of your grades assessed here is as:\n{grades}");
            
        } 
    }
}
