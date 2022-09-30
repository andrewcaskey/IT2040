using System;

namespace Fuel_Gage
{
    class main
    {
        public static void Main(string[] args)
        {

            // 
            while (true)
            {

                // Prompt for User Input
                Console.WriteLine("Fraction:");
                string numb;
                numb = Console.ReadLine();
                string string_1 = numb.ToLower();


                // if string is end, end the program
                if (string_1 == "end")
                {
                    break;
                }

                // method for fraction
                char[] spacer = { '/' };
                Int32 increment = 2;
                String[] strlist = numb.Split(spacer, increment,StringSplitOptions.RemoveEmptyEntries);
                int X = Convert.ToInt32(strlist[0]);
                int Y = Convert.ToInt32(strlist[1]);

                if (X > Y)
                {
                    continue;
                }

                else if (Y > X)
                {
                    double temp = (double)X / (double)Y;
                    if (temp * 100 > 98)
                    {
                        Console.WriteLine("F");
                    }
                    else if (temp * 100 < 2)
                    {
                        Console.WriteLine("E");
                    }
                    else
                    {
                        Console.WriteLine(String.Format("{0:0}%", temp * 100));
                    }

                }
            }
        }
    }
}

