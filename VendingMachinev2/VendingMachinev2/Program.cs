


namespace GradeConverter
{
    class Program
    {


        static float get_coins()
        {
            Console.WriteLine("Insert Coin: ");
            float input = float.Parse(Console.ReadLine());
            if (input != 1 && input != 5 && input != 10 && input != 25)
            {
                Console.WriteLine("You should only insert 1, 5, 10, or 25");
                return get_coins();
            }
            else
            {
                return input;
            }
        }

        static void Main(string[] args)
        {
            float amount_due = 50;
            while (amount_due > 0)
            {
                Console.WriteLine($"Amount Due: {amount_due}");
                float coin = get_coins();

                amount_due -= coin;
            }
            if (amount_due < 0)
            {
                Console.WriteLine($"Change Owes you: {Math.Abs(amount_due)}");
            }

        }

    }
}