
using System.Text;

//variable declarations
double coin;
string[] input;
double amount_due = 50;
bool repeat = true;

/* run a loop as long the amount entered is less than 0.60 or repeat is true */
while (amount_due > 0)
{
    //prompt and read a coin
    Console.WriteLine("Amount Due: " + amount_due);
    Console.Write("Enter a coin: ");
    int coin_Entered = Convert.ToInt32(Console.ReadLine());

    amount_due = amount_due - coin_Entered;

}
int change_owed = 0;
Console.Write("Change Owed: 0");

