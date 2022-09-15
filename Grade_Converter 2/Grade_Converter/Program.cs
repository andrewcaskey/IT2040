using System;
using System.Collections.Generic;

namespace GradeConverter
{
    class Program
    {
        //this function is to take input of numbers to be graded
        static float number()
        {
            float input;
            try
            {
                Console.WriteLine("Enter the score to be converted");
                input = float.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: only numbers 1-100 allowed");
                return -1;
            }
            return input;
        }

        //this function is to convert the number grade to letter grade
        static char letterGrade(float numbers)
        {
            char letter = '\0'; //

            if (numbers >= 90)
            {
                letter = 'A';
            }

            else if (numbers >= 80)
            {
                letter = 'B';
            }

            else if (numbers >= 70)
            {
                letter = 'C';
            }

            else if (numbers >= 60)
            {
                letter = 'D';
            }
       
            else if (numbers < 60)
            {
                letter = 'F';
            }

            return letter;
        }

        //display grade average
        static void grade_Average(int n, List<float> num)
        {
            float sum = 0;
            foreach (float item in num)
            {
                sum += item;
            }

            float avg = sum / n;

            Console.WriteLine($"Number of grade is {n} ");
            Console.WriteLine($"Average grade: {avg}, which is a {letterGrade(avg)} ");
        }

        static void Main(string[] args)
        {
            while (true) // this while loop will iterate until user does not enters n or N to not enter the grade
            {

                Console.Write("Please enter your first and last name :: ");
                string Name = Console.ReadLine();

                Console.WriteLine($"Hello {Name} Welcome to the Grade Converter!");

                Console.WriteLine("\nEnter the number of grades you need to convert: ");
                int numAmount = Convert.ToInt32(Console.ReadLine());

                List<float> numberGrades = new List<float>();

                //this for loop iterates to take user input of numbers
                for (int value = 0; value < numAmount; value++)
                {

                    //number function is called to input number grades
                    float num = number();
                    if (num >= 0.0 && num <= 100.0)
                    {
                        numberGrades.Add(num);
                    }
                    else if ((num < 0 || num > 100)) 
                    {
                        Console.WriteLine($"Grades are to be entered only between 0-100. Please enter again.");
                        value--;
                    }
                }

                // gets letter grade
                foreach (float item in numberGrades)
                {
                    char gradeLetter = letterGrade(item); 
                    Console.WriteLine($"A score of {item} is a {gradeLetter}");
                }

                Console.WriteLine("\n\nGrade Statistics");
                Console.WriteLine("----------------------------------");

                grade_Average(numAmount, numberGrades);

                Console.WriteLine("Do you want to convert more grades ? y/n");
                string choice = Console.ReadLine();
                if (choice.ToUpper().Equals("N")) 
                    break;
            }
        }
    }
}


