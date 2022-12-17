namespace finalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "player_log.csv";

            List<string> names = new List<string>();
            List<int> wins = new List<int>();
            List<int> losses = new List<int>();
            List<int> ties = new List<int>();
            int index;
            try
            {
                foreach (string line in File.ReadLines(filename))
                {
                    if (line.Length > 0)
                    {
                        string[] data = line.Split(',');
                        names.Add(data[0]);
                        wins.Add(int.Parse(data[1]));
                        losses.Add(int.Parse(data[2]));
                        ties.Add(int.Parse(data[3]));
                    }
                }
            }
            catch (Exception ex)
            {

            }

            int choice1;
            while (true)
            {
                Console.WriteLine("Welcome to Rock, Paper, Scissors!\n");
                Console.WriteLine("    1. Start New Game");
                Console.WriteLine("    2. Load Game");
                Console.WriteLine("    3. Quit");
                Console.Write("\nEnter choice: ");
                while (int.TryParse(Console.ReadLine(), out choice1) == false || choice1 < 1 || choice1 > 3)
                {
                    Console.Write("Invalid choice, try again.\nEnter choice: ");
                }

                if (choice1 == 1 || choice1 == 2)
                {
                    bool play = true;
                    string name = "";
                    index = -1;
                    int roundNumber = 1;
                    if (choice1 == 1)
                    {
                        Console.Write("\nWhat is your name? ");
                        name = Console.ReadLine().Trim();
                        for (index = 0; index < names.Count; index++)
                        {
                            if (names[index] == name)
                            {
                                play = false;
                                Console.WriteLine($"\n{name}, already exist.");
                                break;
                            }
                        }
                        if (index == names.Count)
                        {
                            play = true;
                            Console.WriteLine($"\nHello {name}. Let’s play!");
                            names.Add(name);
                            wins.Add(0);
                            losses.Add(0);
                            ties.Add(0);
                            roundNumber = 1;
                        }
                    }
                    else if (choice1 == 2)
                    {
                        Console.Write("\nWhat is your name? ");
                        name = Console.ReadLine().Trim();
                        for (index = 0; index < names.Count; index++)
                        {
                            if (names[index] == name)
                            {
                                play = true;
                                Console.WriteLine($"\nWelcome back {name}. Let’s play!");
                                break;
                            }
                        }
                        if (index == names.Count)
                        {
                            play = false;
                            Console.WriteLine($"\n{name}, your game could not be found.");
                        }
                    }
                    int choice2 = 1;
                    while (play)
                    {
                        if (choice2 == 1)
                        {
                            Console.WriteLine($"\nRound {roundNumber}\n");
                            Console.WriteLine("    1. Rock");
                            Console.WriteLine("    2. Paper");
                            Console.WriteLine("    3. Scissors");
                            Console.Write("\nWhat will it be? ");
                            int userChoice, computerChoice;
                            while (int.TryParse(Console.ReadLine(), out userChoice) == false || userChoice < 1 || userChoice > 3)
                            {
                                Console.Write("Invalid choice, try again.\nWhat will it be? ");
                            }

                            computerChoice = (new Random()).Next(3) + 1;

                            if (userChoice == 1 && computerChoice == 1)
                            {
                                Console.WriteLine("\nYou chose Rock. The computer chose Rock. Game tie!");
                                ties[index]++;
                            }
                            else if (userChoice == 1 && computerChoice == 2)
                            {
                                Console.WriteLine("\nYou chose Rock. The computer chose Paper. You lose!");
                                losses[index]++;
                            }
                            else if (userChoice == 1 && computerChoice == 3)
                            {
                                Console.WriteLine("\nYou chose Rock. The computer chose Scissors. You win!");
                                wins[index]++;
                            }
                            else if (userChoice == 2 && computerChoice == 1)
                            {
                                Console.WriteLine("\nYou chose Paper. The computer chose Rock. You win!");
                                wins[index]++;
                            }
                            else if (userChoice == 2 && computerChoice == 2)
                            {
                                Console.WriteLine("\nYou chose Paper. The computer chose Paper. Game tie!");
                                ties[index]++;
                            }
                            else if (userChoice == 2 && computerChoice == 3)
                            {
                                Console.WriteLine("\nYou chose Paper. The computer chose Scissors. You lose!");
                                losses[index]++;
                            }
                            else if (userChoice == 3 && computerChoice == 1)
                            {
                                Console.WriteLine("\nYou chose Scissors. The computer chose Rock. You lose!");
                                losses[index]++;
                            }
                            else if (userChoice == 3 && computerChoice == 2)
                            {
                                Console.WriteLine("\nYou chose Scissors. The computer chose Paper. You win!");
                                wins[index]++;
                            }
                            else if (userChoice == 3 && computerChoice == 3)
                            {
                                Console.WriteLine("\nYou chose Scissors. The computer chose Scissors. Game tie!");
                                ties[index]++;
                            }
                            roundNumber++;
                        }
                        else if (choice2 == 2)
                        {
                            Console.WriteLine($"\n{name}, here are your game play statistics...");
                            Console.WriteLine($"Wins: {wins[index]}");
                            Console.WriteLine($"Losses: {losses[index]}");
                            Console.WriteLine($"Ties: {ties[index]}");
                            Console.WriteLine("Win/Loss Ratio: {0:#.00}", (double)wins[index] / (double)losses[index]);
                        }
                        else if (choice2 == 3)
                        {
                            Console.WriteLine("\nGlobal Game Statistics");
                            Console.WriteLine("----------------------");
                            List<string> namesCopy = new List<string>(names);
                            List<int> winsCopy = new List<int>(wins);
                            List<int> lossesCopy = new List<int>(losses);
                            List<int> tiesCopy = new List<int>(ties);

                            for (int i = 0; i < namesCopy.Count; i++)
                            {
                                int maxIndex = i;
                                for (int j = i + 1; j < namesCopy.Count; j++)
                                {
                                    if ((winsCopy[maxIndex] < winsCopy[j]) || (winsCopy[maxIndex] == winsCopy[j] && namesCopy[maxIndex].CompareTo(namesCopy[j]) < 0))
                                    {
                                        maxIndex = j;
                                    }
                                }
                                if (maxIndex != i)
                                {
                                    string temp1 = namesCopy[i];
                                    namesCopy[i] = namesCopy[maxIndex];
                                    namesCopy[maxIndex] = temp1;
                                    int temp2 = winsCopy[i];
                                    winsCopy[i] = winsCopy[maxIndex];
                                    winsCopy[maxIndex] = temp2;
                                    temp2 = lossesCopy[i];
                                    lossesCopy[i] = lossesCopy[maxIndex];
                                    lossesCopy[maxIndex] = temp2;
                                    temp2 = tiesCopy[i];
                                    tiesCopy[i] = tiesCopy[maxIndex];
                                    tiesCopy[maxIndex] = temp2;
                                }
                            }
                            Console.WriteLine("----------------------");
                            Console.WriteLine("Top 10 Winning Players");
                            Console.WriteLine("----------------------");
                            for (int i = 0; i < 10 && i < namesCopy.Count; i++)
                            {
                                Console.WriteLine($"{namesCopy[i]}: {winsCopy[i]} wins");
                            }

                            for (int i = 0; i < namesCopy.Count; i++)
                            {
                                int maxIndex = i;
                                for (int j = i + 1; j < namesCopy.Count; j++)
                                {
                                    if ((winsCopy[maxIndex] + lossesCopy[maxIndex] + tiesCopy[maxIndex] < winsCopy[j] + lossesCopy[j] + tiesCopy[j])
                                        || (winsCopy[maxIndex] + lossesCopy[maxIndex] + tiesCopy[maxIndex] == winsCopy[j] + lossesCopy[j] + tiesCopy[j] && namesCopy[maxIndex].CompareTo(namesCopy[j]) < 0))
                                    {
                                        maxIndex = j;
                                    }
                                }
                                if (maxIndex != i)
                                {
                                    string temp1 = namesCopy[i];
                                    namesCopy[i] = namesCopy[maxIndex];
                                    namesCopy[maxIndex] = temp1;
                                    int temp2 = winsCopy[i];
                                    winsCopy[i] = winsCopy[maxIndex];
                                    winsCopy[maxIndex] = temp2;
                                    temp2 = lossesCopy[i];
                                    lossesCopy[i] = lossesCopy[maxIndex];
                                    lossesCopy[maxIndex] = temp2;
                                    temp2 = tiesCopy[i];
                                    tiesCopy[i] = tiesCopy[maxIndex];
                                    tiesCopy[maxIndex] = temp2;
                                }
                            }
                            Console.WriteLine("\n----------------------");
                            Console.WriteLine("Most Games Played");
                            Console.WriteLine("----------------------");
                            for (int i = 0; i < 5 && i < namesCopy.Count; i++)
                            {
                                Console.WriteLine($"{namesCopy[i]}: {winsCopy[i] + lossesCopy[i] + tiesCopy[i]} games played");
                            }

                            int totalWins = 0, totalLosses = 0;
                            for (int i = 0; i < 5 && i < namesCopy.Count; i++)
                            {
                                totalWins += winsCopy[i];
                                totalLosses += lossesCopy[i];
                            }
                            Console.WriteLine("\n----------------------");
                            Console.WriteLine("Overall Win / Loss Ratio: {0:#.00}", (double)totalWins / (double)totalLosses);
                            Console.WriteLine("----------------------");

                            int totalGames = 0;
                            for (int i = 0; i < 5 && i < namesCopy.Count; i++)
                            {
                                totalGames += winsCopy[i] + lossesCopy[i] + tiesCopy[i];
                            }
                            Console.WriteLine("\n----------------------");
                            Console.WriteLine($"Total Games Played: {totalGames}");
                            Console.WriteLine("----------------------");
                        }
                        else if (choice2 == 4)
                        {
                            try
                            {
                                StreamWriter sw = new StreamWriter(filename);
                                for (int i = 0; i < names.Count; i++)
                                {
                                    sw.WriteLine($"{names[i]},{wins[i]},{losses[i]},{ties[i]}");
                                }
                                sw.Close();
                                Console.WriteLine($"\n{name}, your game has been saved.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"\nSorry {name}, the game could not be saved.");
                            }
                            break;
                        }

                        Console.WriteLine("\nWhat would you like to do?\n");
                        Console.WriteLine("    1. Play Again");
                        Console.WriteLine("    2. View Player Statisics");
                        Console.WriteLine("    3. View Leaderboard");
                        Console.WriteLine("    4. Quit");
                        Console.Write("\nEnter choice: ");
                        while (int.TryParse(Console.ReadLine(), out choice2) == false || choice2 < 1 || choice2 > 4)
                        {
                            Console.Write("Invalid choice, try again.\nEnter choice: ");
                        }
                    }
                    break;
                }
                else if (choice1 == 3)
                {
                    break;
                }
            }

        }
    }
}