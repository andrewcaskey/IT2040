
namespace Document
{

    class Document
    {

        static void Main(string[] args)
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

    }

}

