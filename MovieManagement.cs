using System;
using System.Collections.Generic;
namespace MovieManagement
{
    class Program
    {
        class Movie
        {
            public string Name { get; set; }
            public int Length { get; set; } 
            public int Year { get; set; } 
            public string Description { get; set; }

            public override string ToString()
            {
                return $"Name: {Name}, Length: {Length} minutes, Year: {Year}, Description: {Description}";
            }
        }

        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>();

            while (true)
            {
                Console.WriteLine("\nMovie Management Software");
                Console.WriteLine("1. Create a new movie");
                Console.WriteLine("2. Display all movies");
                Console.WriteLine("3. Remove a movie");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateMovie(movies);
                        break;
                    case "2":
                        DisplayMovies(movies);
                        break;
                    case "3":
                        RemoveMovie(movies);
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

        static void CreateMovie(List<Movie> movies)
        {
            Console.Write("Enter movie name: ");
            string name = Console.ReadLine();

            Console.Write("Enter movie length (in minutes): ");
            if (!int.TryParse(Console.ReadLine(), out int length) || length <= 0)
            {
                Console.WriteLine("Invalid length. Movie not created.");
                return;
            }

            Console.Write("Enter year of production: ");
            if (!int.TryParse(Console.ReadLine(), out int year) || year <= 0)
            {
                Console.WriteLine("Invalid year. Movie not created.");
                return;
            }

            Console.Write("Enter movie description: ");
            string description = Console.ReadLine();

            movies.Add(new Movie
            {
                Name = name,
                Length = length,
                Year = year,
                Description = description
            });

            Console.WriteLine("Movie added successfully!");
        }

        static void DisplayMovies(List<Movie> movies)
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies to display.");
                return;
            }

            Console.WriteLine("\nList of Movies:");
            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {movies[i]}");
            }
        }

        static void RemoveMovie(List<Movie> movies)
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies to remove.");
                return;
            }

            Console.WriteLine("\nSelect a movie to remove:");
            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {movies[i].Name}");
            }

            Console.Write("Enter the number of the movie to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index <= 0 || index > movies.Count)
            {
                Console.WriteLine("Invalid selection. No movie removed.");
                return;
            }

            movies.RemoveAt(index - 1);
            Console.WriteLine("Movie removed successfully!");
        }
    }
}