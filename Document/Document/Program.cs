using System;
using System.IO;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace Document
{

    class Document
    {

        static void RunOnce()
        {

            try
            {

                Console.WriteLine("Document");

                Console.WriteLine("Enter Document Title:");

                string name = Console.ReadLine();

                Console.WriteLine("Enter Document Content:");

                string str = Console.ReadLine();

                string filename = name + ".txt";

                string path = Environment.CurrentDirectory + "/" + filename;

                if (!File.Exists(path))

                {

                    File.WriteAllText(path, str);

                }

                int l = 0;
                int wrd = 1;
                while (l <= str.Length - 1)
                {
                    /* check whether the current character is white space or new line or tab character*/
                    if (str[l] == ' ' || str[l] == '\n' || str[l] == '\t')
                    {
                        wrd++;
                    }

                    l++;
                }

                Console.WriteLine(filename + " was successfully saved. The document contains " + wrd + " words");
            }

            catch (Exception e)

            {

                Console.WriteLine(e);

            }


        }


            static void Main(string[] args)
            {


                do
                {
                    RunOnce();
                    Console.WriteLine("Would you like to write another file? (y/n)"); // prompt for running again
                    char c = Console.ReadLine()[0]; // reading first character
                    if (c == 'n') // checking for 'no' option
                        break; // break the loop
                } while (true); // run again

            }

        }
    }



    



