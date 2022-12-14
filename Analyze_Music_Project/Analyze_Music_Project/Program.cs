using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AnalyzeMusicPlaylist
{
    // This class encapsulates the data pertaining to a song.
    class Song
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public string Size { get; set; }
        public int Time { get; set; }
        public int Year { get; set; }
        public int Plays { get; set; }

        override public string ToString()
        {
            return String.Format("Name: {0}, Artist: {1}, Album: {2}, Genre: {3}, Size: {4}, Time: {5}, Year: {6}, Plays: {7}", Name, Artist, Album, Genre, Size, Time, Year, Plays);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Check to see if there are the proper number of command line arguments
            if (args.Length != 2)
            {
                Console.WriteLine("Improper usage. Please run the program like so:");
                Console.WriteLine("MusicPlaylistAnalyzer.exe <music_playlist_file_path> <report_file_path>");
                return;
            }

            // Read the files line by line
            var input_File = args[0];
            var output_File = args[1];
            List<Song> songs = new List<Song>();
            try
            {
                var lines = File.ReadLines(input_File);
                var line_Number = 0;

                foreach (var line in lines)
                {
                    // Skip first line
                    if (line_Number++ == 0)
                    {
                        continue;
                    }

                    // Split line
                    var split = line.Split('\t');
                    try
                    {
                        // Initialize a new song with the given info
                        Song song;
                        try
                        {
                            song = new Song
                            {
                            int invoice_num = int.Parse(values[0]);
                            string branch = values[1];
                            string city = values[2];
                            string customer_type = values[3];
                            string gender = values[4];
                            string product_line = values[5];
                            float unit_price = float.Parse(values[6]);
                            int quantity = int.Parse(values[7]);
                            // Parsing the invoice date 
                            string[] d = values[8].Split("/");
                            int year = int.Parse(d[0]);
                            int month = int.Parse(d[1]);
                            int day = int.Parse(d[2]);
                            DateTime date = new DateTime(year, month, day);
                            // Parsing rest of  the data
                            string payment = values[9];
                            float rating = float.Parse(values[10]);
                            // Adding the new sale to list
                            sales.Add(new Sale(invoice_num, branch, city, customer_type, gender, product_line, unit_price, quantity, date, payment, rating));
                        };
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Record contains data of invalid type.");
                            return;
                        }
                        songs.Add(song);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine(String.Format("Row {} contains {} values. It should contain 8.", line_Number, split.Length));
                        return;
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Error opening file. Check that it exists and try again.");
                return;
            }

            try
            {
                using (StreamWriter writetext = new StreamWriter(output_File))
                {

                    writetext.WriteLine("Music Playlist Report\n");

                    // Songs that had 200 or more plays
                    var songs_200 = from song in songs where song.Plays >= 200 orderby song.Year descending select song;
                    writetext.WriteLine("Songs that received 200 or more plays:");
                    foreach (var song in songs_200)
                    {
                        writetext.WriteLine(song);
                    }

                    // Number of songs with the genre "Alternative"
                    var alternative_Songs = (from song in songs where song.Genre == "Alternative" select song).Count();
                    writetext.WriteLine("\nNumber of Alternative Songs: " + alternative_Songs);

                    // Number of songs with the genre "Hip-Hop/Rap"
                    var hiphop_Songs = (from song in songs where song.Genre == "Hip-Hop/Rap" select song).Count();
                    writetext.WriteLine("\nNumber of Alternative Songs: " + hiphop_Songs);

                    // Songs from the album "Welcome to the Fishbowl"
                    var fishbowl_Songs = from song in songs where song.Album == "Welcome to the Fishbowl" orderby song.Year descending select song;
                    writetext.WriteLine("\nSongs that are from the album \"Welcome to the Fishbowl\":");
                    foreach (var song in fishbowl_Songs)
                    {
                        writetext.WriteLine(song);
                    }

                    // Songs from before 1970
                    var oldSongs = from song in songs where song.Year <= 1970 orderby song.Year descending select song;
                    writetext.WriteLine("\nSongs that are from before 1970:");
                    foreach (var song in oldSongs)
                    {
                        writetext.WriteLine(song);
                    }

                    // Song names that are more than 85 characters long
                    var longNameSongs = from song in songs where song.Name.ToCharArray().Length > 85 orderby song.Year descending select song;
                    writetext.WriteLine("\nSongs whose names are more thna 85 characters long:");
                    foreach (var song in longNameSongs)
                    {
                        writetext.WriteLine(song);
                    }

                    // Longest song
                    var longestSong = songs.OrderByDescending(song => song.Time).First();
                    writetext.WriteLine("\nLongest song:");
                    writetext.WriteLine(longestSong);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error writing to report file. Exiting...");
                return;
            }
        }
    }
}
