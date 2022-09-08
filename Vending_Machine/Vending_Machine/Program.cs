﻿
using System;
using System.Text;



namespace GradeConverter
{
    class Program
    {



        static float number()
        {
            float input;
            try
            {
                Console.WriteLine("Insert Coin: ");
                input = float.Parse(Console.ReadLine());
                //Console.WriteLine(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Error: only numbers 1,5,10,25 allowed");
                return -1;
            }
            return input;
        }

        static void Main(string[] args)
        {
            double amount_due = 50;

           
            while (amount_due > 0)
            {
                // 
                Console.WriteLine("Amount Due: " + amount_due);
                float num = number();

                // if number is within range, take number, otherwise request again
                if (num == 1 || num == 5 || num == 10 || num == 25)
                {
                    amount_due = amount_due - num;
                }
                else if ((num != 1 && num != 5 && num != 10 && num != 25))
                {
                    Console.WriteLine($"Error: only numbers 1,5,10,25 allowed.");
                }
               
            }
            // if numer
            if (amount_due < 0)
            {
                amount_due = Math.Abs(amount_due);
                Console.WriteLine("Change Due: ", amount_due);
                Console.WriteLine(amount_due);

            }
            else if (amount_due == 0)
            {
                Console.WriteLine("Change Due: ", amount_due);
                Console.WriteLine(amount_due);
            }
  
            System.Environment.Exit(1);
        }
    }
}
