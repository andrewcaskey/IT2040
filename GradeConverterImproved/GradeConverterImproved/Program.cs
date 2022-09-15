using System;
using System.Collections.Generic;

namespace ImprovedGradeConverter
{
    class Program
    {

        // Gets The User's First And Last Name
        static string getName()
        {
            Console.Write("Please Enter Your First Name And Last Name: ");
            string userName = Console.ReadLine();

            return userName;
        }

        // Gets The Number Of Grades The User Wants To Enter.
        static int getNumberOfGrades()
        {
            Console.Write("Enter The Number Of Grades You Need To Convert: ");
            int numberOfGrades;
            while (true)
            {
                try
                {
                    numberOfGrades = int.Parse(Console.ReadLine());
                    return numberOfGrades;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Only Numbers Allowed");
                }
            }
        }

        // Prints The Letter Grades And The Numerical Scores For The Grades Stored
        static void printGradeReport(List<float> scores)
        {
            Console.WriteLine("\nGrade Report\n-------------------------");

            // A = 90-100, B = 80-89, C = 70-79, D = 60 - 69, F Lower Than 60
            foreach (float score in scores)
            {
                string letterGrade = getLetterGrade(score);

                Console.WriteLine($"A Score Of {score} Is a '{letterGrade}' Grade");
            }
        }

        // Prints The Statistics For The Grades List.
        // (Number Of Grades, Average Grade, Maximum Grade, Minimum Grade)
        static void printGradeStatistics(List<float> scores)
        {
            Console.WriteLine("\nGrade Statistics\n-------------------------");

            float averageGrade = getAverageGrade(scores);
            float maximumGrade = getMaximumGrade(scores);
            float minimumGrade = getMinimumGrade(scores);

            Console.WriteLine($"Number of grades: {scores.Count}");
            Console.WriteLine($"Average Grade: {averageGrade} Which Is a '{getLetterGrade(averageGrade)}'");
            Console.WriteLine($"Maximum Grade: {maximumGrade} Which Is a '{getLetterGrade(maximumGrade)}'");
            Console.WriteLine($"Minimum Grade: {minimumGrade} Which Is a '{getLetterGrade(minimumGrade)}'");
        }

        // Calculates And Returns The Average Grade
        static float getAverageGrade(List<float> scores)
        {
            float total = 0.0f;
            foreach (float score in scores)
            {
                total += score;
            }

            return total / scores.Count;
        }

        // Returns The Highest Grade In The List Of Grades
        static float getMaximumGrade(List<float> scores)
        {
            float max = float.MinValue;
            foreach (float score in scores)
            {
                if (score > max)
                {
                    max = score;
                }
            }

            return max;
        }

        // Returns The Lowest Grade In The List Of Grades
        static float getMinimumGrade(List<float> scores)
        {
            float min = float.MaxValue;
            foreach (float score in scores)
            {
                if (score < min)
                {
                    min = score;
                }
            }

            return min;
        }

        static float getScore()
        {
            float grade;
            while (true)
            {
                Console.Write("Enter The Score To Be Converted: ");
                try
                {
                    grade = float.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Only Numbers Allowed");
                }
            }
            return grade;
        }

        static string getLetterGrade(float score)
        {
            //A = 90-100, B = 80-89, C = 70-79, D = 60 - 69, F lower than 60
            if (score >= 90)
            {
                return "A";
            }
            else if (score >= 80)
            {
                return "B";
            }
            else if (score >= 70)
            {
                return "C";
            }
            else if (score >= 60)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("\nGrade Converter\n-------------------------\n");

            string userName = getName();
            string doAgain;

            Console.WriteLine($"\nHello {userName}!\nWelcome To The Grade Converter!\n");

            do
            {
                // Get Number Of Grades
                int numberOfGrades = getNumberOfGrades();
                List<float> scores = new List<float>();

                // Prompt The User To Enter The Grades.
                Console.WriteLine("\nInput Grades\n-------------------------\n");
                for (int i = 0; i < numberOfGrades; i++)
                {
                    scores.Add(getScore());
                }

                // Print Grade Report
                printGradeReport(scores);

                // Print Grade Statistics
                printGradeStatistics(scores);
                Console.WriteLine("-------------------------\n");

                Console.Write("You You Like To Convert More Grades (Y/N)? ");
                doAgain = Console.ReadLine().ToLower();
            } while (doAgain.Equals("y"));
        }
    }
}
