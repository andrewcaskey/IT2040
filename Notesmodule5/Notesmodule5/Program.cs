namespace DictionaryDemo
{
    class Program
    {


        static void Main(string[] args)
        {
            {
                //create dictionary containg car brands and models
                Dictionary<string, string> carDictionary = new Dictionary<string, string>() {
            { "Honda", "Accord" },
            { "Toyota", "Camry" },
            { "Ford", "Focus" },
            { "Chevy", "Impala" }

        };


                //add items to dictionary 
                carDictionary.Add("Hyundai", "Elantra");

                //Print value from the dictionary 
                Console.WriteLine(carDictionary["Honda"] + "\n");

                //Loop throguh car dictionary 
                foreach (KeyValuePair<string, string> entry in carDictionary)
                {
                    Console.WriteLine($"{entry.Key} makes the {entry.Value}");

                }
                Console.WriteLine();

                foreach (string key in carDictionary.Keys)
                {
                    Console.WriteLine($"{key}: {carDictionary[key]}");
                }
                Console.WriteLine();

                // check if key exists in the dictionary
                string searchKey = "Honda";
                if (carDictionary.ContainsKey(searchKey))
                {
                    Console.WriteLine($"{searchKey}: {carDictionary[searchKey]} exists");

                }
                else
                {
                    Console.WriteLine($"{searchKey} does not appear in the dictionary");
                }

            }


        }

    }

}