using System;


namespace Automobile
{
    enum AutoType { Sedan, Truck, Van, SUV };
    class Automobile
    {
        string make;
        string model;
        string vin;
        string color;
        int year;
        AutoType autoType;

        public Automobile(string mak, string mo, int y, string vi, string col, AutoType type)
        {
            make = mak;
            model = mo;
            year = y;
            vin = vi;
            color = col;
            autoType = type;

        }

        public string getMake()
        {
            return make;
        }
        public string getModel()
        {
            return model;
        }
        public int getYear()
        {
            return year;
        }
        public void setColor(string Color)
        {
            color = Color;
        }
        public string getColor()
        {
            return color;
        }
        public AutoType getType()
        {
            return autoType;
        }
        public int getAutoAge()
        {
            return year;
        }
        public string getVin()
        {
            return vin;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nCreating the first Automobile\n---------------");
            Automobile auto1 = new Automobile("Tesla", "Model X", 2020, "12345", "blue", AutoType.Sedan);
            Console.WriteLine($"Make: {auto1.getMake()} \nModel: {auto1.getModel()}\nYear: {auto1.getYear()}\nType: {auto1.getType()} \nVIN: {auto1.getVin()}");
            Console.WriteLine($"Color: {auto1.getColor()}");
            Console.WriteLine("\nChanging the Colour\n---------------");
            auto1.setColor("black");
            Console.WriteLine($"Color: {auto1.getColor()}");

            Console.WriteLine("\nCreating the second Automobile\n---------------");
            Automobile auto2 = new Automobile("Mercedes", "G-Wagon", 2017, "24578", "silver", AutoType.SUV);
            Console.WriteLine($"Make: {auto2.getMake()}\nModel: {auto2.getModel()}\nYear: {auto2.getYear()}\nType: {auto2.getType()}\nVIN: {auto2.getVin()}");

            Console.WriteLine("\nPrinting Automobile Ages\n---------------");
            Console.WriteLine($"Auto1 Age: {auto1.getAutoAge()} years");
            Console.WriteLine($"Auto2 Age: {auto2.getAutoAge()} years");

            Console.ReadLine();
        }
    }
}

