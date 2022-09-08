
using System.Text;

//variable declarations
double coin;
string[] input;
double amount_due = 50;
bool repeat = true;


static float number()
{
    float input;
    try
    {
        Console.WriteLine("Insert Coin: ");
        input = float.Parse(Console.ReadLine());
    }
    catch (Exception)
    {
        Console.WriteLine("Error: only numbers 1,5,10,25 allowed");
        return -1;
    }
    return input;
}


/* run a loop as long the amount entered is less than 0.60 or repeat is true */
while (amount_due > 0)
{
    Console.WriteLine("Amount Due: " + amount_due);
    float num = number();
    if (num == 1 && num == 5 && num == 10 && num == 25)
    {
        amount_due = amount_due - num;
    }
    else if ((num != 1 && num != 5 && num != 10 && num != 25))
    {
        Console.WriteLine($"Error: only numbers 1,5,10,25 allowed.");
    }
}

