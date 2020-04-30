using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MovieLab
{
    class Program
    {
        static List<Movie> movies;
        static void Main(string[] args)
        {
            bool cont = true;
            while (cont)
            {
                movies = new List<Movie>
                {
                    new Movie("Avatar",Genre.SciFi),
                    new Movie("Onward",Genre.Animated),
                    new Movie("Rec",Genre.Horror),
                    new Movie("Halloween",Genre.Horror),
                    new Movie("The Conjuring",Genre.Horror),
                    new Movie("Up",Genre.Animated),
                    new Movie("Finding Nemo",Genre.Animated),
                    new Movie("Cars",Genre.Animated),
                    new Movie("Pulp Fiction",Genre.Drama),
                    new Movie("2001 A Space Odyssey",Genre.SciFi),
                };
                ListGenres();
                int category = GetCategorySelection("Please select a movie category by number: ")-1;
                GetMovies(movies, (Genre)category).ForEach(x => Console.WriteLine(x.Name));

                Console.WriteLine("Please enter y(es) to continue or anything else to exi: ");
                cont = Console.ReadLine().ToLower().StartsWith('y');
            }

        }

        static int GetCategorySelection(string prompt)
        {
            int? ret = null;
            bool validSelection = false;
            while (!ret.HasValue || !validSelection)
            {
                Console.Write(prompt);
                try
                {
                    ret = int.Parse(Console.ReadLine());
                    if (Enum.IsDefined(typeof(Genre), ret-1))
                    {
                        validSelection = true;
                    }
                    else
                    {
                        Console.WriteLine("That's not a valid category number!");
                    }
                }
                catch
                {
                    Console.WriteLine("Input was not valid, try again");
                }
            }
            return ret.Value;
        }

        static List<Movie> GetMovies(List<Movie> list, Genre category)
        {
            List<Movie> ret = new List<Movie>();
            return list.Where(x => x.Category.Equals(category)).ToList();
        }

        static void ListGenres()
        {
            int i = 0;
            foreach (Genre g in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{++i}. {g.ToString()}");
            }
        }
    }
}
