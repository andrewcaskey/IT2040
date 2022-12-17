using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor
{
    internal class Player
    {
        public string name;
        public int won;
        public int loss;
        public int ties;
        public int total_games;

        public static List<Player> players = new List<Player>();

        Player(string name, int won, int loss, int ties)
        {
            this.name = name;
            this.ties = ties;
            this.won = won;
            this.loss = loss;
            this.total_games = ties + won + loss;

        }

        public Player()
        {
        }

        public void writeData()
        {
            StreamWriter sw = new StreamWriter("player_log.csv");


            for (int i = 0; i < players.Count(); i++)
            {
                sw.Write(players[i].name+",");
                sw.Write(players[i].won + ",");
                sw.Write(players[i].loss + ",");
                sw.WriteLine(players[i].ties);
            }


            sw.Flush();

            sw.Close();
             
        }

        public void readData()
        {
            StreamReader sr = new StreamReader("player_log.csv");
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            Player p = new Player();

            string line = sr.ReadLine();

            while (line != null)
            {
                string[] data = line.Split(',');

                p = new Player(data[0], Int32.Parse(data[1]), Int32.Parse(data[2]), Int32.Parse(data[3]));
                players.Add(p);

                line = sr.ReadLine();

            }
            sr.Close();

        }

        public void printStatistics()
        {
            Console.WriteLine("Global Game Statistics");
            Console.WriteLine("-----------------------");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Top 10 winning player");
            Console.WriteLine("-----------------------");

            for (int i = 0; i < players.Count() - 1; i++)
            {

                for (int j = 0; j < players.Count() - i - 1; j++)
                {
                    if (players[j].won > players[j + 1].won)
                    {
                        Player temp = players[j];
                        players[j] = players[j + 1];
                        players[j + 1] = temp;
                    }
                }
            }

            for (int i = players.Count()-1; i > players.Count()-11; i--)
            {
                Console.WriteLine(players[i].name + ": " + players[i].won);

            }

            Console.WriteLine("\n-----------------------");
            Console.WriteLine("Most Game Played");
            Console.WriteLine("-----------------------");
            for (int i = 0; i < players.Count() - 1; i++)
            {

                for (int j = 0; j < players.Count() - i - 1; j++)
                {
                    if (players[j].total_games > players[j + 1].total_games)
                    {
                        Player temp = players[j];
                        players[j] = players[j + 1];
                        players[j + 1] = temp;
                    }
                }
            }

            

            for (int i = players.Count() - 1; i > players.Count() - 6; i--)
            {
                Console.WriteLine(players[i].name + ": " + players[i].total_games +" games played");

            }

            int totalGames = 0;
            double ratio = 0.0;
            for (int i = 0; i < players.Count(); i++)
            {
                totalGames += players[i].total_games;

                if (players[i].won == 0)
                {
                    ratio += players[i].won;
                }
                else
                {
                    ratio += players[i].won / players[i].loss;
                }
            
            }

            ratio = ratio/players.Count();

            Console.WriteLine("\n-----------------------");
            Console.WriteLine("Overall Win/Loss ratio: "+ratio);
            Console.WriteLine("-----------------------");

            Console.WriteLine("\n-----------------------");
            Console.WriteLine("Total Game played: "+totalGames);
            Console.WriteLine("-----------------------");




        }

        public void startingMenu()
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors!\n1.Start New Game\n2.Load Game\n3.Quit");
            Console.Write("Enter your Choice: ");
        }

        public void secondMenu()
        {
            Console.WriteLine("\n1. Rock\n2.Paper\n3.Scissors");
            Console.Write("What will it be: ");
        }

        public void thirdMenu()
        {
            Console.WriteLine("\nWhat would you like to do?\n1.Play Again\n2.View Player Statistics\n3.View Leaderboard\n4.Quit");
            Console.Write("Your Choice: ");
        }
        public void playGame()
        {
            int choice1 = 0;
            int round1 = 1;
            int index12 = 0;

            Player p = new Player();

            string[] tools = { "Rock", "Paper", "Scissors" };
            startingMenu();
            choice1 = Int32.Parse(Console.ReadLine());
            bool counter = true;
            while (true)
            {
                
                if (choice1 == 1)
                {
                    
                    String name = "";

                    if (counter)
                    {
                        
                        Console.Write("\nWhat is your name? ");
                        name = Console.ReadLine();
                        Console.WriteLine("\nHello " + name + ". Let's play");
                        p.name = name;
                        counter = false;

                    }

                    Console.WriteLine("\nRound: " + round1);
                    secondMenu();
                    int choice2 = Int32.Parse(Console.ReadLine());

                    String status = "";
                    Random rnd = new Random();
                    int index = rnd.Next(tools.Length);

                    if (tools[choice2 - 1] == "Rock" && tools[index] == "Scissors")
                    {
                        status = "won";
                        p.won++;
                        
                    }
                    else if (tools[choice2 - 1] == "Scissors" && tools[index] == "Paper")
                    {
                        status = "won";
                        p.won++;
                    }
                    else if (tools[choice2 - 1] == "Paper" && tools[index] == "Rock")
                    {
                        status = "won";
                        p.won++;
                    }
                    else if (tools[choice2 - 1] == tools[index])
                    {
                        status = "tie";
                        p.ties++;
                    }
                    else
                    {
                        status = "lose";
                        p.loss++;
                    }


                    Console.WriteLine("\nYou choose " + tools[choice2 - 1] + " Computer Choose " + tools[index] + ". You " + status);
                    
                    round1++;

                    while (true)
                    {
                        thirdMenu();
                        int choice3 = Int32.Parse(Console.ReadLine());
                        if (choice3 == 1)
                        {
                            choice1 = 1;
                            break;
                        }

                        else if (choice3 == 2)
                        {
                            Console.WriteLine(p.name + ", here are your game play statistics...");
                            Console.WriteLine("Win: " + p.won);
                            Console.WriteLine("Losses: " + p.loss);
                            Console.WriteLine("Ties: " + p.ties);
                            double ratio = 0;
                            if (p.loss == 0)
                            {
                                ratio = p.won;
                                Console.WriteLine("Win Loss Ratio: " + ratio);

                            }
                            else
                            {
                                ratio = p.won / p.loss;
                                Console.WriteLine("Win Loss Ratio: " + ratio);
                            }
                            
                        }
                        else if (choice3 == 3)
                        {
                            printStatistics();
                        }
                        else if (choice3 == 4)
                        {
                            Console.WriteLine(p.name +" Your game has been saved");
                            players.Add(p);
                            writeData();
                            counter = true;
                            Environment.Exit(0);
                        }

                    }

                }

                

                else if (choice1 == 2)
                {
                    String name = "";
                    

                    if (counter)
                    {
                        bool check = false;

                        Console.Write("\nWhat is your name? ");
                        name = Console.ReadLine();

                        for (int i = 0; i < players.Count(); i++)
                        {
                            if (players[i].name == name)
                            {
                                index12 = i;
                                check = true;
                            }
                        }

                        if (!check)
                        {
                            Console.WriteLine("Player not found");
                            break;
                        }

                        Console.WriteLine("\nWelcome Back " + name + ". Let's play\n");
                        p.name = name;
                        counter = false;

                    }

                    round1 = players[index12].total_games+1;

                    Console.WriteLine("Round: " + round1);
                    secondMenu();
                    int choice2 = Int32.Parse(Console.ReadLine());

                    String status = "";
                    Random rnd = new Random();
                    int index = rnd.Next(tools.Length);

                    if (tools[choice2 - 1] == "Rock" && tools[index] == "Scissors")
                    {
                        status = "won";
                        players[index12].won++;

                    }
                    else if (tools[choice2 - 1] == "Scissors" && tools[index] == "Paper")
                    {
                        status = "won";
                        players[index12].won++;
                    }
                    else if (tools[choice2 - 1] == "Paper" && tools[index] == "Rock")
                    {
                        status = "won";
                        players[index12].won++;
                    }
                    else if (tools[choice2 - 1] == tools[index])
                    {
                        status = "tie";
                        players[index12].ties++;
                    }
                    else
                    {
                        status = "lose";
                        players[index12].loss++;
                    }


                    Console.WriteLine("You choose " + tools[choice2 - 1] + " Computer Choose " + tools[index] + ". You " + status);

                    round1++;

                    while (true)
                    {
                        thirdMenu();
                        int choice3 = Int32.Parse(Console.ReadLine());
                        if (choice3 == 1)
                        {
                            choice1 = 1;
                            break;
                        }

                        else if (choice3 == 2)
                        {
                            Console.WriteLine(players[index12].name + ", here are your game play statistics...");
                            Console.WriteLine("Win: " + players[index12].won);
                            Console.WriteLine("Losses: " + players[index12].loss);
                            Console.WriteLine("Ties: " + players[index12].ties);

                            double ratio = 0;
                            if (p.loss == 0)
                            {
                                ratio = players[index12].won;
                                Console.WriteLine("Win Loss Ratio: " + ratio);

                            }
                            else
                            {
                                ratio = players[index12].won / players[index12].loss;
                                Console.WriteLine("Win Loss Ratio: " + ratio);
                            }
                        }
                        else if (choice3 == 3)
                        {
                            printStatistics();
                        }
                        else if (choice3 == 4)
                        {
                            Console.WriteLine(players[index12].name + " Your game has been saved");
                            writeData();
                            index12 = 0;
                            Environment.Exit(0);

                        }

                    }
                }

            }

        }
    }
}
