using System;
using System.IO;

namespace DocumentMerger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter First text File: ");
                string file1 = Console.ReadLine();
                while (!File.Exists(file1))
                {
                    Console.Write("File does not exist or cannot be found, try again: ");
                    file1 = Console.ReadLine();
                }

                Console.Write("Enter Second File: ");
                string file2 = Console.ReadLine();
                while (!File.Exists(file2))
                {
                    Console.Write("File does not exist or cannot be found, try again: ");
                    file2 = Console.ReadLine();
                }



                string newFile = file1.Split('.')[0] + file2.Split('.')[0] + ".txt";





                string allText = System.IO.File.ReadAllText(file1);
                allText += "\r\n";
                allText += System.IO.File.ReadAllText(file2);

                if (!File.Exists(newFile))
                {
                    FileStream fs = File.Create(newFile);
                    fs.Close();
                }
                File.WriteAllText(newFile, allText);

                Console.WriteLine("Content Written to '" + newFile + "'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

