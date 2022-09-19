using System;
using System.Collections.Generic;
class MenuOrder
{
    static void Main()
    {

        // Declare dictionary of string keys and double values
        Dictionary<string, double> menu = new Dictionary<string, double>();

        // Add key/value pairs in dictionary
        menu.Add("Baja Taco", 4.00);
        menu.Add("Burrito", 7.50);
        menu.Add("Bowl", 8.50);
        menu.Add("Nachos", 11.00);
        menu.Add("Quesadilla", 8.50);
        menu.Add("Super Burrito", 8.50);
        menu.Add("Super Quesadilla", 9.50);
        menu.Add("Taco", 3.00);
        menu.Add("Tortilla Salad", 8.00);



        // Display the menu
        Console.WriteLine("====\tMenu Items\t====\n");
        foreach (KeyValuePair<string, double> ele in menu)
        {
            Console.WriteLine("\t{0} : {1}", ele.Key, ele.Value);
        }
        Console.WriteLine();

        // loop to ask the user to place the order, terminates when the user enters the end
        double total_cost = 0.00;
        while (true)
        {
            try
            {
                // get the item name from the user to place the order.
                string item;
                Console.Write("Place the order: ");
                item = Console.ReadLine();

                // check if the user has entered end in whatever case!
                if (item.ToLower() == "end")
                {
                    break;
                }
                // if the user has entered the correct item-name then, 
                else if (menu.ContainsKey(item))
                {
                    total_cost += menu[item];
                    Console.WriteLine("Your total cost is : ${0:0.00}", total_cost);
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

