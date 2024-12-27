using System;
using System.Collections.Generic;
namespace VideoGameManagement
{
    class Program
    {
        class VideoGame
        {
            public string Name { get; set; }
            public string Genre { get; set; }
            public int YearOfProduction { get; set; }
            public string Description { get; set; }

            public override string ToString()
            {
                return $"Name: {Name}, Genre: {Genre}, Year: {YearOfProduction}, Description: {Description}";
            }
        }

        static void Main(string[] args)
        {
            List<VideoGame> videoGames = new List<VideoGame>();
            while (true)
            {
                Console.WriteLine("\nVideo Game Management Software");
                Console.WriteLine("1. Create a new game");
                Console.WriteLine("2. Display all games");
                Console.WriteLine("3. Remove a game");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateGame(videoGames);
                        break;
                    case "2":
                        DisplayGames(videoGames);
                        break;
                    case "3":
                        RemoveGame(videoGames);
                        break;
                    case "4":
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CreateGame(List<VideoGame> videoGames)
        {
            Console.Write("Enter game name: ");
            string name = Console.ReadLine();

            Console.Write("Enter game genre: ");
            string genre = Console.ReadLine();

            Console.Write("Enter year of production: ");
            if (!int.TryParse(Console.ReadLine(), out int year) || year <= 0)
            {
                Console.WriteLine("Invalid year. Game not created.");
                return;
            }

            Console.Write("Enter game description: ");
            string description = Console.ReadLine();

            videoGames.Add(new VideoGame
            {
                Name = name,
                Genre = genre,
                YearOfProduction = year,
                Description = description
            });

            Console.WriteLine("Game added successfully!");
        }

        static void DisplayGames(List<VideoGame> videoGames)
        {
            if (videoGames.Count == 0)
            {
                Console.WriteLine("No games to display.");
                return;
            }

            Console.WriteLine("\nList of Games:");
            for (int i = 0; i < videoGames.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {videoGames[i]}");
            }
        }

        static void RemoveGame(List<VideoGame> videoGames)
        {
            if (videoGames.Count == 0)
            {
                Console.WriteLine("No games to remove.");
                return;
            }

            Console.WriteLine("\nSelect a game to remove:");
            for (int i = 0; i < videoGames.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {videoGames[i].Name}");
            }

            Console.Write("Enter the number of the game to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index <= 0 || index > videoGames.Count)
            {
                Console.WriteLine("Invalid selection. No game removed.");
                return;
            }

            videoGames.RemoveAt(index - 1);
            Console.WriteLine("Game removed successfully!");
        }
    }
}